﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using CarRent.Models;

namespace CarRent.Helpers
{
    public class HelperFunctions
    {
        // folder for the upload
        public static string ItemUploadFolderPath = "";
        public static string FullFileLocation;
        public static string FullThumbFileLocation;
        public static int FileSize;

        public static string renameUploadFile(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);//fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFile(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFile(file, finalFileName);
        }

        private static string uploadFile(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!validateExtension(extension))
            {
                return FullFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch (Exception ex)
            {
                FullFileLocation = "~/images/logo.png";
                return FullFileLocation;
            }
        }

        private static bool validateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                case ".pdf":
                    return true;
                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }


        ///#################################################### Thumb Image Uploading ##################################################################

        public static string ThumbrenameUploadFile(HttpPostedFileBase file, string ItmUpldFlPth, int size,Int32 counter = 0)
        {
            FileSize = size;
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);//fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return ThumbrenameUploadFile(file, ItmUpldFlPth, size, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return ThumbuploadFile(file, finalFileName);
        }

        private static string ThumbuploadFile(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!ThumbvalidateExtension(extension))
            {
                return FullThumbFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullThumbFileLocation = ItemUploadFolderPath + fileName;

                Image imgOriginal = Image.FromFile(path);

                //pass in whatever value you want 
                Image imgActual = ScaleBySize(imgOriginal, FileSize);
                imgOriginal.Dispose();
                imgActual.Save(path);
                imgActual.Dispose();

                return FullThumbFileLocation;
            }
            catch (Exception ex)
            {
                return FullThumbFileLocation;
            }
        }

        private static bool ThumbvalidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        public static Image ScaleBySize(Image imgPhoto, int size)
        {
           
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            if (size == 1)//Small Blog Thumb size //2 for medium size
            {
                destWidth = 160;
                destHeight = 108;
            }
            if (size == 2)//Small Blog Thumb size //2 for medium size
            {
                destWidth = 155;
                destHeight = 155;
            }
            // Width is greater than height, set Width = logoSize and resize height accordingly

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }

        ///#################################################### Resume Uploading ##################################################################
        ///
        public static string renameUploadFileResume(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "Resume_";
            //string finalFileName = append + ((counter).ToString()) + "_" + fileName;
            string finalFileName = append + ((counter).ToString()) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);//fileName;

            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFileResume(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFileResume(file, finalFileName);
        }

        private static string uploadFileResume(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!validateExtensionResume(extension))
            {
                return FullFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch (Exception ex)
            {
                FullFileLocation = "";
                return FullFileLocation;
            }
        }

        private static bool validateExtensionResume(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".pdf":
                    return true;
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }

        //########################Any File--All Files#########################


        public static string renameUpload_Any_File(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);//fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUpload_Any_File(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFile_Any(file, finalFileName);
        }



        private static string uploadFile_Any(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch (Exception ex)
            {
                FullFileLocation = "";
                return FullFileLocation;
            }
        }



        ////############################### Chat Files ##############################################################
        public static string renameUploadFile_chat(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            //string finalFileName = append + ((counter).ToString()) + "_" + fileName;
            string finalFileName = append + ((counter).ToString()) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);//fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFile_chat(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFile_chat(file, finalFileName);
        }

        private static string uploadFile_chat(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch
            {
                FullFileLocation = "";
                return FullFileLocation;
            }
        }

    }
}