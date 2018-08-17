namespace ReplaceStateAlteringConditionalsWithState.MyWork
{
    public class PermissionUnixRequested : PermissionState
    {
        public override void claimBy(SystemAdmin admin, SystemPermission systemPermission)
        {
            systemPermission.willBeHandleBy(admin);
            systemPermission.State = PermissionState.UNIX_CLAIMED;
        }

        public override void grantBy(SystemAdmin admin, SystemPermission systemPermission)
        {
        }

        public override void deniedBy(SystemAdmin admin, SystemPermission systemPermission)
        {
        }
    }
}