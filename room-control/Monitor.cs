﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class Monitor : Device, IPowerControl, IInputControl {

        public static int INPUT_BROADCAST = 1;
        public static int INPUT_PC = 2;

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
        private InputCommand.InputType _inputType;
        private int _port = -1;

        public Monitor() {
            _type = DeviceType.MONITOR;
            __powerStatus = PowerCommand.PowerStatus.UNKNOWN;
        }

        public void InitPJLinkConnection() {
            _connection = new PJLinkConnection(IP.ToString(), PASSWORD);
        }

        private void SetInputStatus(InputCommand.InputType inputType) {
            if (inputType != _inputType) {
                OnInputStatusChanged(new InputStatusChangedEventArgs(inputType, _port));
                _inputType = inputType;
            }
        }

        private void SetInputStatus(int port) {
            if (port != _port) {
                OnInputStatusChanged(new InputStatusChangedEventArgs(_inputType, port));
                _port = port;
            }
        }

        private void SetInputStatus(InputCommand.InputType inputType, int port) {
            if (inputType != _inputType || port != _port) {
                OnInputStatusChanged(new InputStatusChangedEventArgs(inputType, port));
                _inputType = inputType;
                _port = port;
            }
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
            thread.Start();
        }

        public void UpdatePowerStatus() {
            UpdatePowerStatus(PowerCommand.PowerStatus.UNKNOWN);
        }

        public void UpdatePowerStatus(PowerCommand.PowerStatus expectedStatus) {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                DateTime start = DateTime.Now;
                DateTime end = start.Add(new TimeSpan(0, 0, 10));
                DateTime nextLoopTime;
                PowerCommand cmd = new PowerCommand(PowerCommand.Power.QUERY);
                Command.Response response;

                while (DateTime.Now < end) {
                    nextLoopTime = DateTime.Now.Add(new TimeSpan(0, 0, 3));
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
            });
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion

        #region IInputControl Implementation
        public event EventHandler<InputStatusChangedEventArgs> InputStatusChanged;

        private void OnInputStatusChanged(InputStatusChangedEventArgs e) {
            EventHandler<InputStatusChangedEventArgs> eventHandler = InputStatusChanged;
            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }

        public void SetInput(InputCommand.InputType inputType, int port) {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                InputCommand inputCommand = new InputCommand(inputType, port);
                _connection.sendCommand(inputCommand);
                System.Threading.Thread.Sleep(2000);
                UpdateInputStatus();
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public void UpdateInputStatus() {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                InputCommand inputCommand = new InputCommand();
                Command.Response response = _connection.sendCommand(inputCommand);
                if (response == Command.Response.SUCCESS) {
                    SetInputStatus(inputCommand.Input, inputCommand.Port);
                }
                else {
                    SetInputStatus(InputCommand.InputType.UNKNOWN);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public void GetInputStatus(out InputCommand.InputType inputType, out int port) {
            inputType = _inputType;
            port = _port;
        }
        #endregion
    }
}

