using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl {
    class DeviceMonitor : Device, IPowerControl, IPowerStatus, IInputControl, IInputStatus {

        public DeviceMonitor(string name, DeviceType type, IPAddress ip, PhysicalAddress mac) : base(name, type, ip, mac) { }

        InputType IInputStatus.GetInputStatus() {
            throw new NotImplementedException();
        }

        PowerStatus IPowerStatus.GetPowerStatus() {
            throw new NotImplementedException();
        }

        void IPowerControl.PowerOff() {
            throw new NotImplementedException();
        }

        void IPowerControl.PowerOn() {
            throw new NotImplementedException();
        }

        void IInputControl.SetInput(int port) {
            throw new NotImplementedException();
        }
    }
}
