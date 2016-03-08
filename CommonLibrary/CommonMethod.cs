using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
namespace CommonLibrary
{
    public static class CommonMethod
    {
        #region private methods
        
        
        
        
        #endregion

        #region public methods
        public static Bitmap createHeaderPage(DataRow row, string ICS, string rootBatch, string pageRange, string imageIssue, string carrierName)
        {
            Bitmap retval = new Bitmap(858, 1106);
            CommonFont barcodeFont = new CommonFont();
            try
            {
                Graphics g = Graphics.FromImage(retval);
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImageUnscaled(retval, 0, 0);
                g.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, retval.Width, retval.Height);
                Font contentFont = new Font("Arial", 10);
                Font headerFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
                
                #region Populate Contents
                //Boxes and its labels
                g.DrawString("Coder :", contentFont, brush, 140, 20);
                g.DrawRectangle(new Pen(brush), 140, 37, 100, 60);
                g.DrawString("Keyer :", contentFont, brush, 250, 20);
                g.DrawRectangle(new Pen(brush), 250, 37, 100, 60);
                g.DrawString("Date Submitted :", contentFont, brush, 360, 20);
                g.DrawRectangle(new Pen(brush), 360, 37, 100, 60);

                //MXX Batch Number
                g.DrawString(row["BatchNumber"].ToString().Trim(), new System.Drawing.Font("Arial", 28, FontStyle.Bold), brush, 600, 20);
                //MXX Batch Number Barcode                
                g.DrawString("*" + row["BatchNumber"].ToString().Trim() + "*", new System.Drawing.Font(barcodeFont.PrivateFont.Families[0], 40), brush, 600, 80);

                //Other Contents
                g.DrawString("Date :", contentFont, brush, 550, 160);
                g.DrawString(row["Date"].ToString().Trim(), new System.Drawing.Font("Arial", 28, FontStyle.Bold), brush, 610, 140);

                g.DrawString("Mode :", contentFont, brush, 550, 190);
                g.DrawString(row["Mode"].ToString().Trim(), contentFont, brush, 650, 190);

                g.DrawString("SCAC :", contentFont, brush, 550, 220);
                //g.DrawString(row["SCAC"].ToString().Trim(), contentFont, brush, 650, 220);

                g.DrawString("Client :", contentFont, brush, 550, 250);
                //g.DrawString(row["Client"].ToString().Trim(), contentFont, brush, 650, 250);

                g.DrawString("Owner Key :", contentFont, brush, 550, 280);
                //g.DrawString(row["OwnerKey"].ToString().Trim(), contentFont, brush, 650, 280);

                g.DrawString("Owner Code :", contentFont, brush, 550, 310);
                //g.DrawString(row["OwnerCode"].ToString().Trim(), contentFont, brush, 650, 310);

                g.DrawString("Carrier :", contentFont, brush, 550, 340);
                g.DrawString(row["Carrier"].ToString().Trim(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(650, 340, 220, 40));

                g.DrawString("Level :", contentFont, brush, 550, 380);
                g.DrawString(row["Level"].ToString().Trim(), contentFont, brush, 650, 380);

                g.DrawString("Bills :", contentFont, brush, 550, 410);
                g.DrawString(row["Bills"].ToString().Trim(), contentFont, brush, 650, 410);

                g.DrawString("Invoices :", contentFont, brush, 550, 440);
                g.DrawString(row["Invoices"].ToString().Trim(), contentFont, brush, 650, 440);

                g.DrawString("Amount :", contentFont, brush, 550, 470);
                g.DrawString(Convert.ToInt32(row["Amount"]).ToString().Trim(), contentFont, brush, 650, 470);

                g.DrawString("ICS :", contentFont, brush, 550, 500);
                g.DrawString(ICS.Trim(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(650, 500, 220, 170));
                if (rootBatch.Trim() != string.Empty)
                {
                    g.DrawString("Root Batch :", contentFont, brush, 550, 530);
                    g.DrawString(rootBatch, contentFont, brush, 650, 530);

                    g.DrawString("Pages :", contentFont, brush, 550, 560);
                    g.DrawString(pageRange, contentFont, brush, 650, 560);
                }
                //Carrier Notes
                g.DrawString("Carrier Notes :", headerFont, brush, 20, 310);
                g.DrawString(row["CarrierNotes"].ToString().Trim(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(20, 330, 500, 170));
                //Client Specific Carrier Notes            
                g.DrawString("Client Specific Carrier Notes :", headerFont, brush, 20, 480);
                g.DrawString(row["ClientSpecific"].ToString().Trim(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(20, 500, 500, 200));
                
                //Carrier Name
                g.DrawString("Carrier Name :", headerFont, brush, 20, 680);
                g.DrawString(carrierName, new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(20, 700, 500, 170));
                //Image Issue
                if (imageIssue.Trim() != string.Empty)
                {
                    g.DrawString("Image Issue :", headerFont, brush, 20, 850);
                    g.DrawString(imageIssue, new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(20, 870, 500, 170));
                }
                #endregion
                g.Dispose();
            }
            catch
            {
            }
            retval = convertToMonochrome(retval);
            return retval;
        }
        /*
        public static Bitmap createHeaderPageNew(DataRow row)
        {
            Bitmap retval = new Bitmap(858, 1106);
            try
            {
                Graphics g = Graphics.FromImage(retval);
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImageUnscaled(retval, 0, 0);
                g.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, retval.Width, retval.Height);
                Font contentFont = new Font("Arial", 10);
                Font headerFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);

                #region Populate Contents
                //Boxes and its labels
                g.DrawString("Coder :", contentFont, brush, 140, 20);
                g.DrawRectangle(new Pen(brush), 140, 37, 100, 60);
                g.DrawString("Keyer :", contentFont, brush, 250, 20);
                g.DrawRectangle(new Pen(brush), 250, 37, 100, 60);
                g.DrawString("Date Submitted :", contentFont, brush, 360, 20);
                g.DrawRectangle(new Pen(brush), 360, 37, 100, 60);

                //MXX Batch Number
                g.DrawString(row["BatchNumber"].ToString().Trim(), new System.Drawing.Font("Arial", 28, FontStyle.Bold), brush, 600, 20);
                //MXX Batch Number Barcode
                g.DrawString("*" + row["BatchNumber"].ToString().Trim() + "*", new System.Drawing.Font("Free 3 of 9", 40), brush, 560, 80);

                //Other Contents
                g.DrawString("Date :", contentFont, brush, 550, 160);
                g.DrawString(row["Date"].ToString().Trim(), new System.Drawing.Font("Arial", 28, FontStyle.Bold), brush, 610, 140);

                g.DrawString("Mode :", contentFont, brush, 550, 190);
                g.DrawString(row["Mode"].ToString().Trim(), contentFont, brush, 650, 190);

                g.DrawString("SCAC :", contentFont, brush, 550, 220);
                g.DrawString(row["SCAC"].ToString().Trim(), contentFont, brush, 650, 220);

                g.DrawString("Client :", contentFont, brush, 550, 250);
                g.DrawString(row["Client"].ToString().Trim(), contentFont, brush, 650, 250);

                g.DrawString("Owner Key :", contentFont, brush, 550, 280);
                g.DrawString(row["OwnerKey"].ToString().Trim(), contentFont, brush, 650, 280);

                g.DrawString("Owner Code :", contentFont, brush, 550, 310);
                g.DrawString(row["OwnerCode"].ToString().Trim(), contentFont, brush, 650, 310);

                g.DrawString("Carrier :", contentFont, brush, 550, 340);
                g.DrawString(row["Carrier"].ToString().Trim(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(650, 340, 220, 40));

                g.DrawString("Level :", contentFont, brush, 550, 380);
                g.DrawString(row["Level"].ToString().Trim(), contentFont, brush, 650, 380);

                g.DrawString("Bills :", contentFont, brush, 550, 410);
                g.DrawString(row["Bills"].ToString().Trim(), contentFont, brush, 650, 410);

                g.DrawString("Invoices :", contentFont, brush, 550, 440);
                g.DrawString(row["Invoices"].ToString().Trim(), contentFont, brush, 650, 440);

                g.DrawString("Amount :", contentFont, brush, 550, 470);
                g.DrawString(Convert.ToInt32(row["Amount"]).ToString().Trim(), contentFont, brush, 650, 470);


                //Carrier Notes
                g.DrawString("Carrier Notes :", headerFont, brush, 20, 310);
                g.DrawString(row["CarrierNotes"].ToString().Trim(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(20, 330, 500, 170));
                //Client Specific Carrier Notes            
                g.DrawString("Client Specific Carrier Notes :", headerFont, brush, 20, 480);
                g.DrawString(row["ClientSpecific"].ToString().Trim(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), brush, new RectangleF(20, 500, 500, 500));

                #endregion
                g.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                retval = convertToMonochrome(retval);
            }
            return retval;
        }
        */
        public static Bitmap stampPage(Bitmap image, string pageNumber)
        {            
            Graphics g = Graphics.FromImage(image);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImageUnscaled(image, 0, 0);            
            g.DrawString(pageNumber, new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 10);
            g.Dispose();
            g = null;
            return image;
        }

        public static Bitmap stampImage(Bitmap image,string stampContent)
        {
            int x = 0;
            Graphics g = Graphics.FromImage(image);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImageUnscaled(image, 0, 0);
            //if(pageNumber.Trim() != string.Empty)
            //    g.DrawString(pageNumber, new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 10);
            g.DrawRectangle(new Pen(System.Drawing.Color.Black), new Rectangle(20, 20, 156, 63));
            switch (stampContent)
            {
                case "TRAX TECH APAC":
                    {
                        x = 22;
                        break;
                    }
                case "TRAX TECH LA":
                    {
                        x = 34;
                        break;
                    }
                case "J P M":
                    {
                        x = 74;
                        break;
                    }
            }
            g.DrawString(stampContent, new Font("Tahoma", 14, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), x, 22);
            g.DrawString(DateTime.Now.ToShortDateString(), new Font("Verdana", 12), new SolidBrush(System.Drawing.Color.Black), 56, 42);
            g.DrawString("RECEIVED", new Font("Verdana", 16, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 44, 60);
            g.Dispose();
            g = null;
            return image;
        }

        public static Bitmap stampImage(Bitmap image, string stampContent, DateTime date)
        {
            int x = 0;
            Graphics g = Graphics.FromImage(image);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImageUnscaled(image, 0, 0);
            g.DrawRectangle(new Pen(System.Drawing.Color.Red), new Rectangle(20, 20, 156, 63));
            switch (stampContent)
            {
                case "TRAX TECH APAC":
                    {
                        x = 22;
                        break;
                    }
                case "TRAX TECH LA":
                    {
                        x = 34;
                        break;
                    }
                case "J P M":
                    {
                        x = 74;
                        break;
                    }
            }
            g.DrawString(stampContent, new Font("Tahoma", 14, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Red), x, 22);
            g.DrawString(date.ToShortDateString(), new Font("Verdana", 12), new SolidBrush(System.Drawing.Color.Red), 56, 42);
            g.DrawString("RECEIVED", new Font("Verdana", 16, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Red), 44, 60);
            g.Dispose();
            g = null;
            return image;
        }

        public static Bitmap convertToMonochrome(Bitmap bmp)
        {
            Bitmap newBitmap = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format1bppIndexed);
            newBitmap.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            BitmapData bmpData = newBitmap.LockBits(new System.Drawing.Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.ReadWrite, newBitmap.PixelFormat);
            
            for (int y = 0; y < bmp.Height; y++)
            {
                byte[] scan = new byte[(bmp.Width + 7) / 8];
                for (int x = 0; x < bmp.Width; x++)
                {
                    System.Drawing.Color c = bmp.GetPixel(x, y);
                    if (c.GetBrightness() >= 0.5)
                        scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                System.Runtime.InteropServices.Marshal.Copy(scan, 0, (IntPtr)((int)bmpData.Scan0 + bmpData.Stride * y), scan.Length);
            }

            newBitmap.UnlockBits(bmpData);
            
            return newBitmap;
        }
        
        public static ImageCodecInfo getCodecInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            } return null;
        }

        public static string getFileType(string filename)
        {
            string[] fileType = filename.Split('.');
            return fileType[fileType.Length - 1];
        }

        public static string getFileName(string filename)
        {
            string[] file = filename.Split('\\');
            return file[file.Length - 1];
        }
        /*
        public static void createTiffImage(string saveAsFileName, string fileName, System.IO.Stream fileImageStream, DataRow row)
        {
            Bitmap myBitmap = createHeaderPage(row,"","");
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            System.Drawing.Imaging.Encoder compressionEncoder = System.Drawing.Imaging.Encoder.Compression;

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
            ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);

            //Save the master bitmap
            try
            {
                myBitmap.Save(saveAsFileName, getCodecInfo("image/tiff"), ep);

                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                System.Drawing.Image imageFile = System.Drawing.Image.FromStream(fileImageStream);

                FrameDimension frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);

                int numberOfImages = imageFile.GetFrameCount(frameDimensions);


                string type = getFileType(fileName);

                if (type.ToUpper() == "GIF" ||
                    type.ToUpper() == "PNG" ||
                    type.ToUpper() == "JPG" ||
                    type.ToUpper() == "BMP")//process image file types
                {
                    Bitmap temp = new Bitmap(fileImageStream);
                    ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionLZW);
                    myBitmap.SaveAdd(temp, ep);
                    temp.Dispose();
                }
                else if (type.ToUpper() == "TIF")//process tif file types possible multipage
                {
                    ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
                    for (int intFrame = 0; intFrame < numberOfImages; intFrame++)
                    {
                        imageFile.SelectActiveFrame(frameDimensions, intFrame);

                        myBitmap.SaveAdd(imageFile, ep);
                    }

                }
                else//file not supported
                {
                    throw new Exception("File type not supported.");
                }
                imageFile.Dispose();
                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.Flush);

                myBitmap.SaveAdd(ep);
            }
            catch (Exception _err)
            {
                myBitmap.Dispose();
                throw _err;
            }
            finally
            {                
                myBitmap.Dispose();
            }
        }
        */
        public static int getTiffPageCount(string imageFileName)
        { 
            int retval= 0;
            try
            {
                System.Drawing.Image imageFile = System.Drawing.Image.FromFile(imageFileName);

                FrameDimension frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);

                retval = imageFile.GetFrameCount(frameDimensions);

                imageFile.Dispose();
            }
            catch
            {                
            }

            return retval;
        }

        public static string base36Encode(Int64 value)
        {
            char[] base36Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string returnValue = "";
            if (value < 0)
            {
                value *= -1;
            }
            do
            {
                returnValue = base36Chars[value % base36Chars.Length] + returnValue;
                value /= 36;
            } while (value != 0);
            return returnValue;
        }

        public static Int64 base36Decode(string input)
        {
            string base36Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] arrInput = input.ToCharArray();
            Array.Reverse(arrInput);
            Int64 returnValue = 0;
            for (int i = 0; i < arrInput.Length; i++)
            {
                int valueindex = base36Chars.IndexOf(arrInput[i]);
                returnValue += Convert.ToInt64(valueindex * Math.Pow(36, i));
            }
            return returnValue;
        }
        
        public static object[] getCurrencyList()
        { 
            object [] retval = new object[] {"AED",
                                            "ALL",
                                            "AMD",
                                            "ARS",
                                            "ATS",
                                            "AUD",
                                            "AWG",
                                            "BAM",
                                            "BBD",
                                            "BDT",
                                            "BEF",
                                            "BGN",
                                            "BHD",
                                            "BIF",
                                            "BMD",
                                            "BND",
                                            "BOB",
                                            "BRL",
                                            "BSD",
                                            "BTN",
                                            "BWP",
                                            "BYR",
                                            "BZD",
                                            "CAD",
                                            "CFP",
                                            "CHF",
                                            "CLP",
                                            "CNY",
                                            "COP",
                                            "CRC",
                                            "CSK",
                                            "CVE",
                                            "CYP",
                                            "CZK",
                                            "DEM",
                                            "DJF",
                                            "DKK",
                                            "DOP",
                                            "DZD",
                                            "EEK",
                                            "EGP",
                                            "ESP",
                                            "ETB",
                                            "EUR",
                                            "FIM",
                                            "FJD",
                                            "FKP",
                                            "FRF",
                                            "GBP",
                                            "GEL",
                                            "GHS",
                                            "GIP",
                                            "GMD",
                                            "GNF",
                                            "GRD",
                                            "GTQ",
                                            "HKD",
                                            "HNL",
                                            "HRK",
                                            "HTG",
                                            "HUF",
                                            "IDR",
                                            "IEP",
                                            "ILS",
                                            "INR",
                                            "IQD",
                                            "IRR",
                                            "ISK",
                                            "ITL",
                                            "JMD",
                                            "JOD",
                                            "JPY",
                                            "KES",
                                            "KHR",
                                            "KMF",
                                            "KRW",
                                            "KWD",
                                            "KZT",
                                            "LAK",
                                            "LBP",
                                            "LKR",
                                            "LRD",
                                            "LSL",
                                            "LTL",
                                            "LUF",
                                            "LVL",
                                            "LYD",
                                            "MAD",
                                            "MDL",
                                            "MGA",
                                            "MKD",
                                            "MMK",
                                            "MNT",
                                            "MOP",
                                            "MRO",
                                            "MTL",
                                            "MUR",
                                            "MVR",
                                            "MWK",
                                            "MXN",
                                            "MYR",
                                            "MZN",
                                            "NAD",
                                            "NGN",
                                            "NIO",
                                            "NLG",
                                            "NOK",
                                            "NPR",
                                            "NZD",
                                            "OMR",
                                            "PAB",
                                            "PEN",
                                            "PGK",
                                            "PHP",
                                            "PKR",
                                            "PLN",
                                            "PTE",
                                            "PYG",
                                            "QAR",
                                            "RMB",
                                            "RON",
                                            "RSD",
                                            "RUB",
                                            "RWF",
                                            "SAR",
                                            "SCR",
                                            "SDG",
                                            "SEK",
                                            "SGD",
                                            "SIT",
                                            "SKK",
                                            "SOS",
                                            "STD",
                                            "SVC",
                                            "SYP",
                                            "SZL",
                                            "THB",
                                            "TND",
                                            "TRY",
                                            "TTD",
                                            "TWD",
                                            "TZS",
                                            "UAH",
                                            "UGX",
                                            "USD",
                                            "UYU",
                                            "VEB",
                                            "VEF",
                                            "VND",
                                            "VUV",
                                            "WST",
                                            "XAF",
                                            "XAG",
                                            "XAU",
                                            "XEU",
                                            "XOF",
                                            "XPF",
                                            "YER",
                                            "ZAR",
                                            "ZMK",
                                            "ZZZ"};
            return retval;
        }

        public static object[] getOldCurrencyList()
        {
            object[] retval = new object[] {"AED",
                                            "ALL",
                                            "AMD",
                                            "ARS",
                                            "ATS",
                                            "AUD",
                                            "AWG",
                                            "BAM",
                                            "BBD",
                                            "BDT",
                                            "BEF",
                                            "BGN",
                                            "BHD",
                                            "BIF",
                                            "BMD",
                                            "BND",
                                            "BOB",
                                            "BRL",
                                            "BSD",
                                            "BTN",
                                            "BWP",
                                            "BYR",
                                            "BZD",
                                            "CAD",
                                            "CFP",
                                            "CHF",
                                            "CLP",
                                            "CNY",
                                            "COP",
                                            "CRC",
                                            "CSK",
                                            "CVE",
                                            "CYP",
                                            "CZK",
                                            "DEM",
                                            "DJF",
                                            "DKK",
                                            "DOP",
                                            "DZD",
                                            "EEK",
                                            "EGP",
                                            "ESP",
                                            "ETB",
                                            "EUR",
                                            "FIM",
                                            "FJD",
                                            "FKP",
                                            "FRF",
                                            "GBP",
                                            "GEL",
                                            "GHS",
                                            "GIP",
                                            "GMD",
                                            "GNF",
                                            "GRD",
                                            "GTQ",
                                            "HKD",
                                            "HNL",
                                            "HRK",
                                            "HTG",
                                            "HUF",
                                            "IDR",
                                            "IEP",
                                            "ILS",
                                            "INR",
                                            "IQD",
                                            "IRR",
                                            "ISK",
                                            "ITL",
                                            "JMD",
                                            "JOD",
                                            "JPY",
                                            "KES",
                                            "KHR",
                                            "KMF",
                                            "KRW",
                                            "KWD",
                                            "KZT",
                                            "LAK",
                                            "LBP",
                                            "LKR",
                                            "LRD",
                                            "LSL",
                                            "LTL",
                                            "LUF",
                                            "LVL",
                                            "LYD",
                                            "MAD",
                                            "MDL",
                                            "MGA",
                                            "MKD",
                                            "MMK",
                                            "MNT",
                                            "MOP",
                                            "MRO",
                                            "MTL",
                                            "MUR",
                                            "MVR",
                                            "MWK",
                                            "MXN",
                                            "MYR",
                                            "MZN",
                                            "NAD",
                                            "NGN",
                                            "NIO",
                                            "NLG",
                                            "NOK",
                                            "NPR",
                                            "NZD",
                                            "OMR",
                                            "PAB",
                                            "PEN",
                                            "PGK",
                                            "PHP",
                                            "PKR",
                                            "PLN",
                                            "PTE",
                                            "PYG",
                                            "QAR",
                                            "RMB",
                                            "RON",
                                            "RSD",
                                            "RUB",
                                            "RWF",
                                            "SAR",
                                            "SCR",
                                            "SDG",
                                            "SEK",
                                            "SGD",
                                            "SIT",
                                            "SKK",
                                            "SOS",
                                            "STD",
                                            "SVC",
                                            "SYP",
                                            "SZL",
                                            "THB",
                                            "TND",
                                            "TRY",
                                            "TTD",
                                            "TWD",
                                            "TZS",
                                            "UAH",
                                            "UGX",
                                            "USD",
                                            "UYU",
                                            "VEB",
                                            "VEF",
                                            "VND",
                                            "VUV",
                                            "WST",
                                            "XAF",
                                            "XAG",
                                            "XAU",
                                            "XEU",
                                            "XOF",
                                            "XPF",
                                            "YER",
                                            "ZAR",
                                            "ZMK"};
            return retval;
        }

        public static string createID(long idCounter, string siteID)
        {
            string retval = string.Empty;
            if (idCounter < 0)
                throw new Exception("");
            else
                retval = "MXX" + CommonMethod.base36Encode(Convert.ToInt64(idCounter)).PadLeft(4, '0') + CommonMethod.base36Encode(Convert.ToInt64(siteID));

            return retval;
        }

        public static string createID(string sitePrefix, long idCounter)
        {
            string retval = string.Empty;
            if (sitePrefix == string.Empty || idCounter < 0)
                throw new Exception("");
            else
                retval = sitePrefix + base36Encode(Convert.ToInt64(idCounter)).PadLeft(7, '0');

            return retval;
        }
        
        public static long createIDKey(long idCounter, string siteID)
        {
            long retval = 0;
            if (idCounter < 0)
                throw new Exception("");
            else
            {
                retval = Convert.ToInt64(siteID) * 0x000000174876e800;
                retval += idCounter;
            }
            return retval;
        }

        public static bool createErrorLog(string errorMessage)
        {
            bool retval = false;
            string filename = ConfigurationManager.AppSettings["ErrorLog"] + System.Environment.MachineName + ".txt";
            try
            {
                string Text = string.Empty;
                StreamWriter sw = File.AppendText(filename);
                Text = DateTime.Now.ToString() + "\r\n" + errorMessage + "\r\n";
                sw.WriteLine(Text);
                sw.Close();
            }
            catch { }
            return retval;
        }

        public static void combineImage(string filename, ArrayList imageFiles)
        {
            try
            {
                if (imageFiles.Count > 0)
                {
                    if (!Directory.Exists(filename.Substring(0, filename.Length - CommonMethod.getFileName(filename).Length)))
                    {
                        Directory.CreateDirectory(filename.Substring(0, filename.Length - CommonMethod.getFileName(filename).Length));
                    }
                    Bitmap myBitmap = new Bitmap(imageFiles[0].ToString().Trim());
                    Bitmap temp;
                    string type = string.Empty;
                    System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
                    EncoderParameters ep = new EncoderParameters(1);

                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
                    myBitmap.Save(filename, CommonMethod.getCodecInfo("image/tiff"), ep);
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                    if (CommonMethod.getFileType(imageFiles[0].ToString().ToUpper()) == "TIF")
                    {
                        System.Drawing.Image imageFile = System.Drawing.Image.FromFile(imageFiles[0].ToString().Trim(), true);
                        FrameDimension frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);
                        int numberOfImages = imageFile.GetFrameCount(frameDimensions);
                        try
                        {
                            for (int intFrame = 1; intFrame < numberOfImages; intFrame++)
                            {
                                imageFile.SelectActiveFrame(frameDimensions, intFrame);
                                myBitmap.SaveAdd(imageFile, ep);
                            }
                        }
                        catch (Exception _err)
                        {
                            throw _err;
                        }
                        finally
                        {
                            imageFile.Dispose();
                            imageFile = null;
                        }
                    }
                    string test = string.Empty;
                    for (int i = 1; i < imageFiles.Count; i++)
                    {
                        type = CommonMethod.getFileType(imageFiles[i].ToString());
                        if (type.ToUpper() == "GIF" ||
                            type.ToUpper() == "PNG" ||
                            type.ToUpper() == "JPG" ||
                            type.ToUpper() == "BMP")//process image file types
                        {
                            temp = new Bitmap(imageFiles[i].ToString().Trim());
                            myBitmap.SaveAdd(temp, ep);
                            temp.Dispose();
                            temp = null;
                        }
                        else if (type.ToUpper() == "TIF")//process tif file types possible multipage
                        {
                            System.Drawing.Image imageFile = System.Drawing.Image.FromFile(imageFiles[i].ToString().Trim(), true);
                            FrameDimension frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);
                            int numberOfImages = imageFile.GetFrameCount(frameDimensions);

                            try
                            {
                                for (int intFrame = 0; intFrame < numberOfImages; intFrame++)
                                {
                                    imageFile.SelectActiveFrame(frameDimensions, intFrame);
                                    myBitmap.SaveAdd(imageFile, ep);
                                }
                            }
                            catch (Exception _err)
                            {
                                throw _err;
                            }
                            finally
                            {
                                imageFile.Dispose();
                                imageFile = null;
                            }
                        }
                        else
                        {
                            throw new Exception("File type not supported.");
                        }
                    }

                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);

                    myBitmap.SaveAdd(ep);


                    myBitmap.Dispose();
                    myBitmap = null;
                    
                }
            }
            catch (Exception _err)
            {
                throw _err;
                //MessageBox.Show("Image creation failed with this error: " + _err.Message, "Image Combine");
            }
            finally
            {
            }
            #region Deleted
            /*
            try
            {
                if (this.lstBoxImages.Items.Count > 1)
                {
                    Image TempImageFile = System.Drawing.Image.FromFile(lstBoxImages.Items[0].ToString().Trim());
                    Bitmap myBitmap = new Bitmap(TempImageFile.Width,TempImageFile.Height);
                    Bitmap temp;
                    string type = string.Empty;

                    System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;

                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);

                    for (int i = 0; i < this.lstBoxImages.Items.Count; i++)
                    {
                        type = CommonMethod.getFileType(this.lstBoxImages.Items[i].ToString());
                        myBitmap.Save(filename, CommonMethod.getCodecInfo("image/tiff"), ep);
                        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);                        
                        if (
                            type.ToUpper() == "GIF" ||
                            type.ToUpper() == "PNG" ||
                            type.ToUpper() == "JPG" ||
                            type.ToUpper() == "BMP")//process image file types
                        {
                            temp = new Bitmap(lstBoxImages.Items[i].ToString().Trim());
                            myBitmap.SaveAdd(temp, ep);
                            temp.Dispose();
                            temp = null;
                        }
                        else if (type.ToUpper() == "TIF")//process tif file types possible multipage
                        {
                            Image imageFile = System.Drawing.Image.FromFile(lstBoxImages.Items[i].ToString().Trim(), true);

                            FrameDimension frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);

                            int numberOfImages = imageFile.GetFrameCount(frameDimensions);

                            try
                            {
                                for (int intFrame = 0; intFrame < numberOfImages; intFrame++)
                                {
                                    imageFile.SelectActiveFrame(frameDimensions, intFrame);

                                    myBitmap.SaveAdd(imageFile, ep);
                                }
                            }
                            catch (Exception _err)
                            {
                                throw _err;
                            }
                            finally
                            {
                                //imageFile.Dispose();
                                //imageFile = null;
                            }
                        }
                        else//file not supported
                        {
                            throw new Exception("File type not supported.");
                        }

                        //}
                    }
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);

                    //close out the file.

                    myBitmap.SaveAdd(ep);


                    myBitmap.Dispose();
                    myBitmap = null;
                    TempImageFile.Dispose();
                    TempImageFile = null;
                    MessageBox.Show("image creation successful", "Image Combine");
                }
                lstBoxImages.Items.Clear();
            }
            catch (Exception _err)
            {
                MessageBox.Show("Image creation failed with this error: " + _err.Message, "Image Combine");
            }
            finally
            {                

            }
             */
            #endregion
        }

        public static void createTiffImage(string saveAsFileName, string ICS, DataRow row, Image imageFile, ArrayList stamp, ArrayList imagePages, string StampLabel, string rootBatch, string imageIssue, string carrierName)
        {
            FrameDimension frameDimensions;
            frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);
            Bitmap myBitmap = CommonMethod.createHeaderPage(row, ICS, rootBatch, (Convert.ToInt32(imagePages[0])+1).ToString() + " - " + (Convert.ToInt32(imagePages[imagePages.Count -1])+1).ToString(), imageIssue,carrierName);
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            System.Drawing.Imaging.Encoder compressionEncoder = System.Drawing.Imaging.Encoder.Compression;

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
            ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);

            //Save the master bitmap
            try
            {
                myBitmap.Save(saveAsFileName, CommonMethod.getCodecInfo("image/tiff"), ep);

                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                string type = CommonMethod.getFileType(CommonMethod.getFileName(saveAsFileName));


                if (type.ToUpper() == "TIF")//process tif file types possible multipage
                {
                    ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);

                    foreach (object page in imagePages)//lstBoxForGrouping.Items)
                    {
                        imageFile.SelectActiveFrame(frameDimensions, Convert.ToInt32(page) - 1);
                        //if (!isSplitBatch)
                        //{
                        if (((ImageStamp)stamp[Convert.ToInt32(page) - 1]).IsStamped)//getStamped(Convert.ToInt32(page) - 1))
                        {
                            string text = StampLabel;
                            Bitmap temp = new Bitmap(imageFile, imageFile.Width, imageFile.Height);
                            temp = CommonMethod.stampImage(temp, text);
                            temp.SetResolution(imageFile.HorizontalResolution, imageFile.VerticalResolution);
                            ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
                            temp = CommonMethod.convertToMonochrome(temp);
                            myBitmap.SaveAdd(temp, ep);
                            temp.Dispose();
                            temp = null;
                        }
                        else
                        {
                            myBitmap.SaveAdd(imageFile, ep);
                        }
                        //}
                        //else
                        //{
                        //    string text = StampLabel;
                        //    Bitmap temp = new Bitmap(imageFile, imageFile.Width, imageFile.Height);
                        //    if (((ImageStamp)stamp[Convert.ToInt32(page) - 1]).IsStamped)
                        //    {
                        //        temp = CommonMethod.stampImage(temp, text, page.ToString());
                        //    }
                        //    else
                        //    {
                        //        temp = CommonMethod.stampPage(temp, page.ToString());
                        //    }
                        //    temp.SetResolution(imageFile.HorizontalResolution, imageFile.VerticalResolution);
                        //    ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
                        //    temp = CommonMethod.convertToMonochrome(temp);
                        //    myBitmap.SaveAdd(temp, ep);
                        //    temp.Dispose();
                        //    temp = null;
                        //}
                    }
                }
                else//file not supported
                {
                    throw new Exception("File type not supported.");
                }
                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.Flush);

                myBitmap.SaveAdd(ep);
            }
            catch (Exception _err)
            {
                throw _err;
            }
            finally
            {
                myBitmap.Dispose();
                myBitmap = null;
                ep.Dispose();
                ep = null;
            }
        }
        /*
        public static void createTiffImageWithQA(string saveAsFileName, string ICS, DataRow row, Image imageFile, ArrayList stamp, ArrayList imagePages, string StampLabel)
        {
            FrameDimension frameDimensions;
            frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);
            Bitmap myBitmap = null;// CommonMethod.createHeaderPage(row, ICS);
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            System.Drawing.Imaging.Encoder compressionEncoder = System.Drawing.Imaging.Encoder.Compression;

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
            ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);

            //Save the master bitmap
            try
            {
                myBitmap.Save(saveAsFileName, CommonMethod.getCodecInfo("image/tiff"), ep);

                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                string type = CommonMethod.getFileType(CommonMethod.getFileName(saveAsFileName));


                if (type.ToUpper() == "TIF")//process tif file types possible multipage
                {
                    ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);

                    foreach (object page in imagePages)//lstBoxForGrouping.Items)
                    {
                        imageFile.SelectActiveFrame(frameDimensions, Convert.ToInt32(page) - 1);

                        if (((ImageStamp)stamp[Convert.ToInt32(page) - 1]).IsStamped)//getStamped(Convert.ToInt32(page) - 1))
                        {
                            string text = StampLabel;
                            //if (radioAPAC.Checked)
                            //    text = "TRAX TECH APAC";
                            //else if (radioLA.Checked)
                            //    text = "TRAX TECH LA";
                            //else if (radioJPM.Checked)
                            //    text = "J P M";
                            Bitmap temp = new Bitmap(imageFile, imageFile.Width, imageFile.Height);
                            temp = CommonMethod.stampImage(temp, text);
                            ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
                            temp = CommonMethod.convertToMonochrome(temp);
                            myBitmap.SaveAdd(temp, ep);
                            temp.Dispose();
                            temp = null;
                        }
                        else
                        {
                            myBitmap.SaveAdd(imageFile, ep);
                        }
                    }
                }
                else//file not supported
                {
                    throw new Exception("File type not supported.");
                }
                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.Flush);

                myBitmap.SaveAdd(ep);
            }
            catch (Exception _err)
            {
                throw _err;
            }
            finally
            {
                myBitmap.Dispose();
                myBitmap = null;
                ep.Dispose();
                ep = null;
            }
        }

        public static void createTiffImageQA(string saveAsFileName, string ICS, DataRow row, Image imageFile)
        {
            FrameDimension frameDimensions;
            frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);
            Bitmap myBitmap = CommonMethod.createHeaderPage(row, ICS, string.Empty, string.Empty);
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            System.Drawing.Imaging.Encoder compressionEncoder = System.Drawing.Imaging.Encoder.Compression;

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
            ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            
            //Save the master bitmap
            try
            {
                myBitmap.Save(saveAsFileName, CommonMethod.getCodecInfo("image/tiff"), ep);

                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                string type = CommonMethod.getFileType(CommonMethod.getFileName(saveAsFileName));
                
                if (type.ToUpper() == "TIF")//process tif file types possible multipage
                {
                    ep.Param[0] = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);
                    for (int page = 0; page < imageFile.GetFrameCount(frameDimensions); page++)
                    {
                        imageFile.SelectActiveFrame(frameDimensions, page);
                        myBitmap.SaveAdd(imageFile, ep);
                    }
                }
                else//file not supported
                {
                    throw new Exception("File type not supported.");
                }
                ep.Param[1] = new EncoderParameter(enc, (long)EncoderValue.Flush);

                myBitmap.SaveAdd(ep);
            }
            catch (Exception _err)
            {
                throw _err;
            }
            finally
            {
                myBitmap.Dispose();
                myBitmap = null;
                ep.Dispose();
                ep = null;
            }
        }
        */
        public static void moveDirectory(string source, string destination)
        {
            MoveDirectory(source + "\0", destination + "\0");
        }

        [DllImport("MoveDirectory.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern void MoveDirectory(string source, string destination);

        public static string getWebServiceName(string completeURL)
        {
            string[] name = completeURL.Split('/');
            return name[name.Length - 1];
        }
        #endregion
    }
}
