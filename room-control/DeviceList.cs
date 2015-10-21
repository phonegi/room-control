using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RoomControl {

    public class MonitorList {
        [XmlElement("monitor")]
        public List<Monitor> monitors { get; set; }
    }

    public class PcList {
        [XmlElement("pc")]
        public List<PC> pcs { get; set; }
    }

    public class ProjectorList {
        [XmlElement("projector")]
        public List<Projector> projectors { get; set; }
    }

    [XmlRoot("devices", Namespace = "", IsNullable = false)]
    public class DeviceList {
        [XmlElement("monitors")]
        public MonitorList monitorList { get; set; }

        [XmlElement("pcs")]
        public PcList pcList { get; set; }

        [XmlElement("projectors")]
        public ProjectorList projectorList { get; set; }

    }


}
