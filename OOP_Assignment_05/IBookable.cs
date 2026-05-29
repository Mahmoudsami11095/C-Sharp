namespace OOP_Assignment_05
{
    internal interface IBookable
    {
        bool IsBoooked { get; }
        void Book();
        void Cancel();
    }
}
