using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmDevicesSimApp.Model.View
{
    public class PackageView
    {
        public PackageView()
        { }

        private int sequence;
        public int Sequence
        {
            get { return sequence; }
            set
            {
                sequence = value;
            }
        }

        private string messageType;
        public string MessageType
        {
            get { return messageType; }
            set
            {
                messageType = value;
            }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }
    }
}
