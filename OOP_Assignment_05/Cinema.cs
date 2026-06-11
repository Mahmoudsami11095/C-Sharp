namespace OOP_Assignment_05
{
    internal class Cinema
    {
        public string CinemaName { get; set; }
        private Projector _projector; // Composition
        private int _ticketCount;
        private Ticket[] _tickets = new Ticket[20];

        public Cinema(string cinemaName)
        {
            CinemaName = cinemaName;
            _projector = new Projector();
            _ticketCount = 0;
        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < _tickets.Length; i++)
            {
                if (_tickets[i] == null && t != null && _ticketCount < _tickets.Length)
                {
                    _tickets[i] = t;
                    _ticketCount++;
                    return true;
                }
            }
            Console.WriteLine("Cinema is at full capacity (20 tickets).");
            return false;
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("--- All Tickets ---");
            foreach (Ticket ticket in _tickets)
            {
                if (ticket != null)
                {
                    ticket.Print();
                }
            }
            Console.WriteLine(); // Blank line for spacing
        }
        public void ProcessTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                ticket.Print();
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine("=== Cinema Opened ===");
            _projector.Start();
            Console.WriteLine(); // Blank line for spacing
        }

        public void CloseCinema()
        {
            Console.WriteLine("=== Cinema Closed ===");
            _projector.Stop();
        }
    }
}
