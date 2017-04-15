using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookManager.DAL
{
    [Serializable]
    class Register
    {
        private static Register instance;
        public Model.BookCollection bc { get; set; }

        private Register()
        {
            bc = new Model.BookCollection();
        }

        // Calls upon the 'Save' function in the BookManager - Saves the listbox-items as file in the project-path (usually bookmanager\bin)
        public void SaveObject()
        {
            // to use as Save As...
            Register bcvm = new DAL.Register();
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Standard_File_Name";
            dlg.DefaultExt = ".cust"; // Custom File Type
            dlg.Filter = "Text Documents (.cust)|*.cust"; //Filter Files by Extension

            // Show Dialog
            Nullable<bool> result = dlg.ShowDialog();

            if(result == true)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, bc);
                fs.Close(); 
            }
        }


        // Calls upon the "Load" function in the Bookmanager - Loads the listbox-items and adds them to the project from the saved file.
        public void LoadObject()
        {
            Register bcvm = new DAL.Register();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Standard_File_Name";
            dlg.DefaultExt = ".cust"; // Custom File Type
            dlg.Filter = "Text Documents (.cust)|*.cust"; //Filter Files by Extension

            Nullable<bool> result = dlg.ShowDialog();

            if(result == true)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Instance.bc.Clear();
                foreach (Book m in (Model.BookCollection)bf.Deserialize(fs))
                {
                    Instance.bc.Add(m);
                }
                fs.Close();
            }


        }

        public static Register Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Register();
                }
                return instance;
            }

        }
    }
}
