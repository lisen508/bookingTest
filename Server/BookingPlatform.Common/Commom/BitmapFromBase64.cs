using System;
using System.IO;

namespace BookingPlatform.Commom
{
    public static class BitmapFromBase64
    {
        public static bool BmpFromBase64(string FilePath, string InputStr)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(InputStr);
                using (var ms = new MemoryStream(arr))
                {
                    //using (var bmp = new Bitmap(ms))
                    //{
                    //    bmp.Save(FilePath, ImageFormat.Jpeg);
                    //    //bmp.Save(txtFileName + ".bmp", ImageFormat.Bmp);  
                    //    //bmp.Save(txtFileName + ".gif", ImageFormat.Gif);  
                    //    //bmp.Save(txtFileName + ".png", ImageFormat.Png);   
                    //    //imgPhoto.ImageUrl = txtFilePath + ".jpg";  
                    //    //MessageBox.Show("转换成功！");  


                    //    System.IO.File.WriteAllBytes(FilePath, arr);
                    //    return true;
                    //}
                    System.IO.File.WriteAllBytes(FilePath, arr);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }
    }
}
