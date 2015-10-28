using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class Projector : OriginalDevice, IPowerControl {


        private PJLinkConnection _connection;
        private PowerCommand.PowerStatus __powerStatus;
        private PowerCommand.PowerStatus _powerStatus {
            get { return __powerStatus; }
            set {
                if (value != __powerStatus) {
                    PowerStatusChangedEventArgs args = new PowerStatusChangedEventArgs(value, __powerStatus);
                    OnPowerStatusChanged(args);
                    __powerStatus = value;
                }
            }
        }

        public Projector() {
            _type = DeviceType.PROJECTOR;
            __powerStatus = PowerCommand.PowerStatus.UNKNOWN;
        }

        public void InitPJLinkConnection() {
            _connection = new PJLinkConnection(IP.ToString(), PASSWORD);
        }

        #region IPowerControl Implementation
        public event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged;

        private void OnPowerStatusChanged(PowerStatusChangedEventArgs e) {
            EventHandler<PowerStatusChangedEventArgs> eventHandler = PowerStatusChanged;
            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }

        public PowerCommand.PowerStatus PowerStatus {
            get { return __powerStatus; }
        }

        public void PowerOn() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                _connection.turnOn();
                UpdatePowerStatus(PowerCommand.PowerStatus.ON);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public void PowerOff() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                _connection.turnOff();
                UpdatePowerStatus(PowerCommand.PowerStatus.OFF);
            });
            thread.IsBackground = true;
        }

        public void UpdatePowerStatus(PowerCommand.PowerStatus expectedStatus = PowerCommand.PowerStatus.UNKNOWN) {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.Add(new TimeSpan(0, 0, 15));
                DateTime nextLoopTime;
                PowerCommand cmd = new PowerCommand(PowerCommand.Power.QUERY);
                Command.Response response;
                
                // Loop a maximum of every nextLoopTime seconds until:
                // 1. Current status = expectedStatus != UNKNOWN
                // 2. Current status != UNKNOWN && expectedStatus = UNKNOWN
                // 3. endTime is reached
                while (DateTime.Now < endTime) {
                    nextLoopTime = DateTime.Now.Add(new TimeSpan(0, 0, 1));
                    response = _connection.sendCommand(cmd);
                    if (response == Command.Response.SUCCESS) {
                        _powerStatus = cmd.Status;
                    }
                    else {
                        _powerStatus = PowerCommand.PowerStatus.UNKNOWN;
                    }
                    if (expectedStatus != PowerCommand.PowerStatus.UNKNOWN) {
                        if (_powerStatus == expectedStatus) { return; }
                    }
                    else if (_powerStatus != PowerCommand.PowerStatus.UNKNOWN) { return; }
                    if (nextLoopTime > DateTime.Now) {
                        System.Threading.Thread.Sleep((nextLoopTime - DateTime.Now).Milliseconds);
                    }
                }
                _powerStatus = PowerCommand.PowerStatus.UNKNOWN;
            });
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion

    }
}
