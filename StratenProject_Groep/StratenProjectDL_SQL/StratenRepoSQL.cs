using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StratenProjectDL_SQL {
    public class StratenRepoSQL {

        string connectionstring;

        public StratenRepoSQL(string connectionstring) {
            //this.connectionstring = connectionstring;

            //TIJDELIJK:
            //Verander in onderstaande connectiestring de naam van de data source naar jouw eigen
            this.connectionstring = @"Data Source=LAPTOP-518B66FM\\SQLEXPRESS;Initial Catalog=StratenProject;Integrated Security=True;Trust Server Certificate=True";
        }



    }
}
