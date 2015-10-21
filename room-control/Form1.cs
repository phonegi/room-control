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
        public Form1()
        {
            InitializeComponent();

            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));
            StreamReader reader = new StreamReader(@"..\..\room-control.xml");
            DeviceList devices = (DeviceList)serializer.Deserialize(reader);
            reader.Close();
        }
    }
}
