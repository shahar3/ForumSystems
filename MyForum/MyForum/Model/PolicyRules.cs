using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class PolicyRules
    {
        List<Forum> BelongTo;
        private string replaceManager;
        private string replaceLeader;
        private string complainHandle;
        private string ligalActionsForUser;
        private string SuspendUser;
        private string memberRecog;
        private string confidentialityOfInformation;
        private string conditionsToManagerAppointment;
        private string conditionsToLeaderAppointment;

        public string ReplaceManager { get => replaceManager; set => replaceManager = value; }
        public string ReplaceLeader { get => replaceLeader; set => replaceLeader = value; }
        public string ComplainHandle { get => complainHandle; set => complainHandle = value; }
        public string LigalActionsForUser { get => ligalActionsForUser; set => ligalActionsForUser = value; }
        public string SuspendUser1 { get => SuspendUser; set => SuspendUser = value; }
        public string MemberRecog { get => memberRecog; set => memberRecog = value; }
        public string ConfidentialityOfInformation { get => confidentialityOfInformation; set => confidentialityOfInformation = value; }
        public string ConditionsToManagerAppointment { get => conditionsToManagerAppointment; set => conditionsToManagerAppointment = value; }
        public string ConditionsToLeaderAppointment { get => conditionsToLeaderAppointment; set => conditionsToLeaderAppointment = value; }
        internal List<Forum> BelongTo1 { get => BelongTo; set => BelongTo = value; }

        public PolicyRules()
        {

        }

        public PolicyRules(
            List<Forum> BelongTo,
            string replaceManager,
            string replaceLeader,
            string complainHandle,
            string ligalActionsForUser,
            string SuspendUser,
            string memberRecog,
            string confidentialityOfInformation,
            string conditionsToManagerAppointment,
            string conditionsToLeaderAppointment
            )
        {
            this.BelongTo = BelongTo;
            this.replaceManager = replaceManager;
            this.replaceLeader = replaceLeader;
            this.complainHandle = complainHandle;
            this.ligalActionsForUser = ligalActionsForUser;
            this.SuspendUser = SuspendUser;
            this.memberRecog = memberRecog;
            this.confidentialityOfInformation = confidentialityOfInformation;
            this.conditionsToManagerAppointment = conditionsToManagerAppointment;
            this.conditionsToLeaderAppointment = conditionsToLeaderAppointment;
        }
    }
}
