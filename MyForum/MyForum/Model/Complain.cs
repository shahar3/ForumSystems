using System;

namespace MyForum.Model
{
    [Serializable]
    internal class Complain
    {
        Forum belongManagerIn;
        SubForum belongLeadIn;
        private string content;
        private DateTime date;
        private string sendUserNameID;
        private string receiveUserNameId;

        public Complain()
        {

        }
    }
}