using System;
using EquipmentManagement.Domain.Exceptions;

namespace EquipmentManagement.Domain
{
    public class EquipmentState
    {
        public long Order { get; private set; }

        public StateType TypeOfState { get; private set; }

        public DateTime Date { get; private set; }

        public UserAccount Registrar { get; private set; }

        public EquipmentState NextState { get; private set; }

        public EquipmentState(StateType stateType, DateTime date, UserAccount registrar)
        {
            this.TypeOfState = stateType;
            if (date == DateTime.MinValue)
                throw new InvalidStateDateException();
            ValidateRegistrar(registrar, stateType);
            this.Date = date;
        }

        private void ValidateRegistrar(UserAccount user, StateType state)
        {
            if (user == null)
                throw new InvalidUserAccountException();
            ChangeStateRuleApplier ruleApplier = new ChangeStateRuleApplier();
            if (ruleApplier.IsNotEligible(user, state))
            {
                throw new UserPermissionException();
            }
        }

        public void SetOrder(long order)
        {
            this.Order = order;
        }

        public void SetNextState(EquipmentState nextState)
        {
            this.NextState = nextState;
        }
    }
}
