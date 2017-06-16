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
