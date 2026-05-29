namespace OOP_Assignment_05.Child
{
    internal class IMAXTicket : Ticket
    {
        public bool Is3D { get; set; }

        public override decimal Price
        {
            get => base.Price + (Is3D ? 30m : 0m);
            set => base.Price = value;
        }

        public IMAXTicket(string movieName, decimal price, bool is3D) : base(movieName, price)
        {
            Is3D = is3D;
        }

        public override void PrintTicket()
        {
            Console.WriteLine(base.ToString());
            Console.WriteLine($"  IMAX 3D: {(Is3D ? "Yes" : "No")}");
        }
    }
}
