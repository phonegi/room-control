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
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace RoomControl
{
    public partial class FormMain : Form {
        private volatile bool _inEverythingOnLoop = false;
        private volatile bool _inEverythingOffLoop = false;

        private List<PC> _pcs;
        private List<Monitor> _monitors;
        private List<Projector> _projectors;
        private IPAddress localPcIp;
        private IPAddress localMonitorIp;

        public delegate void UpdatePowerStatusImage_Delegate(Device device, PowerCommand.PowerStatus status);
        public delegate void UpdateInputStatusImage_Delegate(Device device, InputCommand.InputType inputType, int port);

        private const int COL_PC_NAME = 0;
        private const int COL_PC_POWER = 1;
        private const int COL_MONITOR_NAME = 0;
        private const int COL_MONITOR_POWER = 1;
        private const int COL_MONITOR_INPUT = 2;
        private const int COL_PROJECTOR_NAME = 0;
        private const int COL_PROJECTOR_POWER = 1;

        public FormMain() {
            InitializeComponent();
        }

        private void LoadDevices() {
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));
            StreamReader reader = new StreamReader("room-control.xml");
            DeviceList deviceList = (DeviceList)serializer.Deserialize(reader);
            reader.Close();

            _pcs = deviceList.pcList.pcs;
            foreach (PC pc in _pcs) {
                dgvPC.Rows.Add(new object[] { pc.Name, Properties.Resources.hourglass });
                pc.PowerStatusChanged += PcPowerStatusChanged;
                pc.UpdatePowerStatus();
            }

            _monitors = deviceList.monitorList.monitors;
            foreach (Monitor monitor in _monitors) {
                monitor.InitPJLinkConnection();
                dgvMonitor.Rows.Add(new object[] { monitor.Name, Properties.Resources.hourglass, Properties.Resources.hourglass });
                monitor.PowerStatusChanged += MonitorPowerStatusChanged;
                monitor.InputStatusChanged += MonitorInputStatusChanged;
                monitor.UpdatePowerStatus();
            }

            _projectors = deviceList.projectorList.projectors;
            foreach (Projector projector in _projectors) {
                projector.InitPJLinkConnection();
                dgvProjector.Rows.Add(new object[] { projector.Name, Properties.Resources.hourglass, Properties.Resources.hourglass });
                projector.PowerStatusChanged += ProjectorPowerStatusChanged;
                projector.UpdatePowerStatus();
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
                if (row.Cells[COL_PC_NAME].Value.Equals(pc.Name)) {
                    row.Cells[COL_PC_POWER].Value = image;
                    break;
                }
            }

            //if turning off all devices, turn off computer first
            //when a computer is turned off, turn off the monitor
            if (_inEverythingOffLoop && e.NewStatus == PowerCommand.PowerStatus.OFF) {
                string monitorName = pc.Name.Replace("pc", "monitor");
                foreach (DataGridViewRow row in dgvMonitor.Rows) {
                    if (row.Cells[COL_MONITOR_NAME].Value.ToString().Equals(monitorName)) {
                        row.Cells[COL_MONITOR_POWER].Value = Properties.Resources.hourglass;
                        break;
                    }
                }
                Monitor monitor = _monitors.Find(x => x.Name.Equals(monitorName));
                monitor.PowerOff();
            }
        }

        private void MonitorPowerStatusChanged(object sender, PowerStatusChangedEventArgs e) {
            Monitor monitor = sender as Monitor;
            Bitmap image = GetPowerStatusImage(e.NewStatus);

            foreach (DataGridViewRow row in dgvMonitor.Rows) {
                if (row.Cells[COL_MONITOR_NAME].Value.Equals(monitor.Name)) {
                    row.Cells[COL_MONITOR_POWER].Value = image;
                    if (e.NewStatus == PowerCommand.PowerStatus.OFF) {
                        row.Cells[COL_MONITOR_INPUT].Value = null;
                    }
                    else if (e.NewStatus == PowerCommand.PowerStatus.ON) {
                        row.Cells[COL_MONITOR_INPUT].Value = Properties.Resources.hourglass;
                        System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                            monitor.UpdateInputStatus();
                        });
                        thread.IsBackground = true;
                        thread.Start();

                        //If turning on all devices, turn on monitors first.
                        //Once the monitor is on, turn on the PC
                        if (_inEverythingOnLoop && e.NewStatus == PowerCommand.PowerStatus.ON) {
                            string pcName = monitor.Name.Replace("monitor", "pc");
                            foreach (DataGridViewRow pcRow in dgvPC.Rows) {
                                if (pcRow.Cells[COL_PC_NAME].Value.ToString().Equals(pcName)) {
                                    pcRow.Cells[COL_PC_POWER].Value = Properties.Resources.hourglass;
                                    break;
                                }
                            }
                            PC pc = _pcs.Find(x => x.Name.Equals(pcName));
                            pc.PowerOn();
                        }
                    }
                    return;
                }
            }
        }

        private void MonitorInputStatusChanged(object sender, InputStatusChangedEventArgs e) {
            Monitor monitor = sender as Monitor;
            Bitmap image = GetInputStatusImage(e.NewType, e.NewPort);

            foreach (DataGridViewRow row in dgvMonitor.Rows) {
                if (row.Cells[COL_MONITOR_NAME].Value.Equals(monitor.Name)) {
                    row.Cells[COL_MONITOR_INPUT].Value = image;
                    return;
                }
            }
        }

        private void ProjectorPowerStatusChanged(object sender, PowerStatusChangedEventArgs e) {
            Projector projector = sender as Projector;
            Bitmap image = GetPowerStatusImage(e.NewStatus);

            foreach (DataGridViewRow row in dgvProjector.Rows) {
                if (row.Cells[COL_PROJECTOR_NAME].Value.Equals(projector.Name)) {
                    row.Cells[COL_PROJECTOR_POWER].Value = image;
                    return;
                }
            }
        }

        private void cmdPcOn_Click(object sender, EventArgs e) {
            PC pc;
            if (dgvPC.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all PCs?", "Power ON", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    foreach (DataGridViewRow row in dgvPC.Rows) {
                        row.Cells[COL_PC_POWER].Value = Properties.Resources.hourglass;
                        pc = _pcs.Find(x => x.Name.Equals(row.Cells[COL_PC_NAME].Value.ToString()));
                        pc.PowerOn();
                    }
                }
            }
            else {
                foreach (DataGridViewCell cell in dgvPC.SelectedCells) {
                    dgvPC.Rows[cell.RowIndex].Cells[COL_PC_POWER].Value = Properties.Resources.hourglass;
                    pc = _pcs.Find(x => x.Name.Equals(cell.Value.ToString()));
                    pc.PowerOn();
                }
            }
        }

        private void cmdPcOff_Click(object sender, EventArgs e) {
            PC pc;

            if (dgvPC.SelectedCells.Count == 0) {

                DialogResult result = MessageBox.Show("Are you sure you want to turn off ALL PCs?", "Power OFF", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                result = MessageBox.Show("Click OK to turn off ALL PCs", "Confirm", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK) { return; }

                foreach (DataGridViewRow row in dgvPC.Rows) {
                    row.Cells[COL_PC_POWER].Value = Properties.Resources.hourglass;
                    pc = _pcs.Find(x => x.Name.Equals(row.Cells[COL_PC_NAME].Value.ToString()));
                    pc.PowerOff();
                }

            }
            else {
                DialogResult result = MessageBox.Show("Are you sure you want to turn off the selected PCs?", "Power OFF", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (DataGridViewCell cell in dgvPC.SelectedCells) {
                    dgvPC.Rows[cell.RowIndex].Cells[COL_PC_POWER].Value = Properties.Resources.hourglass;
                    pc = _pcs.Find(x => x.Name.Equals(cell.Value.ToString()));
                    pc.PowerOff();
                }
            }
        }

        private void cmdMonitorOn_Click(object sender, EventArgs e) {
            Monitor monitor;

            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all monitors?", "Power ON", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (DataGridViewRow row in dgvMonitor.Rows) {
                    row.Cells[COL_MONITOR_POWER].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells[COL_MONITOR_NAME].Value.ToString()));
                    monitor.PowerOn();
                }
            }
            else {
                foreach (DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    dgvMonitor.Rows[cell.RowIndex].Cells[COL_MONITOR_POWER].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.PowerOn();
                }
            }
        }

        private void cmdMonitorOff_Click(object sender, EventArgs e) {
            Monitor monitor;

            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn off all monitors?", "Power OFF", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (DataGridViewRow row in dgvMonitor.Rows) {
                    row.Cells[COL_MONITOR_POWER].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells[COL_MONITOR_NAME].Value.ToString()));
                    monitor.PowerOff();
                }
            }
            else {
                foreach (DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    dgvMonitor.Rows[cell.RowIndex].Cells[COL_MONITOR_POWER].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.PowerOff();
                }
            }
        }

        private void cmdMonitorInputBroadcast_Click(object sender, EventArgs e) {
            Monitor monitor;

            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to switch the input to the broadcast signal for all monitors?",
                                                      "Set input to broadcast", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (DataGridViewRow row in dgvMonitor.Rows) {
                    row.Cells[COL_MONITOR_INPUT].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells[COL_MONITOR_NAME].Value.ToString()));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_BROADCAST);
                }
            }
            else {
                foreach (DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    dgvMonitor.Rows[cell.RowIndex].Cells[COL_MONITOR_INPUT].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_BROADCAST);
                }
            }
        }

        private void cmdMonitorInputPc_Click(object sender, EventArgs e) {
            Monitor monitor;

            if (dgvMonitor.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to switch the input to the local PC for all monitors?",
                                                      "Set input to broadcast", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (DataGridViewRow row in dgvMonitor.Rows) {
                    row.Cells[COL_MONITOR_INPUT].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(row.Cells[COL_MONITOR_NAME].Value.ToString()));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_PC);
                }
            }
            else {
                foreach (DataGridViewCell cell in dgvMonitor.SelectedCells) {
                    dgvMonitor.Rows[cell.RowIndex].Cells[COL_MONITOR_INPUT].Value = Properties.Resources.hourglass;
                    monitor = _monitors.Find(x => x.Name.Equals(cell.Value));
                    monitor.SetInput(InputCommand.InputType.DIGITAL, Monitor.INPUT_PC);
                }
            }
        }

        private void cmdProjectorOn_Click(object sender, EventArgs e) {
            Projector projector;

            if (dgvProjector.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn on all projectors?",
                                                      "Turn on projectors", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (DataGridViewRow row in dgvProjector.Rows) {
                    row.Cells[COL_PROJECTOR_POWER].Value = Properties.Resources.hourglass;
                    projector = _projectors.Find(x => x.Name.Equals(row.Cells[COL_PROJECTOR_NAME].Value.ToString()));
                    projector.PowerOn();
                }
            }
            else {
                foreach (DataGridViewCell cell in dgvProjector.SelectedCells) {
                    dgvProjector.Rows[cell.RowIndex].Cells[COL_PROJECTOR_POWER].Value = Properties.Resources.hourglass;
                    projector = _projectors.Find(x => x.Name.Equals(cell.Value));
                    projector.PowerOn();
                }
            }
        }

        private void cmdProjectorOff_Click(object sender, EventArgs e) {
            Projector projector;

            if (dgvProjector.SelectedCells.Count == 0) {
                DialogResult result = MessageBox.Show("Do you want to turn off all projectors?",
                                                      "Turn off projectors", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }

                foreach (DataGridViewRow row in dgvProjector.Rows) {
                    row.Cells[COL_PROJECTOR_POWER].Value = Properties.Resources.hourglass;
                    projector = _projectors.Find(x => x.Name.Equals(row.Cells[COL_PROJECTOR_NAME].Value.ToString()));
                    projector.PowerOff();
                }
            }
            else {
                foreach (DataGridViewCell cell in dgvProjector.SelectedCells) {
                    dgvProjector.Rows[cell.RowIndex].Cells[COL_PROJECTOR_POWER].Value = Properties.Resources.hourglass;
                    projector = _projectors.Find(x => x.Name.Equals(cell.Value));
                    projector.PowerOff();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            LoadDevices();
            IdentifyLocalPcAndMonitor();

            dgvPC.ClearSelection();
            dgvMonitor.ClearSelection();
            dgvProjector.ClearSelection();
        }

        // Turn on all monitors first. Once monitor is on,
        // turn on the PC. That happens in MonitorPowerStatusChanged.
        private void cmdAllOn_Click(object sender, EventArgs e) {
            int allLoopTimeSpan = _pcs[0].MaximumLoopTimeSpan + _monitors[0].MaximumLoopTimeSpan;

            _inEverythingOnLoop = true;

            foreach (Monitor monitor in _monitors) {
                monitor.PowerOn();
            }

            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                System.Threading.Thread.Sleep(allLoopTimeSpan * 1000);
                _inEverythingOnLoop = false;
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void cmdAllOff_Click(object sender, EventArgs e) {
            int allLoopTimeSpan = _pcs[0].MaximumLoopTimeSpan + _monitors[0].MaximumLoopTimeSpan;

            DialogResult result = MessageBox.Show("This will turn off all devices in the room. Are you sure?",
                                                  "Turn off all devices", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) { return; }

            _inEverythingOffLoop = true;

            Projector projector;
            foreach (DataGridViewRow row in dgvProjector.Rows) {
                row.Cells[COL_PROJECTOR_POWER].Value = Properties.Resources.hourglass;
                projector = _projectors.Find(x => x.Name.Equals(row.Cells[COL_PROJECTOR_NAME].Value.ToString()));
                projector.PowerOff();
            }

            PC pc;
            foreach (DataGridViewRow row in dgvPC.Rows) {
                row.Cells[COL_PC_POWER].Value = Properties.Resources.hourglass;
                pc = _pcs.Find(x => x.Name.Equals(row.Cells[COL_PC_NAME].Value.ToString()));
                pc.PowerOff();
            }

            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                System.Threading.Thread.Sleep(allLoopTimeSpan * 1000);
                _inEverythingOffLoop = false;
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void IdentifyLocalPcAndMonitor() {
            IPAddress[] ipAddresses;
            Monitor monitor;
            PC pc;

            ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipAddress in ipAddresses) {
                if (IPAddress.IsLoopback(ipAddress) || ipAddress.AddressFamily != AddressFamily.InterNetwork) continue;
                localPcIp = ipAddress;
                break;
            }

            pc = _pcs.Find(x => x.IP.Equals(localPcIp));
            if (pc == null) {
                localPcIp = null;
                return;
            }

            monitor = _monitors.Find(x => x.Name.Equals(pc.Name.Replace("pc", "monitor")));
            localMonitorIp = monitor.IP;
            foreach (DataGridViewRow row in dgvPC.Rows) {
                pc = _pcs.Find(x => x.Name.Equals(row.Cells[COL_PC_NAME].Value.ToString()));
                if (pc.IP.Equals(localPcIp)) {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    dgvMonitor.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                    break;
                }
            }
        }
    }
}
