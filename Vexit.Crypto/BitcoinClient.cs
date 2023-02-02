using Newtonsoft.Json.Linq;

namespace Vexit.Crypto
{

    public class BitcoinClient
    {
        private RpcConnection _rpc;


        public BitcoinClient()
        { 
        }

        public BitcoinClient(string uri)
        {
           _rpc = new RpcConnection(uri);
        }



        public void BackupWallet(string a_destination)
        {
            _rpc.Call("backupwallet", a_destination);
        }

        public string GetAccount(string a_address)
        {
            return _rpc.Call("getaccount", a_address)["result"].ToString();
        }

        public string GetAccountAddress(string a_account)
        {
            return _rpc.Call("getaccountaddress", a_account)["result"].ToString();
        }

        public IEnumerable<string> GetAddressesByAccount(string a_account)
        {
            return from o in _rpc.Call("getaddressesbyaccount", a_account)["result"]
                   select o.ToString();
        }

        public float GetBalance(string a_account = null, int a_minconf = 1)
        {
            if (a_account == null)
            {
                return (float)_rpc.Call("getbalance")["result"];
            }
            return (float)_rpc.Call("getbalance", a_account, a_minconf)["result"];
        }

        public string GetBlockByCount(int a_height)
        {
            return _rpc.Call("getblockbycount", a_height)["result"].ToString();
        }

        public int GetBlockCount()
        {
            return (int)_rpc.Call("getblockcount")["result"];
        }

        public int GetBlockNumber()
        {
            return (int)_rpc.Call("getblocknumber")["result"];
        }

        public int GetConnectionCount()
        {
            return (int)_rpc.Call("getconnectioncount")["result"];
        }

        public float GetDifficulty()
        {
            return (float)_rpc.Call("getdifficulty")["result"];
        }

        public bool GetGenerate()
        {
            return (bool)_rpc.Call("getgenerate")["result"];
        }

        public float GetHashesPerSec()
        {
            return (float)_rpc.Call("gethashespersec")["result"];
        }

        public JObject GetInfo()
        {
            return _rpc.Call("getinfo")["result"] as JObject;
        }

        public string GetNewAddress(string a_account)
        {
            return _rpc.Call("getnewaddress", a_account)["result"].ToString();
        }

        public float GetReceivedByAccount(string a_account, int a_minconf = 1)
        {
            return (float)_rpc.Call("getreceivedbyaccount", a_account, a_minconf)["result"];
        }

        public float GetReceivedByAddress(string a_address, int a_minconf = 1)
        {
            return (float)_rpc.Call("getreceivedbyaddress", a_address, a_minconf)["result"];
        }

        public JObject GetTransaction(string a_txid)
        {
            return _rpc.Call("gettransaction", a_txid)["result"] as JObject;
        }

        public JObject GetWork()
        {
            return _rpc.Call("getwork")["result"] as JObject;
        }

        public bool GetWork(string a_data)
        {
            return (bool)_rpc.Call("getwork", a_data)["result"];
        }

        public string Help(string a_command = "")
        {
            return _rpc.Call("help", a_command)["result"].ToString();
        }

        public JObject ListAccounts(int a_minconf = 1)
        {
            return _rpc.Call("listaccounts", a_minconf)["result"] as JObject;
        }

        public JArray ListReceivedByAccount(int a_minconf = 1, bool a_includeEmpty = false)
        {
            return _rpc.Call("listreceivedbyaccount", a_minconf, a_includeEmpty)["result"] as JArray;
        }

        public JArray ListReceivedByAddress(int a_minconf = 1, bool a_includeEmpty = false)
        {
            return _rpc.Call("listreceivedbyaddress", a_minconf, a_includeEmpty)["result"] as JArray;
        }

        public JArray ListTransactions(string a_account, int a_count = 10)
        {
            return _rpc.Call("listtransactions", a_account, a_count)["result"] as JArray;
        }

        public bool Move(
          string a_fromAccount,
          string a_toAccount,
          float a_amount,
          int a_minconf = 1,
          string a_comment = ""
        )
        {
            return (bool)_rpc.Call(
              "move",
              a_fromAccount,
              a_toAccount,
              a_amount,
              a_minconf,
              a_comment
            )["result"];
        }

        public string SendFrom(
          string a_fromAccount,
          string a_toAddress,
          float a_amount,
          int a_minconf = 1,
          string a_comment = "",
          string a_commentTo = ""
        )
        {
            return _rpc.Call(
              "sendfrom",
              a_fromAccount,
              a_toAddress,
              a_amount,
              a_minconf,
              a_comment,
              a_commentTo
            )["result"].ToString();
        }

        public string SendToAddress(string a_address, float a_amount, string a_comment, string a_commentTo)
        {
            return _rpc.Call("sendtoaddress", a_address, a_amount, a_comment, a_commentTo)["result"].ToString();
        }

        public void SetAccount(string a_address, string a_account)
        {
            _rpc.Call("setaccount", a_address, a_account);
        }

        public void SetGenerate(bool a_generate, int a_genproclimit = 1)
        {
            _rpc.Call("setgenerate", a_generate, a_genproclimit);
        }

        public void Stop()
        {
            _rpc.Call("stop");
        }

        public JObject ValidateAddress(string a_address)
        {
            return _rpc.Call("validateaddress", a_address)["result"] as JObject;
        }

        public void SetTXFee(float a_amount)
        {
            _rpc.Call("settxfee", a_amount);
        }
    }
}
