namespace StratenProjectDL
{
    internal class Program
    {
        static void Main(string[] args)
        {
           public List<Province> ReadFiles(Dictionary<string,string> filesMap,string dir)
        {
            Dictionary<int, Province> provinces = new Dictionary<int, Province>();
            Dictionary<int, Municapality> municapalities = new Dictionary<int, Municapality>();
            Dictionary<int,string> streetNames = new Dictionary<int,string>();

            // lees provintie id
            HashSet<int>provinceIds = new HashSet<int>();
            using (StreamReader p = new StreamReader(Path.Combine(dir, filesMap["provinces"])))
            {
                string[] ids = p.ReadLine().Trim().Split(",");
                foreach (string id in ids)
                {
                    provinceIds.Add(Int32.Parse(id));
                }
            }

            // lees de provincienamen + provincieId+gemeenteId
            using (StreamReader gp = new StreamReader(Path.Combine(dir, filesMap["link_Province_MunicipalityNames"])))
            {

            }


            // lees gemeentenamen + gemeenteid
            using (StreamReader g = new StreamReader(Path.Combine(dir, filesMap["municipalityNames"])))
            {

            }

            // lees straatamen
            using (StreamReader s = new StreamReader(Path.Combine(dir, filesMap["streetNames"])))
            {

            }

            // lees straatnaamId + gemeenteId
            using (StreamReader sg = new StreamReader(Path.Combine(dir, filesMap["link_StreetName_Municipality"]))) { 
            

            }

            return provinces.Values.ToList();

        }
    }
}
