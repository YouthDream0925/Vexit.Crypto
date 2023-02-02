using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NBitcoin;
using NBitcoin.RPC;
using Web.Models;
using Web.Api.KeyManagement;
using t = Web.Constants.Text;

namespace Web.Api
{
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly CryptoContext _context;

        public CryptoController(CryptoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public string Connect()
        {
            Network network = Network.TestNet;

			IConfiguration config = new ConfigurationBuilder()
				.AddJsonFile("nodesettings.json")
				.AddEnvironmentVariables()
				.Build();

			Settings settings = config.GetRequiredSection("Settings").Get<Settings>();

			Console.WriteLine($"Connecting to {network.Name}");

			RPCClient rpcClientInitial = SetupRpcClient(settings, network);

			// get blockcahin information
			BlockchainInfo blockchainInfo = rpcClientInitial.GetBlockchainInfo();
			Console.WriteLine($"Blockchain Blocks: {blockchainInfo.Blocks}");
			Console.WriteLine($"Blockchain Mining Difficulty: {blockchainInfo.Difficulty}");
			Console.WriteLine($"Blockchain Best Blockhash: {blockchainInfo.BestBlockHash}");
			Console.WriteLine();

            return "Success";
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public string CreateWallet(CreateWallet wallet)
        {
            string walletName = wallet.walletName, pw = wallet.pw, pwConfirmed = wallet.pwConfirmed, result = "";
            Network currentNetwork = Network.TestNet;
            if(pw != pwConfirmed)
                return t.pwConfirmefail;
            else
            {
                try
                {
                    Mnemonic mnemonic;
                    Safe safe = Safe.Create(out mnemonic, pw, t.walletFilePath + walletName + ".json", currentNetwork);
                    // TODO: Initialize the Wallet with the Correct Parameters.

                    result = t.GetMnemonicMessage($"{mnemonic}");

                    for (int i = 0; i < 10; i++)
                        result += $"\n{t.BTCAddress}: {safe.GetAddress(i)} -> {t.PrivateKey}: {safe.FindPrivateKey(safe.GetAddress(i))}";
                }
                catch
                {
                    result = t.walletExist;
                }
            }
            return result;
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public string ImportWallet([FromForm]ImportWallet wallet)
        {
            IFormFile file = wallet.File;
            StringBuilder fileContent = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    fileContent.AppendLine(reader.ReadLine());
            }
            try
            {
                JObject walletJObject = JObject.Parse(fileContent.ToString());
                if(ValidateWalletFormat(file.FileName, walletJObject))
                    return t.walletImportSuccess;
                else
                    return t.ExceptionOccured;
            }
            catch
            {
                return t.ExceptionOccured;
            }
        }
        public static RPCClient SetupRpcClient(Settings settings, Network network, string walletName = null)
		{
			RPCCredentialString credentialString = RPCCredentialString.Parse($"{settings.RpcUserName}:{settings.RpcPassword}");

			if (walletName != null)
			{
				credentialString.WalletName = walletName;
			}

			RPCClient rpcClient = new RPCClient(credentialString, $"{settings.RpcIpAddress}:{settings.Port}", network);
			return rpcClient;
		}

        public static bool ValidateWalletFormat(string fileName, JObject wallet)
        {
            string filePath = t.walletFilePath + fileName;
            if(wallet.Count == 4 && wallet["EncryptedSeed"] != null && wallet["ChainCode"] != null && wallet["Network"] != null && wallet["CreationTime"] != null)
            {
                try
                {
                    WalletFileSerializer.Serialize(filePath, (string) wallet["EncryptedSeed"], (string) wallet["ChainCode"], (string) wallet["Network"], (string) wallet["CreationTime"]);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}