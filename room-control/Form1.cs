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
using rv;

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
                dgvPC.Rows.Add( new object[] { pc.Name, GetPowerStatusImage(pc) } );
            }

            _monitors = deviceList.monitorList.monitors;
            foreach (Monitor monitor in _monitors) {
                monitor.InitPJLinkConnection();
                dgvMonitor.Rows.Add(new object[] { monitor.Name, GetPowerStatusImage(monitor), GetInputStatusImage(monitor) });
            }
            _projectors = deviceList.projectorList.projectors;
            foreach (Projector projector in _projectors) {
                projector.InitPJLinkConnection();
                dgvProjector.Rows.Add(new object[] { projector.Name, GetPowerStatusImage(projector), GetInputStatusImage(projector) });
            }
        }

        private Bitmap GetPowerStatusImage(IPowerControl device) {
            switch (device.GetPowerStatus()) {
                case PowerCommand.PowerStatus.ON:
                    return Properties.Resources.dot_green_22x22;
                case PowerCommand.PowerStatus.OFF:
                    return Properties.Resources.dot_red_22x22;
                case PowerCommand.PowerStatus.COOLING:
                    return Properties.Resources.cool_22x22;
                case PowerCommand.PowerStatus.WARMUP:
                    return Properties.Resources.warm_22x22;
            }
            return Properties.Resources.question_mark_22x22;
        }


        private Bitmap GetInputStatusImage(IInputControl device) {
            InputCommand.InputType type;
            int port;
            device.GetInputStatus(out type, out port);
            if (type == InputCommand.InputType.DIGITAL) {
                switch (port) {
                    case 1:
                        return Properties.Resources.antenna_22x22;
                    case 2:
                        return Properties.Resources.laptop_22x22;
                }
            }
            return Properties.Resources.question_mark_22x22;
        }

        private void cmdPcOn_Click(object sender, EventArgs e) {
            if (dgvPC.SelectedRows.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all PCs?", "Power ON", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    foreach(PC pc in _pcs) {
                        pc.PowerOn();
                    }
                }
            }
            else {
                PC pc;
                foreach (DataGridViewRow row in dgvPC.SelectedRows) {
                    pc = _pcs.Find(x => x.Name.Equals(row.Cells["Name"].ToString()));
                    pc.PowerOn();
                }
            }
        }

        private void cmdPcOff_Click(object sender, EventArgs e) {
            if (dgvPC.SelectedRows.Count == 0) {

                DialogResult result = MessageBox.Show("Are you sure you want to turn off ALL PCs?", "Power OFF", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                result = MessageBox.Show("Click OK to turn off ALL PCs", "Confirm", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK) { return; }

                foreach (PC pc in _pcs) {
                    pc.PowerOff();
                }

            }
            else {
                PC pc;
                foreach (DataGridViewRow row in dgvPC.SelectedRows) {
                    pc = _pcs.Find(x => x.Name.Equals(row.Cells["Name"].ToString()));
                    pc.PowerOff();
                }
            }
        }

        private void cmdMonitorOn_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedRows.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all monitors?", "Power ON", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.PowerOn();
                }
            }
            else {
                Monitor monitor;
                foreach (DataGridViewRow row in dgvMonitor.SelectedRows) {
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells["Name"]));
                    monitor.PowerOn();
                }
            }
        }

        private void cmdMonitorOff_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedRows.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn off all monitors?", "Power OFF", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.PowerOff();
                }
            }
            else {
                Monitor monitor;
                foreach (DataGridViewRow row in dgvMonitor.SelectedRows) {
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells["Name"]));
                    monitor.PowerOff();
                }
            }
        }

        private void cmdMonitorInputBroadcast_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedRows.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to switch the input to the broadcast signal for all monitors?", 
                                                      "Set input to broadcast", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_BROADCAST);
                }
            }
            else {
                Monitor monitor;
                foreach(DataGridViewRow row in dgvMonitor.SelectedRows) {
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells["Name"]));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_BROADCAST);
                }
            }
        }

        private void cmdMonitorInputPc_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedRows.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to switch the input to the local PC for all monitors?",
                                                      "Set input to broadcast", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_PC);
                }
            }
            else {
                Monitor monitor;
                foreach (DataGridViewRow row in dgvMonitor.SelectedRows) {
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells["Name"]));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_PC);
                }
            }
        }
    }
}
