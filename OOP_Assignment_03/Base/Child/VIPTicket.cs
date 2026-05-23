namespace OOP_Assignment_03.Base.Child
{
    internal class VIPTicket : TicketClass
    {
        /*  b.VIPTicket — adds LoungeAccess(bool) and ServiceFee(decimal)= 50. 
            Each child class should override ToString() to include its own extra info.
         */
        public bool LoungeAccess;
        public decimal ServiceFee = 50;

        public VIPTicket(string movieName, decimal price, bool loungeAccess) : base(movieName, price)
        {
            LoungeAccess = loungeAccess;
        }

        public override string ToString()
        {
            return base.ToString() + $", Lounge Access: {(LoungeAccess ? "Yes" : "No")}, Service Fee: {ServiceFee:C}";
        }
    }
}
