using System;

namespace EquipmentManagement.Domain
{
    public class InvalidStateDateException : ApplicationException
    {
        public override string Message => "State Date is invalid.";
    }
}