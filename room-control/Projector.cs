using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class Projector : Device, IPowerControl, IInputControl {

        public const DeviceType TYPE = DeviceType.PROJECTOR;

        private PJLinkConnection _connection;

        public Projector() { }

        public void InitPJLinkConnection() {
            _connection = new PJLinkConnection(IP.ToString(), PASSWORD);
        }

        PowerCommand.PowerStatus IPowerControl.GetPowerStatus() {
            return _connection.powerQuery();
        }

        void IPowerControl.PowerOff() {
            _connection.turnOff();
        }

        void IPowerControl.PowerOn() {
            _connection.turnOff();
        }

        void IInputControl.SetInput(InputCommand.InputType inputType, int port) {
            InputCommand inputCommand = new InputCommand(inputType, port);
            _connection.sendCommand(inputCommand);
        }

        void IInputControl.GetInputStatus(out InputCommand.InputType type, out int port) {
            InputCommand inputCommand = new InputCommand();
            _connection.sendCommand(inputCommand);
            type = inputCommand.Input;
            port = inputCommand.Port;
        }

    }
}
