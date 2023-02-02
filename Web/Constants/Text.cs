namespace Web.Constants
{
    public class Text
    {
        public const string walletFilePath = @"Wallets\";
        public static class Tokens
        {
            public const string Mnemonic = "{{mnemonic}}";
        }

        public const string BTCAddress = "Address: ";
        public const string PrivateKey = "Priavate key: ";
        public const string pwConfirmefail = "Passwords did not match! Try again.";
        public const string walletExist = "Wallet already exists.";
        public const string walletImportSuccess = "Wallet successfuly imported.";
        public const string ExceptionOccured = "Unexpected error occured.";
        public const string MnemonicNotification = $@"Wallet created successfully.
        Write down the following mnemonic words.
        With the mnemonic words AND the password you can recover this wallet.
        ---------------------------------------------------------------------
        {Tokens.Mnemonic}
        ---------------------------------------------------------------------
        Write down and keep in SECURE place your private keys. Only through them you can access your coins!";

        public static string GetMnemonicMessage(string mnemonic)
        {
            return MnemonicNotification.Replace(Tokens.Mnemonic, mnemonic);
        }
    }
}