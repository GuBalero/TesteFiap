using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using TesteFiap.Site.Models;

namespace TesteFiap.Site.DAO
{
    public class ClienteDAO
    {
        public void Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString()))
            {
                string sql = "DELETE FROM tbCliente WHERE ID = " + ID;

                int inserts = connection.Execute(sql);
            }
        }

        public List<ClienteModel> ListAll()
        {
            List<ClienteModel> clientes;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString()))
            {
                string sql = "SELECT * FROM tbCliente";
                clientes = connection.Query<ClienteModel>(sql).ToList();
            }

            return clientes;
        }

        public List<ClienteModel> ListBySearch(String search)
        {
            List<ClienteModel> clientes;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString()))
            {
                string sql = "SELECT * FROM tbCliente WHERE Nome LIKE '%"+search+"%' OR Email LIKE '%"+search+"%'";
                clientes = connection.Query<ClienteModel>(sql).ToList();
            }

            return clientes;
        }

        public void Register(ClienteModel cliente)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString()))
                {
                    string sql = "INSERT INTO tbCliente (Nome, Email) VALUES (@Nome,@Email)";

                    int inserts = connection.Execute(sql, cliente);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        public void Update(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }
    }
}