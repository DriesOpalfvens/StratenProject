using System;

public class Municapality {

    public Municapality(int id) {

        Id = id;

    }

    public int Id { get; set; }

    public string Name { get; set; }

    private SortedSet<string> StreetNames = new SortedSet<string>();


    public void AddStreetName(string streetname) {

        StreetNames.Add(streetname);

    }

    public IReadOnlyList<string> GetStreetNames() {

        return StreetNames;

    }

}
