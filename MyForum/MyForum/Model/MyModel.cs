using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    public class MyModel : INotifyPropertyChanged
    {
        List<User> users;

        public MyModel()
        {
            Console.WriteLine("ok");
            loadUsers();
        }

        private void loadUsers()
        {
            if (!File.Exists("users.txt"))
            {
                return;
            }
            using (FileStream fs = new FileStream("users.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                    }
                }
            }
        }

        #region event handler
        public event PropertyChangedEventHandler PropertyChanged;
        public void notifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
