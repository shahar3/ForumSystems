using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyForum.Model
{
    [Serializable]
    public class MyModel : INotifyPropertyChanged
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, List<Topic>> topics = new Dictionary<string, List<Topic>>();

        private BinaryFormatter formatter = new BinaryFormatter();

        public MyModel()
        {
            topics.Add("politics", new List<Topic>());

            loadUsers();
            //test
            loadTopics();
            //endtest
            loadForumsMessages();
        }

        private void loadTopics()
        {
            // Check if we had previously Save information of our friends previously
            if (File.Exists("topics.txt"))
            {
                try
                {
                    // Create a FileStream will gain read access to the data file.
                    FileStream readerFileStream = new FileStream("topics.txt",
                        FileMode.Open, FileAccess.Read);
                    // Reconstruct information of our friends from file.
                    this.topics = (Dictionary<String, List<Topic>>)
                        this.formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("There seems to be a file that contains " +
                        "friends information but somehow there is a problem " +
                        "with reading it.");
                } // end try-catch
            } // end if
        }

        internal void close()
        {
            saveTopics();
        }

        internal void sendNotification(string forumName, string userName)
        {
            foreach (string user in users.Keys)
            {
                foreach (string subForum in users[user].SubForumsList)
                {
                    if (forumName == subForum && user != userName)
                    {
                        users[user].NotificationList.Add(forumName + " " + userName);
                    }
                }
            }
        }

        //add this forum to sub forum list in the user
        internal void follow(User user, string forumName)
        {
            user.SubForumsList.Add(forumName);
        }

        private void saveTopics()
        {
            WriteToBinaryFile<Dictionary<string, List<Topic>>>("topics.txt", topics, false);
        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        //load the forums messages
        private void loadForumsMessages()
        {
        }

        //This function check if the details for login are correct
        public bool login(string userName, string password)
        {
            if (users.ContainsKey(userName))
            {
                if (users[userName].Password == password)
                {
                    return true;
                }
            }
            return false;
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
                        List<string> notification = new List<string>();
                        int numOfNotification = Int32.Parse(sr.ReadString());
                        for (int i = 0; i < numOfNotification; i++)
                        {
                            notification.Add(sr.ReadString());
                        }
                        List<string> subForumList = new List<string>();
                        int numOfSubForum = Int32.Parse(sr.ReadString());
                        for (int i = 0; i < numOfSubForum; i++)
                        {
                            subForumList.Add(sr.ReadString());
                        }
                        User user = new User(firstName, lastName, email, password, userName, canDeleteMsg, canDeleteTopic, canBanUser, notification, subForumList);
                        users.Add(user.UserName, user);
                    }
                }
            }
        }

        //take the topic for specific forum
        internal List<Topic> getTopics(string forumName)
        {
            if (topics.Count == 0 && !topics.ContainsKey(forumName))
            {
                return new List<Topic>();
            }
            return topics[forumName];
        }

        internal bool register(string firstName, string lastName, string email, string userName, string password)
        {
            //check if the user already exist in the system
            if (users.ContainsKey(userName))
            {
                MessageBox.Show("There is a user with the same username (" + userName + ")");
                return false;
            }
            users[userName] = new User(firstName, lastName, email, password, userName, false, false, false, null, null);
            addUserToFile(users[userName]);
            MessageBox.Show("User was added successfully");
            return true;
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
                    bw.Write(user.NotificationList.Count.ToString());
                    foreach (string noti in user.NotificationList)
                    {
                        bw.Write(noti);
                    }
                    bw.Write(user.SubForumsList.Count.ToString());
                    foreach (string subF in user.SubForumsList)
                    {
                        bw.Write(subF);
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

        #endregion event handler

        internal User getUser(string userName)
        {
            return users[userName];
        }

        internal void addTopic(Topic topic, string subForumName)
        {
            topics[subForumName].Add(topic);
        }
    }
}