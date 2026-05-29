namespace OOP_Assignment_05
{
    internal interface IBookable
    {
        bool IsBooked { get; }
        void Book();
        void Cancel();
    }
}
