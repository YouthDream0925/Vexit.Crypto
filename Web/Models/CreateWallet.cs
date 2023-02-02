namespace Web.Models
{
    public class CreateWallet
    {
        public long Id { get; set; }
        public string walletName { get; set; }
        public string pw { get; set; }
        public string pwConfirmed { get; set; }
    }
}
