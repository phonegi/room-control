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
        MONITOR,
        PROJECTOR
    }

    public class Device {
        private string _name;
        private DeviceType _type;
        private IPAddress _ip;
        private PhysicalAddress _mac;

        public string Name { get { return _name; } }
        public DeviceType Type { get { return _type; } }
        public IPAddress IP { get { return _ip; } }
        public PhysicalAddress MAC { get { return _mac; } }

        public Device(string name, string type, string ip, string mac) {
            _name = name;
            _type = (DeviceType) Enum.Parse(typeof(DeviceType), type, true);
            _ip = IPAddress.Parse(ip);
            _mac = PhysicalAddress.Parse(mac);
        }
    }
    

}
