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
                dgvPC.Rows.Add( new object[] { pc.Name, Properties.Resources.hourglass } );
                pc.PowerStatusChanged += PcPowerStatusChanged;
                //pc.UpdatePowerStatus();
            }

            _monitors = deviceList.monitorList.monitors;
            foreach (Monitor monitor in _monitors) {
                monitor.InitPJLinkConnection();
                dgvMonitor.Rows.Add(new object[] { monitor.Name, Properties.Resources.hourglass, Properties.Resources.hourglass });
                monitor.PowerStatusChanged += MonitorPowerStatusChanged;
                monitor.InputStatusChanged += MonitorInputStatusChanged;
                //if (monitor.Name == "monitor-south-3") {
                    monitor.UpdatePowerStatus();
                //}
            }

            _projectors = deviceList.projectorList.projectors;
            foreach (Projector projector in _projectors) {
                projector.InitPJLinkConnection();
                dgvProjector.Rows.Add(new object[] { projector.Name, Properties.Resources.hourglass, Properties.Resources.hourglass });
                projector.PowerStatusChanged += ProjectorPowerStatusChanged;
                //projector.UpdatePowerStatus();
            }
        }

        private Bitmap GetPowerStatusImage(PowerCommand.PowerStatus status) {
            switch (status) {
                case PowerCommand.PowerStatus.ON:
                    return Properties.Resources.dot_green;
                case PowerCommand.PowerStatus.OFF:
                    return Properties.Resources.dot_red;
                case PowerCommand.PowerStatus.COOLING:
                    return Properties.Resources.cool_down;
                case PowerCommand.PowerStatus.WARMUP:
                    return Properties.Resources.warm_22x22;
            }
            return Properties.Resources.question_mark;
        }

        private Bitmap GetInputStatusImage(InputCommand.InputType type, int port) {
            if (type == InputCommand.InputType.DIGITAL) {
                switch (port) {
                    case 1:
                        return Properties.Resources.broadcast;
                    case 2:
                        return Properties.Resources.laptop;
                }
            }
            return Properties.Resources.question_mark;
        }

        private void PcPowerStatusChanged(object sender, PowerStatusChangedEventArgs e) {
            PC pc = sender as PC;
            Bitmap image = GetPowerStatusImage(e.NewStatus);

            foreach (DataGridViewRow row in dgvPC.Rows) {
                if (row.Cells[0].Value.Equals(pc.Name)) {
                    row.Cells[1].Value = image;
                    return;
                }
            }
        }

        private void MonitorPowerStatusChanged(object sender, PowerStatusChangedEventArgs e) {
            Monitor monitor = sender as Monitor;
            Bitmap image = GetPowerStatusImage(e.NewStatus);

            foreach (DataGridViewRow row in dgvMonitor.Rows) {
                if (row.Cells[0].Value.Equals(monitor.Name)) {
                    row.Cells[1].Value = image;
                    if (e.NewStatus == PowerCommand.PowerStatus.OFF) {
                        row.Cells[2].Value = null;
                    }
                    else if (e.NewStatus == PowerCommand.PowerStatus.ON) {
                        System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                            System.Threading.Thread.Sleep(10000);
                            monitor.UpdateInputStatus();
                        });
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    return;
                }
            }
        }

        private void MonitorInputStatusChanged(object sender, InputStatusChangedEventArgs e) {
            Monitor monitor = sender as Monitor;
            Bitmap image = GetInputStatusImage(e.NewType, e.NewPort);

            foreach (DataGridViewRow row in dgvMonitor.Rows) {
                if (row.Cells[0].Value.Equals(monitor.Name)) {
                    row.Cells[2].Value = image;
                    return;
                }
            }
        }

        private void ProjectorPowerStatusChanged(object sender, PowerStatusChangedEventArgs e) {
            Projector projector = sender as Projector;
            Bitmap image = GetPowerStatusImage(e.NewStatus);

            foreach (DataGridViewRow row in dgvProjector.Rows) {
                if (row.Cells[0].Value.Equals(projector.Name)) {
                    row.Cells[1].Value = image;
                    return;
                }
            }
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
