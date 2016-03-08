using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormControls
{
    public class IDUpdate
    {
        private string originalID;
        private string newID;

        public string OriginalID
        {
            get
            {
                return originalID;
            }
        }

        public string NewID
        {
            get
            {
                return newID;
            }
        }

        public IDUpdate()
        { }

        public IDUpdate(string OriginalID, string NewID)
        {
            this.originalID = OriginalID;
            this.newID = NewID;
        }
    }
}
