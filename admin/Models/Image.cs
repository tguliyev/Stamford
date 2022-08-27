using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stamford.Models;

namespace admin.Models
{
    public class Image
    {

        public string UploadImage(IFormFile userfile)
        {
            if (userfile.Length > 0)
            {
                string filename = userfile.FileName;
                filename = Path.GetFileName(filename);
                string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images", filename);
                using (var stream = new FileStream(uploadfilepath, FileMode.OpenOrCreate))
                {
                    userfile.CopyToAsync(stream);
                }
                return filename;
            }
            else return "";
        }

        public Asset? CheckPhoto(string url,StamfordDBContext _context){
            var image = _context.Assets.FirstOrDefault(i => i.Url == url);
            if(image==null)return null;
            else return image;
        }
        public void UploadImagetoDatabase(Asset asset,StamfordDBContext _context){
            _context.Assets.Add(asset);
            _context.SaveChanges();
        }

    }
}