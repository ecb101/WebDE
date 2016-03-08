using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CommonLibrary
{
    
    public class ImageStamp
    {
        private int page;
        private int splitFBCount;
        private bool isStamped;
        private bool isForSplit;
        public bool IsForSplit
        {
            get
            {
                return isForSplit;
            }

            set
            {
                isForSplit = value;
            }
        }
        public bool IsStamped
        {
            get
            {
                return isStamped;
            }

            set
            {
                isStamped = value;
            }
        }
        public int Page
        {
            get
            {
                return page;
            }

            set
            {
                page = value;
            }
        }
        public int SplitFBCount
        {
            get
            {
                return splitFBCount;
            }

            set
            {
                splitFBCount = value;
            }
        }        
        public ImageStamp()
        {
        }
        public ImageStamp(int pageNo, bool stamp)
        {
            this.page = pageNo;
            this.isStamped = stamp;
            this.isForSplit = false;
        }
        public ImageStamp(int pageNo, bool stamp, bool forSplit)
        {
            this.page = pageNo;
            this.isStamped = stamp;
            this.isForSplit = forSplit;
        }    
    }
}
