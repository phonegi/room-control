using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class PC : Device, IPowerControl {


        private PowerCommand.PowerStatus _powerStatus = PowerCommand.PowerStatus.UNKNOWN;

        public PC() {
            _type = DeviceType.PC;
        }


        public void PowerOff() {
            _powerStatus = Wmi.Util.ShutdownHost(IP) == Wmi.Util.ShutdownResult.SUCCESS ? PowerCommand.PowerStatus.OFF : PowerCommand.PowerStatus.UNKNOWN;
        }

        public void PowerOff(FormMain.UpdatePowerStatusImage_Delegate UpdatePowerStatusImage) {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                Wmi.Util.ShutdownHost(IP);
                UpdatePowerStatus(UpdatePowerStatusImage, PowerCommand.PowerStatus.OFF);
                UpdatePowerStatusImage(this, _powerStatus);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void UpdatePowerStatus(FormMain.UpdatePowerStatusImage_Delegate UpdatePowerStatusImage, PowerCommand.PowerStatus expectedStatus) {
            DateTime start = DateTime.Now;
            DateTime end = start.Add(new TimeSpan(0, 1, 30));
            DateTime nextLoopTime;
            PowerCommand.PowerStatus currentStatus = _powerStatus;
            while (DateTime.Now < end) {
                nextLoopTime = DateTime.Now.Add(new TimeSpan(0, 0, 5));
                GetPowerStatus();
                if (_powerStatus == expectedStatus) { return; }
                if (_powerStatus != currentStatus) {
                    UpdatePowerStatusImage(this, _powerStatus);
                    currentStatus = _powerStatus;
                }
                if (nextLoopTime > DateTime.Now) {
                    System.Threading.Thread.Sleep((DateTime.Now - nextLoopTime).Milliseconds);
                }
            }
        }

        public void PowerOn() {
            _powerStatus = Network.WakeOnLan.WakeUp(MAC) ? PowerCommand.PowerStatus.ON : PowerCommand.PowerStatus.UNKNOWN;
        }

        public PowerCommand.PowerStatus GetPowerStatus() {
            Ping ping = new Ping();
            PingReply reply;
            try {
                reply = ping.Send(IP, 3000);
                switch (reply.Status) {
                    case IPStatus.Success:
                    case IPStatus.DestinationPortUnreachable:
                    case IPStatus.DestinationProtocolUnreachable:
                        _powerStatus = PowerCommand.PowerStatus.ON;
                        break;
                    case IPStatus.BadDestination:
                    case IPStatus.DestinationHostUnreachable:
                    case IPStatus.TimedOut:
                    case IPStatus.TimeExceeded:
                    case IPStatus.TtlExpired:
                        _powerStatus = PowerCommand.PowerStatus.OFF;
                        break;
                    default:
                        _powerStatus = PowerCommand.PowerStatus.UNKNOWN;
                        break;
                }
            }
            catch {
                _powerStatus = PowerCommand.PowerStatus.UNKNOWN;
            }
            return _powerStatus;
        }
    }
}
