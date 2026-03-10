using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratenProjectBL.Interface
{
    internal interface IStratenProvinciesBestandenLezer
    {
        List<Municapality> LeesDataMunicapality(string pad, string logpad);
    }
}
