using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RoomControl {

    [XmlRoot(Namespace = "", IsNullable = false)]
    class DeviceLoader {
        [XmlElement("device")]
        public List<Device> devices { get; set; }
    }
    
}
