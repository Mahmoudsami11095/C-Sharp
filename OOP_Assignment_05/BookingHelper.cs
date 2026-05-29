namespace OOP_Assignment_05
{
    internal static class BookingHelper
    {
        private static int _bookingCounter = 1;

        public static decimal CalcGroupDiscount(int numberOfTickets, decimal pricePerTicket)
        {
            if (numberOfTickets >= 5)
            {
                return numberOfTickets * pricePerTicket * 0.9m;
            }
            else
            {
                return numberOfTickets * pricePerTicket;
            }
        }

        public static string GenerateBookingReference()
        {
            return $"BK-{_bookingCounter++}";
        }

        public static void PrintAll(IPrintable[] printables)
        {
            foreach (IPrintable printable in printables)
            {
                if (printable != null)
                {
                    printable.Print();
                }
            }
        }
    }
}
