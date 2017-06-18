﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyForum.Model
{
    [Serializable]
    internal class User : Observer
    {
        #region fields

        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string userName;
        private List<string> subForumsList;

        #endregion fields

        #region permissions

        private bool canDeleteMsg;
        private bool canDeleteTopic;
        private bool canBanUser;

        #endregion permissions

        //hold a list of notifications

        //encapsulate fields
        public string FirstName { get => firstName; set => firstName = value; }

        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }
        public bool CanDeleteMsg { get => canDeleteMsg; set => canDeleteMsg = value; }
        public bool CanDeleteTopic { get => canDeleteTopic; set => canDeleteTopic = value; }
        public bool CanBanUser { get => canBanUser; set => canBanUser = value; }
        public List<string> SubForumsList { get => subForumsList; set => subForumsList = value; }

        //the default constructor
        public User(string firstName, string lastName, string email, string password, string userName, bool canDeleteMsg, bool canDeleteTopic, bool canBanUser)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.userName = userName;
            this.CanDeleteMsg = canDeleteMsg;
            this.CanDeleteTopic = canDeleteTopic;
            this.CanBanUser = canBanUser;
        }

        public User(string line)
        {
        }

        public void update(Notification notification)
        {
            //
        }

        public bool havePermission(object subForumNameLbl)
        {
            return this.subForumsList.Contains(subForumNameLbl);
        }
    }
}