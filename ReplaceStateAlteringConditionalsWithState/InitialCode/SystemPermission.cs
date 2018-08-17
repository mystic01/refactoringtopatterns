namespace ReplaceStateAlteringConditionalsWithState.InitialCode
{
    public class SystemPermission
    {
        private readonly SystemProfile profile;
        private readonly SystemUser requestor;
        private SystemAdmin admin;
        private string state;
        private bool isGranted;
        private bool isUnixPermissionGranted;

        public static readonly string REQUESTED = "REQUESTED";
        public static readonly string CLAIMED = "CLAIMED";
        public static readonly string GRANTED = "GRANTED";
        public static readonly string DENIED = "DENIED";
        public static readonly string UNIX_REQUESTED = "UNIX_REQUESTED";
        public static readonly string UNIX_CLAIMED = "UNIX_CLAIMED";

        public SystemPermission(SystemUser requestor, SystemProfile profile)
        {
            this.requestor = requestor;
            this.profile = profile;
            state = REQUESTED;
            isGranted = false;
            notifyAdminOfPermissionRequest();
        }

        public void claimBy(SystemAdmin admin)
        {
            if (!state.Equals(REQUESTED) && !state.Equals(UNIX_REQUESTED))
                return;
            willBeHandleBy(admin);
            if (state.Equals(REQUESTED))
                state = CLAIMED;
            else if (state.Equals(UNIX_REQUESTED))
                state = UNIX_CLAIMED;
        }

        public void deniedBy(SystemAdmin admin)
        {
            if (!state.Equals(CLAIMED) && !state.Equals(UNIX_CLAIMED))
                return;
            if (!this.admin.Equals(admin))
                return;
            isGranted = false;
            isUnixPermissionGranted = false;
            state = DENIED;
            notifyAdminOfPermissionRequest();
        }

        public void grantBy(SystemAdmin admin)
        {
            if (!state.Equals(CLAIMED) && !state.Equals(UNIX_CLAIMED))
                return;
            if (!this.admin.Equals(admin))
                return;

            if (profile.IsUnixPermissionRequired() && state.Equals(UNIX_CLAIMED))
                isUnixPermissionGranted = true;
            else if (profile.IsUnixPermissionRequired() && !IsUnixPermissionGranted())
            {
                state = UNIX_REQUESTED;
                notifyAdminOfPermissionRequest();
                return;
            }
            state = GRANTED;
            isGranted = true;
            notifyAdminOfPermissionRequest();
        }

        public bool IsUnixPermissionGranted()
        {
            return isUnixPermissionGranted;
        }

        public string State()
        {
            return state;
        }

        public bool IsGranted()
        {
            return isGranted;
        }

        private void willBeHandleBy(SystemAdmin admin)
        {
            this.admin = admin;
        }

        private void notifyAdminOfPermissionRequest()
        {
        }
    }
}