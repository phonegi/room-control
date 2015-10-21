using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RoomControl {

    [XmlRoot("DeviceList", Namespace = "", IsNullable = false)]
    public class DeviceList {
        [XmlElement("device")]
        public List<DeviceCreator> devices { get; set; }
    }

    
    
}
