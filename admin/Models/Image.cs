using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stamford.Models;

namespace admin.Models
{
    public class Image
    {

        public async Task<string> UploadImage(IFormFile userfile)
        {
            if (userfile.Length > 0)
            {
                string filename = userfile.FileName;
                var guid = Guid.NewGuid().ToString();
                var imgname = guid.Split('-')[0];
                var filesplit = filename.Split('.')[1];
                filename = imgname+'.'+filesplit;

                string dirname = Directory.GetCurrentDirectory();
                var newdir = dirname.Replace("admin","website");
                newdir += "\\wwwroot\\img";
                string uploadfilepath = Path.Combine(newdir, filename);
                using (var stream = new FileStream(uploadfilepath, FileMode.OpenOrCreate))
                {
                    await userfile.CopyToAsync(stream);
                }
                return filename;
            }
            else return "";
        }
         public async Task<string> UploadProfileImage(IFormFile userfile)
        {
            if (userfile.Length > 0)
            {
                string filename = userfile.FileName;
                filename = Path.GetFileName(filename);
                var guid = Guid.NewGuid().ToString();
                var imgname = guid.Split('-')[0];
                var filesplit = filename.Split('.')[1];
                filename = imgname+'.'+filesplit;

                string dirname = "wwwroot\\img";
                string uploadfilepath = Path.Combine( Directory.GetCurrentDirectory(),dirname, filename);
                using (var stream = new FileStream(uploadfilepath, FileMode.OpenOrCreate))
                {
                    await userfile.CopyToAsync(stream);
                }
                return filename;
            }
            else return "";
        }
        public void UploadImagetoDatabase(Asset asset,StamfordDBContext _context){
            _context.Assets.Add(asset);
            _context.SaveChanges();
        }

    }
}