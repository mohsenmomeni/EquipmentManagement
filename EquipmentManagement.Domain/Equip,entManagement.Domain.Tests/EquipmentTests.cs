using EquipmentManagement.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EquipmentManagement.Domain.Tests
{
    [TestClass]
    public class EquipmentTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccountException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenUserIsNull()
        {
            Equipment eq = new Domain.Equipment();
            eq.ChangeState(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEquipmentStateException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenStateIsNull()
        {
            Equipment eq = new Domain.Equipment();
            UserAccount user = new UserAccount();
            eq.ChangeState(user, null);
        }

        [TestMethod]
        public void ChangeState_Of_Equipment_ShouldChangeEquipmentState_WhenStateIsValid()
        {
            Equipment eq = new Domain.Equipment();
            int stateCounter = eq.States.Count;
            UserAccount user = new UserAccount();
            EquipmentState state = new EquipmentState(StateType.Active);
            eq.ChangeState(user, state);
            Assert.AreEqual(eq.LastState, state);
            Assert.AreEqual(eq.States.Count, stateCounter + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEquipmentStateException))]
        public void ChangeState_Of_Equipment_ShouldThrowException_WhenStateIsTheSameWithPreviousState()
        {
            Equipment eq = new Domain.Equipment();
            var stateType = StateType.Fixed;
            EquipmentState state1 = new EquipmentState(stateType);
            UserAccount user = new UserAccount();
            eq.ChangeState(user, state1);
            EquipmentState state2 = new EquipmentState(stateType);
            eq.ChangeState(user, state2);            
        }
    }
}
