using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class Moderator : RegisteredUser
    {
        List<SubForum> subForumLead;
        private int ComplainsNum;
        private int securityLevelInForum;

        public Moderator(List<SubForum> lead, string firstName, string lastName, string email, string password, string userName, bool canDeleteMsg, bool canDeleteTopic, bool canBanUser, List<string> notification, List<string> subForumList) :base(firstName,lastName,email,password,userName,true,true,true,notification,subForumList)
        {
            subForumLead = lead;
        }
    }
}
