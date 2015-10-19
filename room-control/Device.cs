using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;
using System.Net.NetworkInformation;

namespace RoomControl
{
    public enum DeviceType {
        PC,
        Monitor,
        Projector
    }

    abstract class Device {
        private string _name;
        private DeviceType _type;
        private IPAddress _ip;
        private PhysicalAddress _mac;

        public string Name { get { return _name; } }
        public DeviceType Type { get { return _type; } }
        public IPAddress IP { get { return _ip; } }
        public PhysicalAddress MAC { get { return _mac; } }

        public Device(string name, DeviceType type, IPAddress ip, PhysicalAddress mac) {
            _name = name;
            _type = type;
            _ip = ip;
            _mac = mac;
        }
    }
    

}
