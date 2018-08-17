namespace ReplaceStateAlteringConditionalsWithState.InitialCode
{
    public class SystemProfile
    {
        private bool isUnixPermissionRequired;

        public SystemProfile(bool isUnixPermissionRequired)
        {
            this.isUnixPermissionRequired = isUnixPermissionRequired;
        }

        public bool IsUnixPermissionRequired()
        {
            return isUnixPermissionRequired;
        }
    }
}