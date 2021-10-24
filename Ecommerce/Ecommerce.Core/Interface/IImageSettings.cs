using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interface
{
   public interface IImageSettings
    {
        public string ThumbnailBasePath { get; set; }
        public string FolderName { get; set; }
    }
}
