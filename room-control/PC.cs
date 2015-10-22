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

        public const DeviceType Type = DeviceType.PC;

        private PowerCommand.PowerStatus _powerStatus = PowerCommand.PowerStatus.UNKNOWN;

        public PC() { }

        public PowerCommand.PowerStatus GetPowerStatus() {
            return _powerStatus;
        }

        public void PowerOff() {
            _powerStatus = Wmi.Util.ShutdownHost(IP) == Wmi.Util.ShutdownResult.SUCCESS ? PowerCommand.PowerStatus.OFF : PowerCommand.PowerStatus.UNKNOWN;
        }

        public void PowerOn() {
            _powerStatus = Network.WakeOnLan.WakeUp(MAC) ? PowerCommand.PowerStatus.ON : PowerCommand.PowerStatus.UNKNOWN;
        }
    }
}
