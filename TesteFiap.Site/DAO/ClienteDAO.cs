using System;
using System.Collections.Generic;
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

        public String ConnectionString { get; set; }
        public ClienteDAO()
        {
            ConnectionString = "Data Source=LAPTOP-TDD2C3K7\\SQLEXPRESS;Initial Catalog=dbFireSkateShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public int Delete(int ID)
        {
            int deletes = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string sql = "DELETE FROM tbCliente WHERE ID = " + ID;

                    deletes = connection.Execute(sql);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return deletes;
        }

        public List<ClienteModel> ListAll()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string sql = "SELECT * FROM tbCliente";
                    clientes = connection.Query<ClienteModel>(sql).ToList();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return clientes;
        }

        public List<ClienteModel> ListBySearch(String search)
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string sql = "SELECT * FROM tbCliente WHERE Nome LIKE '%" + search + "%' OR Email LIKE '%" + search + "%'";
                    clientes = connection.Query<ClienteModel>(sql).ToList();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return clientes;
        }

        public int Register(ClienteModel cliente)
        {
            int inserts = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    string sql = "INSERT INTO tbCliente (Nome, Email) VALUES (@Nome,@Email)";

                    inserts = connection.Execute(sql, cliente);

                    /*using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = cliente.nome;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = cliente.email;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }*/
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return inserts;
            
        }

        public void Update(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }
    }
}