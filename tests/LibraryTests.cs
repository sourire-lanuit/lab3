using EBookLibrary;
using EBookLibrary.Subsystems;
using Xunit;
using System.Collections.Generic;

namespace EBookLibraryTests
{
    public class LibraryTests
    {
        [Fact]
        public void TestStartReadingSession()
        {
            var lib = new Library(
                new BookCatalog(), new UserAccount(), new Downloader(), new Reader(), new Notifier()
            );

            var result = lib.StartReadingSession("alice", "1984");

            Assert.Contains("User alice logged in", result);
            Assert.Contains("Searching for book: 1984", result);
            Assert.Contains("Opening book: 1984", result);
        }

        [Fact]
        public void TestEndReadingSession()
        {
            var lib = new Library(
                new BookCatalog(), new UserAccount(), new Downloader(), new Reader(), new Notifier()
            );

            var result = lib.EndReadingSession("alice", "1984");

            Assert.Contains("Closing book: 1984", result);
            Assert.Contains("User alice logged out", result);
        }
    }
}