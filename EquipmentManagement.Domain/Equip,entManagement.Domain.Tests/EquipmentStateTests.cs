using System;
using EquipmentManagement.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquipmentManagement.Domain.Tests
{
    [TestClass]
    public class EquipmentStateTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccountException))]
        public void Constructor_Of_EquipmentState_ShouldThrowException_WhenUserAccountIsNull()
            => new EquipmentState(StateType.Broken, DateTime.Now, null);

        [TestMethod]
        [ExpectedException(typeof(InvalidStateDateException))]
        public void Constructor_Of_EquipmentState_ShouldThrowException_WhenStateDateIsInvalid()
            => new EquipmentState(StateType.Fixed, DateTime.MinValue, new UserAccount(UserType.Operator));

        [TestMethod]
        [ExpectedException(typeof(UserPermissionException))]
        public void Constructor_Of_EquipmentState_ShouldThrowException_WhenOperatorTryToChangeStateToFixed()
            => new EquipmentState(StateType.Fixed, DateTime.Now, new UserAccount(UserType.Operator));

        [TestMethod]
        [ExpectedException(typeof(UserPermissionException))]
        public void Constructor_Of_EquipmentState_ShouldThrowException_WhenRepairmanTryToChangeStateToBroken()
            => new EquipmentState(StateType.Broken, DateTime.Now, new UserAccount(UserType.Repairman));
    }
}
