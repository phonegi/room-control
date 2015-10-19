using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl {
    public enum PowerStatus {
        OFF,
        ON,
        COOLING,
        WARMUP,
        UNKNOWN
    }

    public interface IPowerControl {
        void PowerOn();
        void PowerOff();
    }

    public interface IPowerStatus {
        PowerStatus GetPowerStatus();
    }
}
