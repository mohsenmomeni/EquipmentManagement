namespace EquipmentManagement.Domain
{
    public enum UserType
    {
        Operator,
        Repairman,
        System
    }

    public class UserAccount
    {
        public UserType UserType { get; set; }

        public UserAccount(UserType userType)
        {
            UserType = userType;
        }
    }
}
