using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public abstract class PoweredDevice : Device, IPowerControl {
        public PowerCommand.PowerStatus PowerStatus { get; }

        protected PowerCommand.PowerStatus __powerStatus;
        protected PowerCommand.PowerStatus _powerStatus {
            get { return __powerStatus; }
            set {
                if (value != __powerStatus) {
                    PowerStatusChangedEventArgs args = new PowerStatusChangedEventArgs(value, __powerStatus);
                    OnPowerStatusChanged(args);
                    __powerStatus = value;
                }
            }
        }

        protected void OnPowerStatusChanged(PowerStatusChangedEventArgs e) {
            EventHandler<PowerStatusChangedEventArgs> eventHandler = PowerStatusChanged;
            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }
        public event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged;

        public abstract void PowerOff();
        public abstract void PowerOn();
        public abstract void UpdatePowerStatus(PowerCommand.PowerStatus expectedStatus = PowerCommand.PowerStatus.UNKNOWN);
    }
}
