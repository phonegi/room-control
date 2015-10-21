using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    interface IInputControl {
        void SetInput(InputCommand.InputType inputType, int port);
        void GetInputStatus(out InputCommand.InputType inputType, out int port);
    }
}
