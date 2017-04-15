using System.Windows.Input;

namespace BookManager.ViewModel
{
    class CreateNewBookViewModel : BookViewModel
    {
        private bool syncDisabled = false;
        private Command.RelayCommand newBook;
        public ICommand New { get { return newBook;  } }

        public CreateNewBookViewModel()
        {
            newBook = new Command.RelayCommand(SaveNewBook, SyncAllowed);
        }

        public Book Return { get { return book; } }

        private void SaveNewBook()
        {
            // disable synchronization
            syncDisabled = true;

            // Sets the Book Properties from BookViewModel to the values of the entered values from the BookWindow.
            book.Title = BookTitle;
            book.Author = BookAuthor;
            book.ISBN = BookISBN;
            book.Publisher = BookPublisher;
            book.Date = BookDate;
            book.Price = BookPrice;
            
            // adds the new-set properties as item to the BookCollection
            DAL.Register.Instance.bc.Add(book);
            // disable synchronization
            syncDisabled = false;
        }

        private bool SyncAllowed()
        {
            return (!syncDisabled);
        }
    }
}
