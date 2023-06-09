﻿using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Linq;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile, string folder)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}.jpg";


            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"wwwroot\\photos\\{folder}",
            file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return $"~/photos/{folder}/{file}";
        }
        public async Task DeleteImageAsync(string imageId)
        {
            if (!string.IsNullOrEmpty(imageId))
            {
                string folder = imageId.Split('/')[2];
                string file = imageId.Split('/').Last();

                string delete = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", folder, file);

                if (File.Exists(delete))
                {
                    await Task.Run(() => File.Delete(delete));
                }


            }
        }
    }
}