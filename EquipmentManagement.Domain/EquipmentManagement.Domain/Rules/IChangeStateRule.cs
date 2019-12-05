using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Domain.Rules
{
    public interface IChangeStateRule
    {
        bool IsNotEligibleToDo(UserAccount user, StateType state);
    }
}
