using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratenProjectBL.Interface
{
    internal interface IProvincieRepository
    {
        Province GetProvince(string provinceName);


        void importProvince(List<Province> provinceList);

    }
}
