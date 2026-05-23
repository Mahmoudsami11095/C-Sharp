namespace OOP_Assignment_03.Base.Child
{
    internal class IMAXTicket : TicketClass
    {
        /*
            c. IMAXTicket — adds Is3D (bool). If true, the price increases by 30 EGP. 
            Each child class should override ToString() to include its own extra info.
        */
        public bool Is3D { get; set; }

        public IMAXTicket(string movie, int price, bool is3D) : base(movie, price + (is3D ? 30 : 0))
        {
            Is3D = is3D;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | 3D: {(Is3D ? "Yes" : "No")} | IMAX";
        }
    }
}
