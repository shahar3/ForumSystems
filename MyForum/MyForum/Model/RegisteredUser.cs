﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyForum.Model
{
    [Serializable]
    internal class RegisteredUser :User, Observer
    {
        #region fields

        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string userName;
        private List<string> subForumsList;
        private List<string> notificationList;
        List<Message> Publish;
        List<Message> Recive;
        List<Topic> topicsList;
        List<FriendsGroup> belong;
        List<RegisteredUser> FriendedBy;
        List<RegisteredUser> Friend;
        public bool statusActive;


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
        public List<string> NotificationList { get => notificationList; set => notificationList = value; }

        //the default constructor
        public RegisteredUser(string firstName, string lastName, string email, string password, string userName, bool canDeleteMsg, bool canDeleteTopic, bool canBanUser,List<string> notification,List<string> subForumList)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.userName = userName;
            this.CanDeleteMsg = canDeleteMsg;
            this.CanDeleteTopic = canDeleteTopic;
            this.CanBanUser = canBanUser;
            if (notification != null)
            {
                this.notificationList = notification;
            }
            else
            {
                this.notificationList = new List<string>();
            }
            if(subForumList != null)
            {
                this.subForumsList = subForumList;
            }
            else
            {
                this.subForumsList = new List<string>();
            }
        }

        public RegisteredUser(string line)
        {
        }

        public void update(Notification notification)
        {
            //
        }

        public bool havePermission(string subForumNameLbl)
        {
            //if (this.subForumsList != null && subForumsList.Count > 0)
            //{
            //    return this.subForumsList.Contains(subForumNameLbl);
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        /**
        * 
        * @param userId
        * @param userPassword
        */
        public void connectToForum(int userId, int userPassword)
        {
        }

        /**
         * 
         * @param userId
         * @param password
         */
        public void checkUsernameAndPassword(int userId, int password)
        {
        }

        /**
         * 
         * @param userId
         */
        public void changeUserToActive()
        {
            // TODO - implement RegisteredUser.changeUserToActive
        }

        /**
         * 
         * @param userId
         * @param content
         */
        public void sendNewMessage(int userId, int content)
        {
        }

        /**
         * 
         * @param title
         * @param content
         */
        public void notifyMessage(int title, int content)
        {
        }

        /**
         * 
         * @param reportId
         */
        public void DisplayReport(int reportId)
        {
        }
    }
}