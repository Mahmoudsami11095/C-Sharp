namespace OOP_Assignment_02
{
    internal class CinemaClass
    {
        private TicketClass?[] tickets = new TicketClass?[20];
        public TicketClass? this[int index]
        {
            get
            {
                if (index >= 0 && index < tickets.Length)
                {
                    return tickets[index];
                }
                return null;
            }
            set
            {
                if (index >= 0 && index < tickets.Length)
                {
                    tickets[index] = value;
                }
            }
        }

        public TicketClass? GetMovieByName(string movieName)
        {
            foreach (var ticket in tickets)
            {
                if (ticket != null && ticket.MovieName == movieName)
                {
                    return ticket;
                }
            }
            return null;
        }

        public bool AddTicket(TicketClass t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            return false; // Cinema is full
        }
    }
}
