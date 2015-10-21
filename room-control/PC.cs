using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class PC : Device, IPowerControl {

        public const DeviceType TYPE = DeviceType.PC;

        public PC() { }

        PowerCommand.PowerStatus IPowerControl.GetPowerStatus() {
            return PowerCommand.PowerStatus.UNKNOWN;
        }

        void IPowerControl.PowerOff() {
            Wmi.Util.ShutdownHost(IP);
        }

        void IPowerControl.PowerOn() {
            Network.WakeOnLan.WakeUp(MAC);
        }
    }
}
