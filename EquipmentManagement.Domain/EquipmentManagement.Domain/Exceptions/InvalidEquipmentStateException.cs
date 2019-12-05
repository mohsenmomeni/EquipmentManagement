using System;

namespace EquipmentManagement.Domain
{
    public class InvalidEquipmentStateException : ApplicationException
    {
        public override string Message => "State is not available for equipment";
    }
}