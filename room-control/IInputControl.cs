using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {

    public class InputStatusChangedEventArgs : EventArgs {
        public InputCommand.InputType NewType;
        public int NewPort;
        public InputCommand.InputType OldType = InputCommand.InputType.UNKNOWN;
        public int OldPort = -1;

        public InputStatusChangedEventArgs(InputCommand.InputType newType, int newPort) {
            NewType = newType;
            NewPort = newPort;
        }

        public InputStatusChangedEventArgs(InputCommand.InputType newType, int newPort, InputCommand.InputType oldType, int oldPort) {
            NewType = newType;
            NewPort = newPort;
            OldType = oldType;
            OldPort = oldPort;
        }
    }

    interface IInputControl {
        void SetInput(InputCommand.InputType inputType, int port);
        void UpdateInputStatus();
        void GetInputStatus(out InputCommand.InputType type, out int port);
        event EventHandler<InputStatusChangedEventArgs> InputStatusChanged;
    }
}
