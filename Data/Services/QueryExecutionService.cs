using System.Data.SqlClient;
using System.Data;


namespace ComponentsUIAPI.Data.Services
{
    public class QueryExecutionService
    {
        private readonly string _connectionString;
        private readonly Tools _tools;
        public QueryExecutionService(IConfiguration configuration, Tools tools)
        {
            _connectionString = configuration.GetConnectionString("DefaultDB");
            _tools = tools;
        }
        public DataTable DataTable(string qry)
        {
            using SqlConnection _con = new(_connectionString);
            DataTable dt = new();
            using SqlCommand cmd = new(qry, _con);
            _con.Open();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataSet DataSet(string qry)
        {
            using SqlConnection _con = new(_connectionString);
            DataSet dt = new();
            using SqlCommand cmd = new(qry, _con);
            _con.Open();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dt);
            _con.Close();
            return dt;
        }
        public string ExecuteScaler(string qry)
        {
            using SqlConnection _con = new(_connectionString);
         
            using SqlCommand cmd = new(qry, _con);
            _con.Open();
            var Result = cmd.ExecuteScalar();
            _con.Close();
            return Result.ToString();
        }
        public int QueryExecute(string qry)
        {
            using SqlConnection _con = new(_connectionString);

            using SqlCommand cmd = new(qry, _con);
            _con.Open();
            int Result = cmd.ExecuteNonQuery();

            _con.Close();
            return Result;
        }

    }
}
