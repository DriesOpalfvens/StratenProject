using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace StratenProjectDL_SQL {
    public class StratenRepoSQL {

        string connectionstring;

        public StratenRepoSQL(string connectionstring) {
            //this.connectionstring = connectionstring;

            //TIJDELIJK:
            //Verander in onderstaande connectiestring de naam van de data source naar jouw eigen
            this.connectionstring = @"Data Source=LAPTOP-518B66FM\\SQLEXPRESS;Initial Catalog=StratenProject;Integrated Security=True;Trust Server Certificate=True";
        }

        public void ImportDataToDB(List<Province> provinces) {
            
            string queryProvinces = "INSERT INTO Provinces(id,provincename) output INSERTED.ID VALUES(@id,@provincename)";
            //string queryMunicipalities = "INSERT INTO Municipalities(id,municipalityname,provinceid) output INSERTED.ID VALUES(@id,@municipalityname,@provinceid)";
            //string queryStreets = "INSERT INTO Streets(id,streetname,municipalityid) output INSERTED.ID VALUES(@id,@streetname,@municipalityid)";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand cmdProvinces = new SqlCommand(queryProvinces, connection)) { 
           // using (SqlCommand cmdMunicipalities = new SqlCommand(queryMunicipalities, connection))
            //using (SqlCommand cmdStreets = new SqlCommand(queryStreets, connection)) {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                cmdProvinces.Transaction = transaction;
               // cmdMunicipalities.Transaction = transaction;
                //cmdStreets.Transaction = transaction;

                cmdProvinces.CommandText = queryProvinces;
                cmdProvinces.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmdProvinces.Parameters.Add(new SqlParameter("@provincename", SqlDbType.NVarChar));
                cmdProvinces.Transaction.Commit();
                connection.Close();
                //cmdMunicipalities.CommandText = queryMunicipalities;
                //cmdStreets.CommandText = queryStreets;

            }

        }



    }
}
