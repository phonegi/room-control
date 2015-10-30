using System;
using System.Net;
using System.Net.NetworkInformation;

namespace RoomControl {

    public enum DeviceType {
        MONITOR,
        PC,
        PROJECTOR
    }

    public abstract class Device : IEquatable<Device> {
        private string _name;
        private IPAddress _ip;
        private PhysicalAddress _mac;
        protected DeviceType _type;

        #region XML Serialization
        public string name {
            get { return _name; }
            set { _name = value; }
        }

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
        #endregion

        #region Class Definition
        public string Name { get { return _name; } }
        public IPAddress IP { get { return _ip; } }
        public PhysicalAddress MAC { get { return _mac; } }
        public DeviceType Type { get { return _type; } }

        public Device() { }
        #endregion

        #region IEquatable Implementation
        public bool Equals(Device other) {
            if (other == null) { return false; }
            return Name.Equals(other.Name);
        }
        #endregion
    }
}
