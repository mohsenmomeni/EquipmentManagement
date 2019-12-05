using EquipmentManagement.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EquipmentManagement.Domain.Tests
{
    [TestClass]
    public class EquipmentTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidEquipmentStateException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenStateIsNull()
        {
            new Equipment().ChangeState(null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccountException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenStateDoesNotContainsValidUserAccount()
        {
            new Equipment().ChangeState(new EquipmentState(StateType.Broken, DateTime.Now, null));
        }

        [TestMethod]
        public void ChangeState_Of_Equipment_ShouldChangeEquipmentState_WhenStateIsValid()
        {
            Equipment eq = new Equipment();
            int stateCounter = eq.States.Count;
            EquipmentState state = 
                new EquipmentState(StateType.Broken, DateTime.Now, new UserAccount(UserType.Operator));
            eq.ChangeState(state);
            Assert.AreEqual(eq.LastState, state);
            Assert.AreEqual(eq.States.Count, stateCounter + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEquipmentStateException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenStateIsTheSameWithPreviousState()
        {
            var eq = new Equipment();
            eq.ChangeState(new EquipmentState(StateType.Broken, DateTime.Now, new UserAccount(UserType.Operator)));
            eq.ChangeState(new EquipmentState(StateType.Broken, DateTime.Now, new UserAccount(UserType.Operator)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateDateException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenStateDateIsInvalid()
        {
            new Equipment().ChangeState(new EquipmentState(StateType.Fixed, DateTime.MinValue, new UserAccount(UserType.Operator)));
        }

        [TestMethod]
        [ExpectedException(typeof(UserPermissionException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenOperatorTryToChangeStateToFixed()
        {
            new Equipment().ChangeState(
                new EquipmentState(StateType.Fixed, DateTime.Now,
                    new UserAccount(UserType.Operator)));
        }

        [TestMethod]
        [ExpectedException(typeof(UserPermissionException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenRepairmanTryToChangeStateToBroken()
        {
            new Equipment().ChangeState(
                new EquipmentState(StateType.Broken, DateTime.Now,
                    new UserAccount( UserType.Repairman )));
        }
    }
}
