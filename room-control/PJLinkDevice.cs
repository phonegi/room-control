using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public abstract class PJLinkDevice : PoweredDevice {
        protected const string PASSWORD = "anatomage";
        protected PJLinkConnection _connection;

        public PJLinkDevice() {
            _maximumLoopTimeSpan = 60;
            _minimumLoopTimeSpan = 2;
        }

        public void InitPJLinkConnection() {
            _connection = new PJLinkConnection(IP.ToString(), PASSWORD);
        }

        public override void PowerOff() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                _connection.turnOff();
                UpdatePowerStatus(PowerCommand.PowerStatus.OFF);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public override void PowerOn() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                _connection.turnOn();
                UpdatePowerStatus(PowerCommand.PowerStatus.ON);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        protected override bool GetPowerStatus(PowerCommand.PowerStatus expectedStatus) {
            PowerCommand cmd = new PowerCommand(PowerCommand.Power.QUERY);
            Command.Response response;

            response = _connection.sendCommand(cmd);
            if (response == Command.Response.SUCCESS) {
                _powerStatus = cmd.Status;
            }
            else {
                _powerStatus = PowerCommand.PowerStatus.UNKNOWN;
            }
            if (expectedStatus != PowerCommand.PowerStatus.UNKNOWN) {
                if (_powerStatus == expectedStatus) { return true; }
            }
            else if (_powerStatus != PowerCommand.PowerStatus.UNKNOWN) { return true; }
            return false;
        }
    }
}
