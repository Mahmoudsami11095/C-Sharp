namespace OOP_Assignment_02
{
    internal class BookingHelperClass
    {
        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            if (numberOfTickets >= 5)
            {
                return numberOfTickets * pricePerTicket * 0.9;
            }
            else
            {
                return numberOfTickets * pricePerTicket;
            }
        }

        private static int BookingCounter = 1;

        public static string GenerateBookingReference()
        {
            return $"BK-{BookingCounter++}";
        }
    }
}
