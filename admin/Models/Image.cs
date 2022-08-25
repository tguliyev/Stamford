using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}