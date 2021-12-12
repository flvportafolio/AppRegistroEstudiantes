using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingUnitTest
{
    public class UIBase
    {
        internal MapperWeb MapperWeb;
        public UIBase()
        {
            MapperWeb = new MapperWeb();
        }
    }
}
