using System;
using System.Runtime.Serialization;

namespace EquipmentManagement.Domain.Exceptions
{
    public class InvalidUserAccountException : ApplicationException
    {
        public override string Message => "Invalid user account";
    }
}