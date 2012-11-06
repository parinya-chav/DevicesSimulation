using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmDevicesSimApp.Model.View
{
    public class SimDeviceView
    {
        public SimDeviceView()
        { }

        private IList<PackageView> packageView;
        public IList<PackageView> PackageView
        {
            get { return packageView; }
            set
            {
                packageView = value;
            }
        }

        private string imei;
        public string Imei
        {
            get { return imei; }
            set
            {
                imei = value;
            }
        }

        /// <summary>
        /// 0 = Inactive, 1 = Active
        /// </summary>
        private byte status;
        public byte Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }

        private bool finish;
        public bool Finish
        {
            get { return finish; }
            set
            {
                finish = value;
            }
        }

        /// <summary>
        /// sendTime (s)
        /// </summary>
        private int sendTime;
        public int SendTime
        {
            get { return sendTime; }
            set
            {
                sendTime = value;
            }
        }

        private bool checkChoose;
        public bool CheckChoose
        {
            get { return checkChoose; }
            set
            {
                checkChoose = value;
            }
        }

        private int sendComplete;
        public int SendComplete
        {
            get { return sendComplete; }
            set
            {
                sendComplete = value;
            }
        }
        public void SendPacket()
        {
            ++SendComplete;
        }

        public void CheckSetAllComplete()
        {
            if (sendComplete == sendTotal)
                Finish = true;
        }

        private int sendTotal;
        public int SendTotal
        {
            get { return sendTotal; }
            set
            {
                sendTotal = value;
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }
    }
}
