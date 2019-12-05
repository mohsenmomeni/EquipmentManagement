using System.Collections.Generic;
using EquipmentManagement.Domain.Rules;

namespace EquipmentManagement.Domain
{
    internal class ChangeStateRuleApplier
    {
        public List<IChangeStateRule> Rules { get; private set; }

        public ChangeStateRuleApplier()
        {
            Rules = new List<IChangeStateRule>
            {
                new OperatorIsNotEligibleToRegisterFixed(),
                new RepairmanIsNotEligibleToRegisterBroken()
            };
        }

        public bool IsNotEligible(UserAccount user, StateType state)
        {
            foreach (var changeStateRule in Rules)
            {
                if (changeStateRule.IsNotEligibleToDo(user, state))
                    return true;
            }
            return false;
        }
    }
}