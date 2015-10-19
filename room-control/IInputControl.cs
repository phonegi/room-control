using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl {
    public enum InputType {
        UNKNOWN,
        RGB,
        VIDEO,
        DIGITAL,
        STORAGE,
        NETWORK
    }

    interface IInputControl {
        void SetInput(int port);
    }

    interface IInputStatus {
        InputType GetInputStatus();
    }
}
