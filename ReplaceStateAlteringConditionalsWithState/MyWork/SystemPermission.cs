namespace ReplaceStateAlteringConditionalsWithState.MyWork
{
    public class SystemPermission
    {
        private readonly SystemProfile profile;
        private readonly SystemUser requestor;
        private SystemAdmin admin;
        private PermissionState state;
        private bool isGranted;
        private bool isUnixPermissionGranted;

        public SystemPermission(SystemUser requestor, SystemProfile profile)
        {
            this.requestor = requestor;
            this.profile = profile;
            state = PermissionState.REQUESTED;
            isGranted = false;
            notifyAdminOfPermissionRequest();
        }

        public PermissionState State
        {
            set { state = value; }
            get { return state; }
        }

        public bool IsGranted
        {
            set { isGranted = value; }
            get { return isGranted; }
        }

        public bool IsUnixPermissionGranted
        {
            set { isUnixPermissionGranted = value; }
            get { return isUnixPermissionGranted; }
        }

        public void claimBy(SystemAdmin admin)
        {
            state.claimBy(admin, this);
        }

        public void deniedBy(SystemAdmin admin)
        {
            State.deniedBy(admin, this);
        }

        public void grantBy(SystemAdmin admin)
        {
            State.grantBy(admin, this);
        }

        public bool isUnixPermissionDesiredButNotRequested()
        {
            return profile.IsUnixPermissionRequired() && !IsUnixPermissionGranted;
        }

        public bool isUnixPermissionRequestedAndClaimed()
        {
            return profile.IsUnixPermissionRequired() && state.Equals(PermissionState.UNIX_CLAIMED);
        }

        public void willBeHandleBy(SystemAdmin admin)
        {
            this.admin = admin;
        }

        public void notifyAdminOfPermissionRequest()
        {
        }
    }
}