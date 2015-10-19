using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl {
    class DeviceCreator {
        public string Name { get; set; }
        public DeviceType Type { get; set; }
        public IPAddress IP { get; set; }
        public PhysicalAddress MAC { get; set; }

        public DeviceCreator() { }

        public Device Create() {
            switch (Type) {
                case DeviceType.Monitor:
                    return new DeviceMonitor(Name, Type, IP, MAC);
                case DeviceType.PC:
                    return new DevicePC(Name, Type, IP, MAC);
                case DeviceType.Projector:
                    return new DeviceProjector(Name, Type, IP, MAC);
            }
            throw new ArgumentException();
        }
    }
}
