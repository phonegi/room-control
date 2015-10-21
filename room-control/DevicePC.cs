using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl {
    class DevicePC : Device, IPowerControl, IPowerStatus {

        public DevicePC(string name, string type, string ip, string mac) : base(name, type, ip, mac) { }

        PowerStatus IPowerStatus.GetPowerStatus() {
            throw new NotImplementedException();
        }

        void IPowerControl.PowerOff() {
            throw new NotImplementedException();
        }

        void IPowerControl.PowerOn() {
            throw new NotImplementedException();
        }
    }
}
