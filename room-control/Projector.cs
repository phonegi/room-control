﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class Projector : Device, IPowerControl, IInputControl {

        public const DeviceType Type = DeviceType.PROJECTOR;

        private PJLinkConnection _connection;
        private PowerCommand.PowerStatus _powerStatus = PowerCommand.PowerStatus.UNKNOWN;

        public Projector() { }

        public void InitPJLinkConnection() {
            _connection = new PJLinkConnection(IP.ToString(), PASSWORD);
        }

        public PowerCommand.PowerStatus GetPowerStatus() {
            //_powerStatus = _connection.powerQuery();
            return _powerStatus;
        }

        public void PowerOff() {
            if (_connection.turnOff()) {
                _powerStatus = PowerCommand.PowerStatus.OFF;
            }
            else {
                _powerStatus = PowerCommand.PowerStatus.UNKNOWN;
            }
        }

        public void PowerOn() {
            if (_connection.turnOn()) {
                _powerStatus = PowerCommand.PowerStatus.ON;
            }
            else {
                _powerStatus = PowerCommand.PowerStatus.UNKNOWN;
            }
        }

        public void SetInput(InputCommand.InputType inputType, int port) {
            InputCommand inputCommand = new InputCommand(inputType, port);
            _connection.sendCommand(inputCommand);
        }

        public void GetInputStatus(out InputCommand.InputType type, out int port) {
            InputCommand inputCommand = new InputCommand();
            //_connection.sendCommand(inputCommand);
            type = inputCommand.Input;
            port = inputCommand.Port;
        }

    }
}
