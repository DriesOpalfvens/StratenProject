using System;
using System.Globalization;

public class Province {
    public Province(int id, string name) {
        ProvinceId = id;
        ProvinceName = name;
    }
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    private Dictionary<int, Municapality> Municipalities = new Dictionary<int, Municapality>;

    public void AddMunicipality(Municapality municapality) {
        Municipalities.TryAdd(municapality.Id, municapality);   
    }

    public bool HasMunicpality(int id) { 
        return Municipalities.ContainsKey(id);
    }

    public Municapality GetMunicapality(int id) {
        return Municipalities[id];
    }
    public IReadOnlyList<Municapality> GetMunicapalities() { 
        return Municipalities.Values.ToList(); 
    }

}
