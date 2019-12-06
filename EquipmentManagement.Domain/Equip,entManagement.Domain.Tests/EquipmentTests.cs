using EquipmentManagement.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

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
        public void Readyness_Of_Equipment_ShouldBeZero_WhenItsStateHasNotChanged()
        {
            var equipment = new Equipment();
            Assert.AreEqual(equipment.Readyness, new TimeSpan(0,0,0,0));
        }

        [TestMethod]
        public void Readyness_Of_Equipment_ShouldNotBeZero_WhenItsStatesContainsFixed()
        {
            var equipment = new Equipment();
            equipment.ChangeState(new EquipmentState(StateType.Fixed, DateTime.Now, new UserAccount(UserType.Repairman)));
            Thread.Sleep(1000);
            Assert.IsTrue(equipment.Readyness.TotalMilliseconds > 500);
        }
    }
}
