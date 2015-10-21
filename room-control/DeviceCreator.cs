using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl {
    public class DeviceCreator {
        private string _type;
        private string _ip;
        private string _mac;

        public string name { get;  set; }

        public string type {
            get { return _type; }
            set {
                try {
                    Enum.Parse(typeof(DeviceType), value, true);
                }
                catch {
                    throw new Exception("Invalid device type: " + value);
                }
                _type = value;
            }
        }

        public string ip {
            get { return _ip; }
            set {
                try {
                    IPAddress ip = IPAddress.Parse(value);
                }
                catch {
                    throw new Exception("Invalid IP Address: " + value);
                }
                _ip = value;
            }
        }

        public string mac {
            get { return _mac; }
            set {
                try {
                    PhysicalAddress mac = PhysicalAddress.Parse(value);
                }
                catch {
                    throw new Exception("Invalid MAC address: " + value);
                }
                _mac = value;
            }
        }

        public DeviceCreator() { }

        public Device Create() {
            switch (type) {
                case "MONITOR":
                    return new DeviceMonitor(name, type, ip, mac);
                case "PC":
                    return new DevicePC(name, type, ip, mac);
                case "PROJECTOR":
                    return new DeviceProjector(name, type, ip, mac);
            }
            throw new ArgumentException();
        }
    }
}
