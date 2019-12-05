using System;
using System.Runtime.Serialization;

namespace EquipmentManagement.Domain
{
    [Serializable]
    public class InvalidEquipmentStateException : ApplicationException
    {
        public override string Message => "State is not available for equipment";
    }
}