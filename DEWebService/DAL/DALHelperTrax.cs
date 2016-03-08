using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Configuration;
using Filex.Persistence.ByteStream;
using Filex.MSharp.Excel.Bootstrap;
using Filex.MSharp.Runtime.Bootstrap;
using Trax.FPS;
namespace DAL
{
    public sealed class DALHelperTrax
    {
        public DALHelperTrax()
        {
                                    
        }

        public void PersistToFile(string FileName, InvBat invoiceBat)
        {
            try
            {
                using (ByteStreamWriter writer = new ByteStreamWriter(new BinaryWriter(new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None)), true))
                {
                    //writer.Write(PackageTitle);
                    //writer.Write(PackageVersion);
                    //writer.Write(FrameworkVersion);

                    writer.Write(invoiceBat);
                }
            }
            catch
            {
                //butang ug throw para mahibawan na nag error inig persist sa file.
            }
            finally
            { }
        }
                
        public object DepersistFile(string FileName)
        {
            object retval = null;
            ByteStreamReader reader = null;
            BinaryReader binaryReader = null;
            FileStream stream = null;
            try
            {
                stream = new FileStream(FileName, FileMode.Open);
                binaryReader = new BinaryReader(stream);
                reader = new ByteStreamReader(binaryReader);
                //string packageTitle = reader.ReadString();
                //string packageVersion = reader.ReadString();
                //string packageFramework = reader.ReadString();

                retval = reader.Read();
            }
            catch
            { 
                //butang ug throw para mahibawan na nag error inig Depersist sa file.
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (binaryReader != null)
                {
                    binaryReader.Close();
                }
                stream = null;
                binaryReader = null;
                reader = null;
            }
            return retval;
        }
    }
}
