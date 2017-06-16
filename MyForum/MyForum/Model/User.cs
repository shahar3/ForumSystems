using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class User : Observer
    {
        #region fields
        string firstName;
        string lastName;
        string email;
        string password;
        string userName;
        #endregion

        #region permissions
        public bool canDeleteMsg;
        public bool canDeleteTopic;
        public bool canBanUser;
        #endregion

        //hold a list of notifications


        //encapsulate fields
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }

        //the default constructor
        public User(string firstName, string lastName, string email, string password, string userName,bool canDeleteMsg,bool canDeleteTopic,bool canBanUser)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email; 
            this.password = password;
            this.userName = userName;
            this.canDeleteMsg = canDeleteMsg;
            this.canDeleteTopic = canDeleteTopic;
            this.canBanUser = canBanUser;
        }

        public User(string line)
        {
        }

        public void update(Notification notification)
        {
            //
        }
    }
}
