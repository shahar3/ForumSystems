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
        List<SubForum> Lead;
        private int ComplainsNum;
        private int securityLevelInForum;

        public Moderator():base("")
        {

        }
    }
}
