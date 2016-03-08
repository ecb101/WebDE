using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace CommonLibrary
{
    public class CreatedBatch
    {
        private ArrayList Pages = new ArrayList();
        private string Batch;
        private long BatchID;
        private string BackupFolderPath;
        private string ImageDropPath;

        public ArrayList pages
        {
            get
            {
                return Pages;
            }

            set
            {
                Pages = value;
            }
        }

        public string batch
        {
            get
            {
                return Batch;
            }

            set
            {
                Batch = value;
            }
        }

        public long batchID
        {
            get
            {
                return BatchID;
            }

            set
            {
                BatchID = value;
            }
        }

        public string backupFolderPath
        {
            get
            {
                return BackupFolderPath;
            }

            set
            {
                BackupFolderPath = value;
            }
        }

        public string imageDropPath
        {
            get
            {
                return ImageDropPath;
            }

            set
            {
                ImageDropPath = value;
            }
        }
    }
}
