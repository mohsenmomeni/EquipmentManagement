using System;
namespace EquipmentManagement.Domain.Exceptions
{
    public class UserPermissionException : ApplicationException
    {
        public override string Message => "User has not permitted to register this type of action.";
    }
}
