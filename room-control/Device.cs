using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;
using System.Net.NetworkInformation;
using rv;

namespace RoomControl
{
    public enum DeviceType {
        MONITOR,
        PC,
        PROJECTOR
    }

    public abstract class Device : IEquatable<Device> {
        protected const string PASSWORD = "anatomage";

        private string _name;
        public string name {
            get { return _name; }
            set { _name = value; }
        }
        public string Name { get { return _name; } }

        private IPAddress _ip;
        public string ip {
            get { return _ip.ToString(); }
            set {
                try {
                    _ip = IPAddress.Parse(value);
                }
                catch {
                    throw new Exception("Invalid IP Address: " + value);
                }
            }
        }
        public IPAddress IP { get { return _ip; } }

        private PhysicalAddress _mac;
        public string mac {
            get { return _mac.ToString(); }
            set {
                try {
                    _mac = PhysicalAddress.Parse(value);
                }
                catch {
                    throw new Exception("Invalid MAC address: " + value);
                }
            }
        }
        public PhysicalAddress MAC { get { return _mac; } }

        public Device() { }

        protected DeviceType _type;
        public DeviceType Type {
            get {
                return _type;
            }
        }

        public bool Equals(Device other) {
            if (other == null) { return false; }
            return Name.Equals(other.Name);
        }
    }
    

}
