using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace BookManager.ViewModel 
{
   public class BookCollectionViewModel : ObservableCollection<BookViewModel>
    {
        private bool syncDisabled = false;

        private Command.RelayCommand save;
        private Command.RelayCommand load;
        private Command.RelayCommand newBook;
        private Command.DeleteCommand delete;

        private BookWindow newBookWindow;

        public ICommand Save { get { return save; } }
        public ICommand Load { get { return load; } }
        public ICommand New  { get { return newBook; }  }
        public ICommand Delete { get { return delete; } }

        public BookCollectionViewModel()
        {
            save = new Command.RelayCommand(this.SaveFile, this.SyncAllowed);
            load = new Command.RelayCommand(this.LoadFile, this.SyncAllowed);
            newBook = new Command.RelayCommand(this.CreateNewBook, this.SyncAllowed);
            delete = new Command.DeleteCommand(this.DeleteItem);

            CollectionChanged += ViewModelCollectionChanged;
            DAL.Register.Instance.bc.CollectionChanged += ModelCollectionChanged;
            FetchFromModels();
        }


        private void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Return if synchronization is internally disabled
            if(syncDisabled)
            {
                return;
            }

            // disable synchronization
            syncDisabled = true;
            switch(e.Action)
            {
                //Add
                case NotifyCollectionChangedAction.Add:
                    foreach(var bookItems in e.NewItems.OfType<BookViewModel>().Select(v => v.book).OfType<Book>())
                    {
                        DAL.Register.Instance.bc.Add(bookItems);
                    }
                    break;
                //Remove
                case NotifyCollectionChangedAction.Remove:
                    foreach(var bookItems in e.OldItems.OfType<BookViewModel>().Select(v => v.book).OfType<Book>())
                    {
                        DAL.Register.Instance.bc.Remove(bookItems);
                    }
                    break;
                //Reset
                case NotifyCollectionChangedAction.Reset:
                    DAL.Register.Instance.bc.Clear();
                    foreach(BookViewModel bookItems in this)
                    {
                        DAL.Register.Instance.bc.Add(bookItems.book);
                    }
                    break;

            }
            // enable synchronization
            syncDisabled = false;

        }

        private void ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Return if synchronization is internally disabled
            if (syncDisabled)
            {
                return;
            }

            // disable synchronization
            syncDisabled = true;

            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(var bookItems in e.NewItems.OfType<Book>())
                    {
                        Add(new BookViewModel(bookItems));
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach(var bookItems in e.OldItems.OfType<Book>())
                    {
                        this.Remove(BVMInstantiation(bookItems));
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Clear();
                    FetchFromModels();
                    break;
            }

            // enable synchronization
            syncDisabled = false;
        }

        public void FetchFromModels()
        {
            if (syncDisabled)
            {
                return;
            }
            syncDisabled = true;
            Clear();
            for(int i = 0; i < DAL.Register.Instance.bc.Count;i++)
            {
                BookViewModel bvm = new BookViewModel(DAL.Register.Instance.bc.ElementAt(i));
                Add(bvm);
            }
            syncDisabled = false;
        }

        // This method creates a new BookViewModel object along with a new Book Object
        private BookViewModel BVMInstantiation(Book book)
        {
            BookViewModel bvm = new BookViewModel(new Book());
            foreach(BookViewModel bookItem in this)
            {
                if(bookItem.book == book)
                {
                    // References the BookViewModel & Book object to the bookItem.book
                    bvm = bookItem;
                    break;
                }
            }
            return bvm;
        }

        // Functions as When-Operator for the RelayCommand.cs, to prevent Synchronization-Errors.
        private bool SyncAllowed()
        {
            return (!syncDisabled);
        }

        // Uses the "Save" function
        private void SaveFile()
        {
            // Calls upon the Save-Method from Register
            DAL.Register.Instance.SaveObject();
        }

        // Uses the "Load" function
        private void LoadFile()
        {
            // Calls upon the Load-Method from Register
            DAL.Register.Instance.LoadObject();
        }

        private void CreateNewBook()
        {
            // Makes a new instance of the BookWindow.XAML and enables its visibility.
            newBookWindow = new BookWindow();
            newBookWindow.ShowDialog();
        }

        private void DeleteItem(object item)
        {
            // Casts the item-object to a type of BookViewModel, so the CollectionChanged triggers the Remove.Action
            BookViewModel bvmObject = item as BookViewModel;
            if(bvmObject != null)
            {
                for(int i = 0; i < this.Count; i++)
                {
                    if(this[i].Equals(bvmObject))
                    {
                        this.Remove(this[i]);
                    }
                }
            }
        }
                   
    }
}
