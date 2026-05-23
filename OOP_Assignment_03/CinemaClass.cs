using OOP_Assignment_03.Base;

namespace OOP_Assignment_03
{
    /*
     3. Create a Cinema class that has a CinemaName, a Projector object (created inside Cinema), and holds up to 20 tickets. Add: 
        a. AddTicket(Ticket t) — adds a ticket to the first available slot. 
        b. PrintAllTickets() — prints all tickets. 
        c. OpenCinema() and CloseCinema() — start/stop the projector. 
     */
    internal class CinemaClass
    {
        public string CinemaName { get; set; }
        private ProjectorClass _projector; // Composition
        private int _ticketCount;
        public TicketClass[] _tickets = new TicketClass[20];

        public CinemaClass(string cinemaName)
        {
            CinemaName = cinemaName;
            _projector = new ProjectorClass();
            _ticketCount = 0;
        }

        public bool AddTicket(TicketClass t)
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
            return false; // No available slot
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("========== All Tickets ==========");
            foreach (TicketClass ticket in _tickets)
            {
                if (ticket != null)
                {
                    Console.WriteLine(ticket.ToString());
                }
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine("========== Cinema Opened ==========");
            _projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine("\n========== Cinema Closed ==========");
            _projector.Stop();
        }
    }
}
