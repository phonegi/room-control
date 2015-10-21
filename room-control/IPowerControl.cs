using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    interface IPowerControl {
        void PowerOn();
        void PowerOff();
        PowerCommand.PowerStatus GetPowerStatus();
    }
}
