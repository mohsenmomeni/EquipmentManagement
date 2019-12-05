namespace EquipmentManagement.Domain.Rules
{
    public class RepairmanIsNotEligibleToRegisterBroken  : IChangeStateRule
    {
        public bool IsNotEligibleToDo(UserAccount user, StateType state)
        {
            if (user.UserType == UserType.Repairman && state == StateType.Broken)
                return true;
            return false;
        }
    }
}