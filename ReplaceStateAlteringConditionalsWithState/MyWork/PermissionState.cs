namespace ReplaceStateAlteringConditionalsWithState.MyWork
{
    public abstract class PermissionState
    {
        public static readonly PermissionState REQUESTED = new PermissionRequested();
        public static readonly PermissionState CLAIMED = new PermissionClaimed();
        public static readonly PermissionState GRANTED = new PermissionGranted();
        public static readonly PermissionState DENIED = new PermissionDenied();
        public static readonly PermissionState UNIX_REQUESTED = new PermissionUnixRequested();
        public static readonly PermissionState UNIX_CLAIMED = new PermissionUnixClaimed();

        public abstract void claimBy(SystemAdmin admin, SystemPermission systemPermission);

        public abstract void grantBy(SystemAdmin admin, SystemPermission systemPermission);

        public abstract void deniedBy(SystemAdmin admin, SystemPermission systemPermission);
    }
}