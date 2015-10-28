using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace RoomControl {
    public abstract class PoweredDevice : Device, IPowerControl {
        protected int _maximumLoopTimeSpan;     //in seconds
        protected int _minimumLoopTimeSpan;        //in seconds
        private PowerCommand.PowerStatus __powerStatus = PowerCommand.PowerStatus.UNKNOWN;

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

        // returns true if power status was subb
        protected abstract bool GetPowerStatus(PowerCommand.PowerStatus expectedStatus);

        #region IPowerControl Implementation
        public event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged;

        public PowerCommand.PowerStatus PowerStatus { get { return __powerStatus; } }

        public abstract void PowerOn();
        public abstract void PowerOff();

        public void UpdatePowerStatus(PowerCommand.PowerStatus expectedStatus = PowerCommand.PowerStatus.UNKNOWN) {

            System.Threading.Thread thread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.Add(new TimeSpan(0, 0, _maximumLoopTimeSpan));
                DateTime nextLoopTime;

                while (DateTime.Now < endTime) {
                    nextLoopTime = DateTime.Now.Add(new TimeSpan(0, 0, _minimumLoopTimeSpan));
                    if (GetPowerStatus(expectedStatus)) { return; }
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
