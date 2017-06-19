using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class Forum
    {
        public Dictionary<string,SubForum> subForums = new Dictionary<string, SubForum >();
        public PolicyRules behavaAccording;
        public List<FriendsGroup> friendGroup;
        public Dictionary<string,RegisteredUser> users;
        public List<Admin> ManagedBy;
        public List<Complain> compOnManager;
        private string nameF;
        private int password;
        private List<RegisteredUser> banUserList;

        public Dictionary<string, SubForum> SubForums { get => subForums; set => subForums = value; }
        internal PolicyRules BehavaAccording { get => behavaAccording; set => behavaAccording = value; }
        public List<FriendsGroup> FriendGroup { get => friendGroup; set => friendGroup = value; }
        internal Dictionary<string, RegisteredUser> Users { get => users; set => users = value; }
        internal List<Admin> ManagedBy1 { get => ManagedBy; set => ManagedBy = value; }
        public List<Complain> CompOnManager { get => compOnManager; set => compOnManager = value; }
        public string NameF { get => nameF; set => nameF = value; }
        public int Password { get => password; set => password = value; }
        internal List<RegisteredUser> BanUserList { get => banUserList; set => banUserList = value; }

        public Forum()
        {
            initSubForums();
            behavaAccording = new PolicyRules();
            friendGroup = new List<FriendsGroup>();
            users = new Dictionary<string, RegisteredUser>();
            ManagedBy = new List<Admin>();
            compOnManager = new List<Complain>();
            banUserList = new List<RegisteredUser>();

        }

        private void initSubForums()
        {
            SubForum politicsForum = new SubForum("politics");
            SubForums["politics"] = politicsForum;
            SubForum economicsForum = new SubForum("economics");
            SubForums["economics"] = economicsForum;
            SubForum sportForum = new SubForum("sport");
            SubForums["sport"] = sportForum;
            SubForum programmingForum = new SubForum("programming");
            SubForums["programming"] = programmingForum;
            SubForum generalForum = new SubForum("general");
            SubForums["general"] = generalForum;
        }

        public void postMessage(int content)
        {
            
        }

        /**
         * 
         * @param userId
         */
        public void checkUserRegistertion(int userId)
        {
        }

        /**
         * 
         * @param forumId
         * @param title
         * @param user
         * @param content
         */
        public void submitTopic(int forumId, int title, int user, int content)
        {
            //
        }

        /**
         * 
         * @param ForumId
         * @param ManagedId
         */
        public void checkifMangedForum(int ForumId, int ManagedId)
        {
        }

        /**
         * 
         * @param UserId
         */
        public void AddUserToBanList(int UserId)
        {
        }

        public void BanUser()
        {
        }

        /**
         * 
         * @param UserId
         * @param ForumId
         * @param GroupName
         * @param UserList
         */
        public void sendNewRequest(int UserId, int ForumId, int GroupName, int UserList)
        {
        }

        /**
         * 
         * @param ForumId
         * @param UserId
         * @param UserList
         */
        public void ValidateTheRequest(int ForumId, int UserId, int UserList)
        {
        }

        /**
         * 
         * @param RequestId
         */
        public void createRequest(int RequestId)
        {
        }

        /**
         * 
         * @param ReqId
         */
        public void AnalyzeGroupRequest(int ReqId)
        {
        }

        /**
         * 
         * @param Qurey
         */
        public void GetMessageList(int Qurey)
        {
        }

        /**
         * 
         * @param UserId
         * @param SearchQuery
         */
        public void GetDitelMessage(int UserId, int SearchQuery)
        {
        }

        /**
         * 
         * @param RequistId
         * @param LeaderId
         */
        public void addRequest(int RequistId, int LeaderId)
        {
        }

        /**
         * 
         * @param ModeratorId
         */
        public void NominateModerator(int ModeratorId)
        {
        }

        /**
         * 
         * @param ModeratorId
         * @param ForumId
         */
        public void GetReport(int ModeratorId, int ForumId)
        {
        }

        public void GenreateReport()
        {
        }

    }

}
