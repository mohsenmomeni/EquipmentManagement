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
                return this.States.OrderByDescending(o => o.Id).FirstOrDefault();
            }
        }

        public Equipment()
        {
            this.States = new List<EquipmentState>();
        }

        public void ChangeState(EquipmentState state)
        {
            ValidateState(state);
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
