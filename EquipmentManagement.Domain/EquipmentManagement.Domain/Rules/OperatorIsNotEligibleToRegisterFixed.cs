namespace EquipmentManagement.Domain.Rules
{
    public class OperatorIsNotEligibleToRegisterFixed : IChangeStateRule
    {
        public bool IsNotEligibleToDo(UserAccount user, StateType state)
        {
            if (user.UserType == UserType.Operator && state == StateType.Fixed)
                return true;
            return false;
        }
    }
}