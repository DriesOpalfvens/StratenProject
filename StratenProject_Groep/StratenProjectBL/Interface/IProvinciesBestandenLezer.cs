using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratenProjectBL.Interface
{
    internal interface IProvinciesBestandenLezer
    {
        List<Province> LeesDataProvince(string pad, string logpad);
    }
}
