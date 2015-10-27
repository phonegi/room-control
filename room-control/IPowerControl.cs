using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public class PowerStatusChangedEventArgs : EventArgs {
        public PowerCommand.PowerStatus NewStatus;
        public PowerCommand.PowerStatus OldStatus = PowerCommand.PowerStatus.UNKNOWN;

        public PowerStatusChangedEventArgs(PowerCommand.PowerStatus newStatus) {
            NewStatus = newStatus;
        }
        public PowerStatusChangedEventArgs(PowerCommand.PowerStatus newStatus, PowerCommand.PowerStatus oldStatus) {
            NewStatus = newStatus;
            OldStatus = oldStatus;
        }
    }

    interface IPowerControl {
        PowerCommand.PowerStatus PowerStatus { get; }
        void PowerOn();
        void PowerOff();
        void UpdatePowerStatus();
        void UpdatePowerStatus(PowerCommand.PowerStatus expectedStatus);
        event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged;
    }
}
