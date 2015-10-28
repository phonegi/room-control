
using rv;
using System.Net.NetworkInformation;

namespace RoomControl {
    public class PC : PoweredDevice {

        public PC() {
            _type = DeviceType.PC;
            _maximumLoopTimeSpan = 90;
            _minimumLoopTimeSpan = 3;
        }

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

        #region PoweredDevice Implementation
        public override void PowerOff() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                Wmi.Util.ShutdownHost(IP);
                UpdatePowerStatus(PowerCommand.PowerStatus.OFF);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public override void PowerOn() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                Network.WakeOnLan.WakeUp(MAC);
                UpdatePowerStatus(PowerCommand.PowerStatus.ON);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        protected override bool GetPowerStatus(PowerCommand.PowerStatus expectedStatus) {
            _powerStatus = Ping();
            if (expectedStatus != PowerCommand.PowerStatus.UNKNOWN) {
                if (_powerStatus == expectedStatus) { return true; }
            }
            else if (_powerStatus != PowerCommand.PowerStatus.UNKNOWN) { return true; }
            return false;
        }
        #endregion

    }
}
