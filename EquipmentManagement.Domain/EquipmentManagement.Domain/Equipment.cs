using EquipmentManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentManagement.Domain
{
    public class Equipment
    {       
        public List<EquipmentState> States { get; private set; }

        public EquipmentState LastState
        {
            get
            {
                return this.States.OrderByDescending(o => o.Order).FirstOrDefault();
            }
        }

        public TimeSpan Readyness => CalculateReadyness();

        private TimeSpan CalculateReadyness()
        {
            TimeSpan timeSpan = new TimeSpan(0,0,0,0);
            if (this.States.All(o => o.TypeOfState != StateType.Fixed))
                return timeSpan;
            foreach (var equipmentState in States)
            {
                if (equipmentState.TypeOfState == StateType.Fixed)
                {
                    
                }
            }
            return DateTime.Now.Subtract(LastState.Date);
        }

        public Equipment()
        {
            var initialState = new EquipmentState(StateType.Initial, DateTime.Now, new UserAccount(UserType.System));
            initialState.SetOrder(1);
            this.States = new List<EquipmentState>
            {
                initialState
            };
        }

        public void ChangeState(EquipmentState state)
        {
            ValidateState(state);
            state.SetOrder(this.LastState.Order + 1);
            this.States.Add(state);
        }

        private void ValidateState(EquipmentState state)
        {
            if (state == null)
                throw new InvalidEquipmentStateException();
            if (LastState?.TypeOfState == state.TypeOfState)
                throw new InvalidEquipmentStateException();
        }
    }
}
