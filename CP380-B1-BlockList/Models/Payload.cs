
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public Payload(string user, TransactionTypes transactionType, int amount, string item)
        {
            User = user;
            transactiontype = transactionType;
            Item = item;
            Amount = amount;
        }

        public string User { get; set; }

        public TransactionTypes transactiontype { get; set; }
        
        public int Amount { get; set; }
        public string Item { get; set; }


    }
}
