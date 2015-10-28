using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class PC : OriginalDevice, IPowerControl {
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
        
        public PC() {
            _type = DeviceType.PC;
            __powerStatus = PowerCommand.PowerStatus.UNKNOWN;
        }

        public PowerCommand.PowerStatus PowerStatus {
            get { return __powerStatus; }
        }

        private void OnPowerStatusChanged(PowerStatusChangedEventArgs e) {
            EventHandler<PowerStatusChangedEventArgs> eventHandler = PowerStatusChanged;
            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }
        
        private void SetPowerStatus(PowerCommand.PowerStatus powerStatus) {

        }

        #region IPowerControl Implementation
        public event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged;

        public void PowerOn() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                Network.WakeOnLan.WakeUp(MAC);
                UpdatePowerStatus(PowerCommand.PowerStatus.ON);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public void PowerOff() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                Wmi.Util.ShutdownHost(IP);
                UpdatePowerStatus(PowerCommand.PowerStatus.OFF);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public void UpdatePowerStatus() {
            UpdatePowerStatus(PowerCommand.PowerStatus.UNKNOWN);
        }

        public void UpdatePowerStatus(PowerCommand.PowerStatus expectedStatus) {

            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                DateTime start = DateTime.Now;
                DateTime end = start.Add(new TimeSpan(0, 1, 30));
                DateTime nextLoopTime;

                while (DateTime.Now < end) {
                    nextLoopTime = DateTime.Now.Add(new TimeSpan(0, 0, 5));
                    _powerStatus = Ping();
                    if (expectedStatus != PowerCommand.PowerStatus.UNKNOWN) {
                        if (_powerStatus == expectedStatus) { return; }
                    }
                    else if (_powerStatus != PowerCommand.PowerStatus.UNKNOWN) { return; }
                    if (nextLoopTime > DateTime.Now) {
                        System.Threading.Thread.Sleep((nextLoopTime - DateTime.Now).Milliseconds);
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion
        private PowerCommand.PowerStatus Ping() {
            Ping ping = new Ping();
            PingReply reply;
            PowerCommand.PowerStatus powerStatus;

            try {
                reply = ping.Send(IP, 3000);
                switch (reply.Status) {
                    case IPStatus.Success:
                    case IPStatus.DestinationPortUnreachable:
                    case IPStatus.DestinationProtocolUnreachable:
                        powerStatus = PowerCommand.PowerStatus.ON;
                        break;
                    case IPStatus.BadDestination:
                    case IPStatus.DestinationHostUnreachable:
                    case IPStatus.TimedOut:
                    case IPStatus.TimeExceeded:
                    case IPStatus.TtlExpired:
                        powerStatus = PowerCommand.PowerStatus.OFF;
                        break;
                    default:
                        powerStatus = PowerCommand.PowerStatus.UNKNOWN;
                        break;
                }
            }
            catch {
                powerStatus = PowerCommand.PowerStatus.UNKNOWN;
            }
            return powerStatus;
        }

        public PowerCommand.PowerStatus GetPowerStatus() {
            return _powerStatus;
        }
    }
}
