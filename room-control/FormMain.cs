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
    public partial class FormMain : Form
    {
        private List<PC> _pcs;
        private List<Monitor> _monitors;
        private List<Projector> _projectors;
        public delegate void UpdatePowerStatusImage_Delegate(Device device, PowerCommand.PowerStatus status);
        public delegate void UpdateInputStatusImage_Delegate(Device device, InputCommand.InputType inputType, int port);

        public FormMain()
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
                dgvPC.Rows.Add( new object[] { pc.Name, PowerCommand.PowerStatus.UNKNOWN } );
            }

            _monitors = deviceList.monitorList.monitors;
            foreach (Monitor monitor in _monitors) {
                monitor.InitPJLinkConnection();
                dgvMonitor.Rows.Add(new object[] { monitor.Name, PowerCommand.PowerStatus.UNKNOWN, InputCommand.InputType.UNKNOWN });
            }

            _projectors = deviceList.projectorList.projectors;
            foreach (Projector projector in _projectors) {
                projector.InitPJLinkConnection();
                dgvProjector.Rows.Add(new object[] { projector.Name, PowerCommand.PowerStatus.UNKNOWN, InputCommand.InputType.UNKNOWN });
            }
        }

        private Bitmap GetPowerStatusImage(PowerCommand.PowerStatus status) {
            switch (status) {
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

        private void UpdatePowerStatusImage(Device device, PowerCommand.PowerStatus status) {
            Bitmap image = GetPowerStatusImage(status);
            DataGridViewRow row = GetDataGridViewRow(device.Type, device.Name);
            if (row == null) { return; }
            row.Cells[1].Value = image;
        }


        private void UpdateInputStatusImage(Device device, InputCommand.InputType type, int port) {
            Bitmap image = GetInputStatusImage(type, port);
            DataGridViewRow row = GetDataGridViewRow(device.Type, device.Name);
            if (row == null) { return; }
            row.Cells[2].Value = image;
        }

        private Bitmap GetInputStatusImage(InputCommand.InputType type, int port) {
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

        private DataGridViewRow GetDataGridViewRow(DeviceType deviceType, string name) {
            DataGridView dgv;
            switch (deviceType) {
                case DeviceType.MONITOR:
                    dgv = dgvMonitor;
                    break;
                case DeviceType.PC:
                    dgv = dgvPC;
                    break;
                case DeviceType.PROJECTOR:
                    dgv = dgvProjector;
                    break;
                default:
                    dgv = new DataGridView();
                    break;
            }
            foreach (DataGridViewRow row in dgv.Rows) {
                if (row.Cells[0].Value.Equals(name)) {
                    return row;
                }
            }
            return null;
        }

        private void cmdPcOn_Click(object sender, EventArgs e) {
            if (dgvPC.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all PCs?", "Power ON", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    foreach(PC pc in _pcs) {
                        pc.PowerOn();
                    }
                }
            }
            else {
                PC pc;
                foreach (DataGridViewCell cell in dgvPC.SelectedCells) {
                    pc = _pcs.Find(x => x.Name.Equals(cell.Value.ToString()));
                    pc.PowerOn();
                }
            }
        }

        private void cmdPcOff_Click(object sender, EventArgs e) {
            if (dgvPC.SelectedCells.Count == 0) {

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
                foreach (DataGridViewCell cell in dgvPC.SelectedCells) {
                    pc = _pcs.Find(x => x.Name.Equals(cell.Value.ToString()));
                    pc.PowerOff();
                }
            }
        }

        private void cmdMonitorOn_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all monitors?", "Power ON", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.PowerOn();
                }
            }
            else {
                Monitor monitor;
                foreach (DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.PowerOn();
                }
            }
        }

        private void cmdMonitorOff_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn off all monitors?", "Power OFF", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.PowerOff();
                }
            }
            else {
                Monitor monitor;
                foreach (DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.PowerOff();
                }
            }
        }

        private void cmdMonitorInputBroadcast_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to switch the input to the broadcast signal for all monitors?", 
                                                      "Set input to broadcast", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_BROADCAST);
                }
            }
            else {
                Monitor monitor;
                foreach(DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_BROADCAST);
                }
            }
        }

        private void cmdMonitorInputPc_Click(object sender, EventArgs e) {
            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to switch the input to the local PC for all monitors?",
                                                      "Set input to broadcast", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Monitor monitor in _monitors) {
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_PC);
                }
            }
            else {
                Monitor monitor;
                foreach (DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_PC);
                }
            }
        }

        private void cmdProjectorOn_Click(object sender, EventArgs e) {
            if (dgvProjector.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all projectors?",
                                                      "Turn on projectors", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Projector projector in _projectors) {
                    projector.PowerOn();
                }
            }
            else {
                Projector projector;
                foreach (DataGridViewCell cell in dgvProjector.SelectedCells) {
                    projector = _projectors.Find(x => x.Name.Equals(cell.Value));
                    projector.PowerOn();
                }
            }
        }

        private void cmdProjectorOff_Click(object sender, EventArgs e) {
            if (dgvProjector.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn off all projectors?",
                                                      "Turn off projectors", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (Projector projector in _projectors) {
                    projector.PowerOff();
                }
            }
            else {
                Projector projector;
                foreach (DataGridViewCell cell in dgvProjector.SelectedCells) {
                    projector = _projectors.Find(x => x.Name.Equals(cell.Value));
                    projector.PowerOff();
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvPC.ClearSelection();
            dgvMonitor.ClearSelection();
            dgvProjector.ClearSelection();
        }
    }
}
