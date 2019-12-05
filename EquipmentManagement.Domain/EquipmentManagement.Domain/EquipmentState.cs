namespace EquipmentManagement.Domain
{
    public enum StateType
    {
        Fixed,
        Active,
        Broken
    }

    public class EquipmentState
    {
        public long Id { get; private set; }
        public StateType TypeOfState { get; private set; }

        public EquipmentState(StateType st)
        {
            this.TypeOfState = st;
        }
    }
}
