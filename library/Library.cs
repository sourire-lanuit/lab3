using EBookLibrary.Subsystems;

namespace EBookLibrary
{
    public class Library
    {
        private readonly BookCatalog _catalog;
        private readonly UserAccount _account;
        private readonly Downloader _downloader;
        private readonly Reader _reader;
        private readonly Notifier _notifier;

        public Library(BookCatalog catalog, UserAccount account, Downloader downloader, Reader reader, Notifier notifier)
        {
            _catalog = catalog;
            _account = account;
            _downloader = downloader;
            _reader = reader;
            _notifier = notifier;
        }

        public List<string> StartReadingSession(string username, string bookTitle)
        {
            return new List<string>
            {
                _account.Login(username),
                _catalog.SearchBook(bookTitle),
                _downloader.Download(bookTitle),
                _reader.OpenBook(bookTitle),
                _notifier.SendNotification($"{username} started reading {bookTitle}")
            };
        }

        public List<string> EndReadingSession(string username, string bookTitle)
        {
            return new List<string>
            {
                _reader.CloseBook(bookTitle),
                _account.Logout(username),
                _notifier.SendNotification($"{username} finished reading {bookTitle}")
            };
        }
    }
}