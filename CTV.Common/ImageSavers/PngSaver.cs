﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using FunctionalProgrammingInfrastructure;

namespace CTV.Common.ImageSavers
{
    public class PngSaver : IImageSaver
    {
        public Result<None> Save(Bitmap image, Stream outputStream)
        {
            return Result.OfAction(() => image.Save(outputStream, ImageFormat.Png));
        }
    }
}