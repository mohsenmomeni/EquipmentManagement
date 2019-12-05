using System;

namespace EquipmentManagement.Domain
{
    public enum StateType
    {
        Fixed,
        Broken
    }

    public class EquipmentState
    {
        public long Id { get; private set; }
        public StateType TypeOfState { get; private set; }

        public DateTime Date { get; private set; }
        public EquipmentState(StateType stateType, DateTime date)
        {
            this.TypeOfState = stateType;
            if (date == DateTime.MinValue)
                throw new InvalidStateDateException();
            this.Date = date;
        }
    }
}
