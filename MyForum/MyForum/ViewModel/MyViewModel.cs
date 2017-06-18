using MyForum.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.ViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private MyModel model;

        private string str;

        public string Str
        {
            get { return Str; }
            set
            {
                Str = value;
                notifyPropertyChanged(str);
            }
        }

        public MyViewModel(MyModel model)
        {
            this.model = model;
        }

        public bool login(string userName, string password)
        {
            return model.login(userName, password);
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

        internal List<Topic> getTopics(string forumName)
        {
            return model.getTopics(forumName);
        }

        internal bool register(string firstName, string lastName, string email, string userName, string password)
        {
            return model.register(firstName, lastName, email, userName, password);
        }

        internal void sendNotification(object content)
        {
        }

        internal void addTopic(Topic topic, string forumName)
        {
            model.addTopic(topic, forumName);
        }

        #endregion event handler

        internal User GetUser(string userName)
        {
            return model.getUser(userName);
        }
    }
}