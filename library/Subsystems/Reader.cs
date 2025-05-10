namespace EBookLibrary.Subsystems
{
    public class Reader
    {
        public string OpenBook(string title) => $"Opening book: {title}";
        public string CloseBook(string title) => $"Closing book: {title}";
    }
}