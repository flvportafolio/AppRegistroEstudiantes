using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFrontendUtils
{
    public static class FrontendUtils
    {
        public static decimal ParseDecimal(string valor)
        {
            if (valor == "")
            {
                return 0;
            }

            return Convert.ToDecimal(valor, CultureInfo.GetCultureInfo("en-US"));
        }

        public static bool ExistPathImage(string rutaImagen) {
            return File.Exists(rutaImagen);
        }
    }
}
