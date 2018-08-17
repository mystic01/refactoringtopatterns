using NUnit.Framework;
using ReplaceStateAlteringConditionalsWithState.InitialCode;

namespace RefactoringToPatterns.Tests.ReplaceStateAlteringConditionalsWithState.MyWork
{
    [TestFixture]
    public class TestStates
    {
        [Test]
        public void testGrandBy_NoUnixPermissionRequired_Granted()
        {
            var user = new SystemUser();
            var profile = new SystemProfile(false);
            var permission = new SystemPermission(user, profile);

            var admin = new SystemAdmin();
            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State(), "requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.claimBy(admin);
            Assert.AreEqual(SystemPermission.CLAIMED, permission.State(), "claimed");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.GRANTED, permission.State(), "granted");
            Assert.AreEqual(true, permission.IsGranted(), "granted");
        }

        [Test]
        public void testGrandBy_NoUnixPermissionRequired_Denied()
        {
            var user = new SystemUser();
            var profile = new SystemProfile(false);
            var permission = new SystemPermission(user, profile);

            var admin = new SystemAdmin();
            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State(), "requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.claimBy(admin);
            Assert.AreEqual(SystemPermission.CLAIMED, permission.State(), "claimed");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.deniedBy(admin);
            Assert.AreEqual(SystemPermission.DENIED, permission.State(), "denied");
            Assert.AreEqual(false, permission.IsGranted(), "denied");
        }

        [Test]
        public void testGrandBy_NoUnixPermissionRequired_NoClaimed_Denied()
        {
            var user = new SystemUser();
            var profile = new SystemProfile(false);
            var permission = new SystemPermission(user, profile);

            var admin = new SystemAdmin();
            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State(), "requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.deniedBy(admin);
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State(), "requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");
        }

        [Test]
        public void testGrandBy_UnixPermissionRequired_Granted()
        {
            var user = new SystemUser();
            var profile = new SystemProfile(true);
            var permission = new SystemPermission(user, profile);

            var admin = new SystemAdmin();
            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State(), "requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.claimBy(admin);
            Assert.AreEqual(SystemPermission.CLAIMED, permission.State(), "claimed");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.UNIX_REQUESTED, permission.State(), "Unix requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.claimBy(admin);
            Assert.AreEqual(SystemPermission.UNIX_CLAIMED, permission.State(), "Unix Claimed");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.GRANTED, permission.State(), "granted");
            Assert.AreEqual(true, permission.IsGranted(), "granted");
        }

        [Test]
        public void testGrandBy_UnixPermissionRequired_Denied()
        {
            var user = new SystemUser();
            var profile = new SystemProfile(true);
            var permission = new SystemPermission(user, profile);

            var admin = new SystemAdmin();
            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State(), "requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.claimBy(admin);
            Assert.AreEqual(SystemPermission.CLAIMED, permission.State(), "claimed");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.UNIX_REQUESTED, permission.State(), "Unix requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.claimBy(admin);
            Assert.AreEqual(SystemPermission.UNIX_CLAIMED, permission.State(), "Unix Claimed");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.deniedBy(admin);
            Assert.AreEqual(SystemPermission.DENIED, permission.State(), "denied");
            Assert.AreEqual(false, permission.IsGranted(), "denied");
        }

        [Test]
        public void testGrandBy_UnixPermissionRequired_NoUnixClaim_Denied()
        {
            var user = new SystemUser();
            var profile = new SystemProfile(true);
            var permission = new SystemPermission(user, profile);

            var admin = new SystemAdmin();
            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State(), "requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.claimBy(admin);
            Assert.AreEqual(SystemPermission.CLAIMED, permission.State(), "claimed");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.grantBy(admin);
            Assert.AreEqual(SystemPermission.UNIX_REQUESTED, permission.State(), "Unix requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");

            permission.deniedBy(admin);
            Assert.AreEqual(SystemPermission.UNIX_REQUESTED, permission.State(), "Unix requested");
            Assert.AreEqual(false, permission.IsGranted(), "not granted");
        }
    }
}