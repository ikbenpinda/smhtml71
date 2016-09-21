using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formsapp2.Code.api
{
    public interface IResizeImage
    {
        byte[] ResizeImage(byte[] imageByte, float width, float height);
    }
}
