using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class Monitor : PJLinkDevice, IInputControl {
        public static int INPUT_BROADCAST = 1;
        public static int INPUT_PC = 2;

        private InputCommand.InputType _inputType;
        private int _port = -1;

        public Monitor() {
            _type = DeviceType.MONITOR;
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

        private void OnInputStatusChanged(InputStatusChangedEventArgs e) {
            EventHandler<InputStatusChangedEventArgs> eventHandler = InputStatusChanged;
            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }

        #region IInputControl Implementation
        public event EventHandler<InputStatusChangedEventArgs> InputStatusChanged;

        public void GetInputStatus(out InputCommand.InputType type, out int port) {
            type = _inputType;
            port = _port;
        }

        public void SetInput(InputCommand.InputType inputType, int port) {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                InputCommand inputCommand = new InputCommand(inputType, port);
                Command.Response response = _connection.sendCommand(inputCommand);
                if (response == Command.Response.SUCCESS) {
                    UpdateInputStatus(inputType, port);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public void UpdateInputStatus(InputCommand.InputType expectedType = InputCommand.InputType.UNKNOWN, int expectedPort = -1) {
            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.Add(new TimeSpan(0, 0, _maximumLoopTimeSpan));
                DateTime nextLoopTime;
                InputCommand cmd = new InputCommand();
                Command.Response response;

                // Loop a maximum of every nextLoopTime seconds until:
                // 1. Current status = expectedStatus != UNKNOWN
                // 2. Current status != UNKNOWN && expectedStatus = UNKNOWN
                // 3. endTime is reached
                while (DateTime.Now < endTime) {
                    nextLoopTime = DateTime.Now.Add(new TimeSpan(0, 0, _minimumLoopTimeSpan));
                    response = _connection.sendCommand(cmd);
                    if (response == Command.Response.SUCCESS) {
                        SetInputStatus(cmd.Input, cmd.Port);
                    }
                    else {
                        SetInputStatus(InputCommand.InputType.UNKNOWN);
                    }
                    if (expectedType != InputCommand.InputType.UNKNOWN) {
                        if (_inputType == expectedType && _port == expectedPort) { return; }
                    }
                    else if (_inputType != InputCommand.InputType.UNKNOWN) { return; }
                    if (nextLoopTime > DateTime.Now) {
                        System.Threading.Thread.Sleep((nextLoopTime - DateTime.Now).Milliseconds);
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion
    }
}
