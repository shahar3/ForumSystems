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
            loadUsers();
            //test
            saveTopics();
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

        private void saveTopics()
        {
            User user1 = new User("daniel", "verman", "daniverman@gmail.com", "123456", "daniel Verman", true, true,
                true);
            Topic t1 = new Topic("subject1", "content1", user1);
            Topic t3 = new Topic("subject11", "content11", user1);
            List<Topic> politicsTopics = new List<Topic>();
            politicsTopics.Add(t1);
            politicsTopics.Add(t3);
            User user2 = new User("hhhhhhhhhhhhhh");
            Topic t2 = new Topic("subject2", "content2", user1);
            List<Topic> sportTopics = new List<Topic>();
            sportTopics.Add(t2);
            topics.Add("politics", politicsTopics);
            topics.Add("sport", sportTopics);
            //save the dictionary
            // Create a FileStream that will write data to file.
            WriteToBinaryFile<Dictionary<string, List<Topic>>>("topics.txt", topics, false);
            topics.Clear();
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
                        User user = new User(firstName, lastName, email, password, userName, canDeleteMsg, canDeleteTopic, canBanUser);
                        users.Add(user.UserName, user);
                    }
                }
            }
        }

        //take the topic for specific forum
        internal List<Topic> getTopics(string forumName)
        {
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
            users[userName] = new User(firstName, lastName, email, password, userName, false, false, false);
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
        }
    }
}