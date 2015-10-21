using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace RoomControl
{
    public partial class Form1 : Form
    {
        private List<PC> _pcs;
        private List<Monitor> _monitors;
        private List<Projector> _projectors;

        public Form1()
        {
            InitializeComponent();
            LoadDevices();
        }

        private void LoadDevices() {
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));
            StreamReader reader = new StreamReader(@"..\..\room-control.xml");
            DeviceList deviceList = (DeviceList)serializer.Deserialize(reader);
            reader.Close();

            _pcs = deviceList.pcList.pcs;
            foreach(PC pc in _pcs) {
                dgvPC.Rows.Add( new object[] { pc.Name, new Bitmap(Properties.Resources._25_x_25_circle) } );
            }

            _monitors = deviceList.monitorList.monitors;
            foreach (Monitor monitor in _monitors) {
                monitor.InitPJLinkConnection();
                
            }
            _projectors = deviceList.projectorList.projectors;
            foreach (Projector projector in _projectors) {
                projector.InitPJLinkConnection();
            }

        }
    }
}
