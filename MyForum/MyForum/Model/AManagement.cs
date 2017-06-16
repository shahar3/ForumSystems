using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    /// <summary>
    /// This is the common class for moderators and admins
    /// </summary>
    abstract class AManagement : User
    {
        public AManagement(string firstName, string lastName, string email, string password, string userName, bool canDeleteMsg, bool canDeleteTopic, bool canBanUser) : base(firstName, lastName, email, password, userName, canDeleteMsg, canDeleteTopic, canBanUser)
        {

        }
    }
}
