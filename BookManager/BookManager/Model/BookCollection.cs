using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BookManager.Model
{
    [Serializable]
    class BookCollection : ObservableCollection<Book>, INotifyCollectionChanged
    {
        // BookCollection functions as a temporary database that saves the added new Book-Items in the Listbox
    }
}
