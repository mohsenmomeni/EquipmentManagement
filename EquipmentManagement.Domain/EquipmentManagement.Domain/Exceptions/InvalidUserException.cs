using System;

namespace EquipmentManagement.Domain.Exceptions
{
    public class InvalidUserAccountException : ApplicationException
    {
        public override string Message => "Invalid user account";
    }
}