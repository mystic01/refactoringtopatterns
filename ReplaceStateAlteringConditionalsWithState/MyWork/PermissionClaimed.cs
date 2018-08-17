namespace ReplaceStateAlteringConditionalsWithState.MyWork
{
    public class PermissionClaimed : PermissionState
    {
        public override void claimBy(SystemAdmin admin, SystemPermission systemPermission)
        {
        }

        public override void grantBy(SystemAdmin admin, SystemPermission systemPermission)
        {
            if (!admin.Equals(admin))
                return;

            if (systemPermission.isUnixPermissionRequestedAndClaimed())
                systemPermission.IsUnixPermissionGranted = true;
            else if (systemPermission.isUnixPermissionDesiredButNotRequested())
            {
                systemPermission.State = PermissionState.UNIX_REQUESTED;
                systemPermission.notifyAdminOfPermissionRequest();
                return;
            }

            systemPermission.State = PermissionState.GRANTED;
            systemPermission.IsGranted = true;
            systemPermission.notifyAdminOfPermissionRequest();
        }

        public override void deniedBy(SystemAdmin admin, SystemPermission systemPermission)
        {
            if (!admin.Equals(admin))
                return;
            systemPermission.IsGranted = false;
            systemPermission.IsUnixPermissionGranted = false;
            systemPermission.State = PermissionState.DENIED;
            systemPermission.notifyAdminOfPermissionRequest();
        }
    }
}