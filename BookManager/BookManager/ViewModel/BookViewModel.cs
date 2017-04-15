using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;

namespace BookManager.ViewModel
{
    public class BookViewModel : INotifyCollectionChanged, INotifyPropertyChanged
    {
        public Book book = new Book();
        
        public event NotifyCollectionChangedEventHandler CollectionChanged; // NotifyCollectionChangedEventHandler had to be implemented due to the implementation of INotifyCollectionChanged, which is necessary for the CollectionChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public BookViewModel()
        {
            book = new Book();
        }

        public BookViewModel(Book book1)
        {
            this.book = book1;
        }

        public string BookTitle
        {
            get { return book.Title; }
            set
            {
                book.Title = value;
                NotifyPropertyChanged(() => BookTitle);
            }

        }

        public string BookAuthor
        {
            get { return book.Author; }
            set
            {
                book.Author = value;
                NotifyPropertyChanged(() => BookAuthor);
            }
        }

        public string BookISBN
        {
            get { return book.ISBN; }
            set
            {
                book.ISBN = value;
                NotifyPropertyChanged(() => BookISBN);
            }
        }

        public string BookPublisher
        {
            get { return book.Publisher; }
            set
            {
                book.Publisher = value;
                NotifyPropertyChanged(() => BookPublisher);
            }
        }

        public int BookDate
        {
            get
            {
                    return book.Date;
            }
            
            set
            {
                book.Date = value;
                NotifyPropertyChanged(() => BookDate);
                NotifyPropertyChanged(() => ColorYear);
            }
        }
        
        public double BookPrice
        {
            get
            {
                return book.Price;
            }
            set
            {
                book.Price = value;
                NotifyPropertyChanged(() => BookPrice);
            }
        }

        
        // Colors the Ellipse in the MainWindow.XAML in Relation to the BookDate-Property.
        public string ColorYear
        {
            get
            {
                int thisYear = DateTime.Now.Year;
                if(book.Date == thisYear || book.Date == thisYear - 1)
                {
                    return "Green";
                }
                else if(book.Date <= thisYear - 2 && book.Date > thisYear - 10)
                {
                    return "Yellow";
                }
                else
                {
                    return "Red";
                }
            }
        }

        /* The NotifyPropertyChanged() - Method allows for a dynamic editing without having to save more complicatedly.
         * The properties can be edited at will in the mainwindow, once selected an item;
         * The NotifyPropertyChanged method will then save the new value, so that another external Edit-Button is not required.
         */

        private void NotifyPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            var expression = body.Expression as ConstantExpression;

            PropertyChangedEventHandler handler = PropertyChanged;
            if( null != handler)
            {
                handler(this, new PropertyChangedEventArgs(body.Member.Name));
            }


        }



    }
}
