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
        Forum forum = new Forum();
        private BinaryFormatter formatter = new BinaryFormatter();

        public MyModel()
        {
            loadUsers();
            //test
            loadSubForumDict();
            //endtest
            loadForumsMessages();
        }

        private void loadSubForumDict()
        {
            // Check if we had previously Save information of our friends previously
            if (File.Exists("topics.txt"))
            {
                try
                {
                        string path = "topics";
                        // Create a FileStream will gain read access to the data file.
                        FileStream readerFileStream = new FileStream("topics.txt",
                            FileMode.Open, FileAccess.Read);
                        // Reconstruct information of our friends from file.
                        this.forum.SubForums = (Dictionary<String, SubForum>)
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
            saveSubForums();
            saveUsers();
        }

        //this function save the users dictionary to file
        private void saveUsers()
        {
            using (FileStream fs = new FileStream("users.txt", FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (string user in this.forum.users.Keys)
                    {
                        RegisteredUser userToWrite = this.forum.users[user];
                        bw.Write(userToWrite.FirstName);
                        bw.Write(userToWrite.LastName);
                        bw.Write(userToWrite.Email);
                        bw.Write(userToWrite.Password);
                        bw.Write(userToWrite.UserName);
                        bw.Write(userToWrite.CanDeleteMsg);
                        bw.Write(userToWrite.CanDeleteTopic);
                        bw.Write(userToWrite.CanBanUser);
                        bw.Write(userToWrite.NotificationList.Count.ToString());
                        foreach (string noti in userToWrite.NotificationList)
                        {
                            bw.Write(noti);
                        }
                        bw.Write(userToWrite.SubForumsList.Count.ToString());
                        foreach (string subF in userToWrite.SubForumsList)
                        {
                            bw.Write(subF);
                        }
                    }
                }
            }
        }

        internal void clearNotification(string userName)
        {
            this.forum.users[userName].NotificationList.Clear();
        }

        internal void sendNotification(string subject, string content, string forumName, string userName)
        {
            foreach (string user in this.forum.users.Keys)
            {
                foreach (string subForum in this.forum.users[user].SubForumsList)
                {
                    if (forumName == subForum && user != userName)
                    {
                        string message = userName + " added new topic in " + forumName + " forum";
                        this.forum.users[user].NotificationList.Add(message);
                    }
                }
            }
        }

        //add this forum to sub forum list in the user
        internal void follow(RegisteredUser user, string forumName)
        {
            //add the forum to the sub list of the user
            user.SubForumsList.Add(forumName);
        }

        private void saveSubForums()
        {
                WriteToBinaryFile<Dictionary<string,SubForum>>("topics.txt", this.forum.SubForums, false);
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
            if (this.forum.users.ContainsKey(userName))
            {
                if (this.forum.users[userName].Password == password)
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
                        RegisteredUser user = new RegisteredUser(firstName, lastName, email, password, userName, canDeleteMsg, canDeleteTopic, canBanUser, notification, subForumList);
                        this.forum.users.Add(user.UserName, user);
                    }
                }
            }
        }

        //take the topic for specific forum
        internal List<Topic> getTopics(string forumName)
        {
            if (this.forum.subForums[forumName].topics.Count == 0)
            {
                return new List<Topic>();
            }
            return this.forum.subForums[forumName].topics;
        }

        internal bool register(string firstName, string lastName, string email, string userName, string password)
        {
            //check if the user already exist in the system
            if (this.forum.users.ContainsKey(userName))
            {
                MessageBox.Show("There is a user with the same username (" + userName + ")");
                return false;
            }
            this.forum.users[userName] = new RegisteredUser(firstName, lastName, email, password, userName, false, false, false, null, null);
            addUserToFile(this.forum.users[userName]);
            MessageBox.Show("User was added successfully");
            return true;
        }

        private void addUserToFile(RegisteredUser user)
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

        internal RegisteredUser getUser(string userName)
        {
            return this.forum.users[userName];
        }

        internal void addTopic(Topic topic, string subForumName)
        {
            //topics[subForumName].Add(topic);
            this.forum.subForums[subForumName].topics.Add(topic);
        }
    }
}