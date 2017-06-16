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
        Dictionary<string, User> users = new Dictionary<string, User>();

        public MyModel()
        {
            Console.WriteLine("ok");
            loadUsers();

        }

        //load users that are regitred to the forum
        private void loadUsers()
        {
            if (!File.Exists("users.txt"))
            {
                return;
            }
            using (FileStream fs = new FileStream("users.txt", FileMode.Open))
            {
                using (BinaryReader sr = new BinaryReader(fs))
                {
                    while (sr.BaseStream.Position != sr.BaseStream.Length)
                    {
                        string firstName = sr.ReadString();
                        string lastName = sr.ReadString();
                        string email = sr.ReadString();
                        string password = sr.ReadString();
                        string userName = sr.ReadString();
                        bool canDeleteMsg = sr.ReadBoolean();
                        bool canDeleteTopic = sr.ReadBoolean();
                        bool canBanUser = sr.ReadBoolean();
                        User user = new User(firstName, lastName, email, password, userName, canDeleteMsg, canDeleteTopic, canBanUser);
                        users.Add(user.UserName, user);
                    }
                }
            }
        }

        internal void register(string firstName, string lastName, string email, string userName, string password)
        {
            //check if the user already exist in the system
            if (users.ContainsKey(userName))
            {
                MessageBox.Show("There is a user with the same username (" + userName + ")");
                return;
            }
            users[userName] = new User(firstName, lastName, email, password, userName, false, false, false);
            addUserToFile(users[userName]);
        }

        private void addUserToFile(User user)
        {
            using (FileStream fs = new FileStream("users.txt", FileMode.Append))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(user.FirstName);
                    bw.Write(user.LastName);
                    bw.Write(user.Email);
                    bw.Write(user.Password);
                    bw.Write(user.UserName);
                    bw.Write(user.CanDeleteMsg);
                    bw.Write(user.CanDeleteTopic);
                    bw.Write(user.CanBanUser);

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
