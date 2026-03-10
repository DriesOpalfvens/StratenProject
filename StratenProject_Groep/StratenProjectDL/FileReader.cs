using System.IO.Compression; // Noodzakelijk

namespace StratenProjectDL {
    public class StratenProjectDL_Reader {
        public List<Province> ReadFiles(Dictionary<string, string> filesMap, string dir) {
            Dictionary<int, Province> provinces = new Dictionary<int, Province>();
            Dictionary<int, Municapality> municapalities = new Dictionary<int, Municapality>();
            Dictionary<int, string> streetNames = new Dictionary<int, string>();

            // lees provintie id
            HashSet<int> provinceIds = new HashSet<int>();
            using (StreamReader p = new StreamReader(Path.Combine(dir, filesMap["provinces"]))) {
                string[] ids = p.ReadLine().Trim().Split(",");
                foreach (string id in ids) {
                    provinceIds.Add(Int32.Parse(id));
                }
            }

            // lees de provincienamen + provincieId+gemeenteId
            using (StreamReader gp = new StreamReader(Path.Combine(dir, filesMap["link_Province_MunicipalityNames"]))) 
            {
                string line;
                gp.ReadLine();
                while ((line = gp.ReadLine()) != null)
                {
                    string[] ss = line.Trim().Split(";");
                    int municipalityID = int.Parse(ss[0]);
                    int provinceID = int.Parse(ss[1]);
                    string languageCode = ss[2];
                    string provinceName = ss[3];

                    if (provinceIds.Contains(provinceID) && (languageCode == "nl"))
                    {

                        if (!provinces.ContainsKey(provinceID))
                        {
                            provinces.Add(provinceID, new Province(provinceID, provinceName));
                        }
                        if (!provinces[provinceID].HasMunicpality(municipalityID))
                        {
                            provinces[provinceID].AddMunicipality(new Municapality(municipalityID));
                            municapalities.Add(municipalityID, provinces[provinceID].GetMunicapality(municipalityID));
                        }
                    }
                }
            }


            // lees gemeentenamen + gemeenteid
            using (StreamReader g = new StreamReader(Path.Combine(dir, filesMap["municipalityNames"])))
            {
                string line;
                g.ReadLine();// skip header
                while ((line = g.ReadLine()) != null)
                {
                    string[] ss = line.Trim().Split(";");
                    int municipalityID = int.Parse(ss[1]);
                    string languageCode = ss[2];
                    string municipalityName = ss[3];

                    if(languageCode== "nl")
                    {
                        if (municapalities.ContainsKey(municipalityID)) municapalities[municipalityID].Name = municipalityName;
                    }
                }

            }

            // lees straatamen
            using (StreamReader s = new StreamReader(Path.Combine(dir, filesMap["streetNames"])))
            {
                string line;
                s.ReadLine();
                while ((line = s.ReadLine()) != null)
                {
                    string[] ss = line.Trim().Split(";");
                    int streetNameID = Int32.Parse(ss[0]);
                    string streetName = ss[1];
                    streetNames.Add(streetNameID, streetName);
                }
            }

            // lees straatnaamId + gemeenteId
            using (StreamReader sg = new StreamReader(Path.Combine(dir, filesMap["link_StreetName_Municipality"])))
            {

                string line;
                sg.ReadLine();
                while ((line = sg.ReadLine()) != null)
                {
                    string[] ss = line.Trim().Split(";");
                    int municipalityID = int.Parse(ss[1]);
                    int streetNameID = int.Parse(ss[0]);
                    if (municapalities.ContainsKey(municipalityID) && streetNames.ContainsKey(streetNameID))
                    {
                        municapalities[municipalityID].AddStreetName(streetNames[streetNameID]);
                    }
                }
            }
            return provinces.Values.ToList();

        }
    }
}
