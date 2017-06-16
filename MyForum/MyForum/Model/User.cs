﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    abstract class User : Observer
    {
        #region fields
        string firstName;
        string lastName;
        string email;
        string password;
        string userName;
        #endregion

        #region permissions
        bool canDeleteMsg;
        bool canDeleteTopic;
        bool canBanUser;
        #endregion

        //hold a list of notifications

        //encapsulate fields
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }

        //the default constructor
        public User(string firstName, string lastName, string email, string password, string userName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.userName = userName;
        }

        public void update(Notification notification)
        {
            //
        }
    }
}