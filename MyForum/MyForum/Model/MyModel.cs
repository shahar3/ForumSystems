using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyForum.Model
{
    public class MyModel : INotifyPropertyChanged
    {
        Dictionary<string,User> users = new Dictionary<string, User>();

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

        internal void register(string firstName, string lastName, string email, string userName, string password)
        {
            //check if the user already exist in the system
            if (users.ContainsKey(userName))
            {
                MessageBox.Show("There is a user with the same username (" +userName+")");
                return;
            }
            users[userName] = new User(firstName, lastName, email, password, userName);
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
