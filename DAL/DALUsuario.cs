using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Portal.DAL
{
    public class DALUsuario
    {
        private System.Configuration.ConnectionStringSettings connString;


        public DALUsuario()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");

            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
        }


        public void Inserir(Model.Usuario obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "Insert into usuarios (nome,email,senha) values (@nome,@email,@senha);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", obj.Nome);
                cmd.Parameters.AddWithValue("email", obj.Email);
                cmd.Parameters.AddWithValue("senha", obj.Senha);

                con.Open();
                obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Alterar(Model.Usuario obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "update usuarios set nome = @nome, email =@email where id =@id;";
                cmd.Parameters.AddWithValue("nome", obj.Nome);
                cmd.Parameters.AddWithValue("email", obj.Email);
                cmd.Parameters.AddWithValue("id", obj.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Excluir(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "delete from usuarios where id = " + id.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Localizar()
        {
            try
            {
                DataTable tabela = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter("Select * from usuarios", connString.ConnectionString);

                adapter.Fill(tabela);

                return tabela;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public DataTable Localizar(string valor)
        {
            try
            {

                DataTable tabela = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter("Select * from usuarios where usuario like '%'" + valor + "'%'", connString.ConnectionString);

                adapter.Fill(tabela);

                return tabela;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Model.Usuario GetRegistro(int id)
        {
            Model.Usuario obj = new Model.Usuario();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "Select * from usuarios where id =@id";
                cmd.Parameters.AddWithValue("id", id);
                con.Open();

                SqlDataReader xRegistro = cmd.ExecuteReader();

                if (xRegistro.HasRows)
                {
                    xRegistro.Read();
                    obj.Id = Convert.ToInt32(xRegistro["id"]);
                    obj.Nome = Convert.ToString(xRegistro["nome"]);
                    obj.Email = Convert.ToString(xRegistro["email"]);

                }

                con.Close();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return obj;

        } 
        
        public Model.Usuario GetRegistro(string xEmail)
        {
            Model.Usuario obj = new Model.Usuario();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "Select * from usuarios where email =@email";
                cmd.Parameters.AddWithValue("email", xEmail);
                con.Open();

                SqlDataReader xRegistro = cmd.ExecuteReader();

                if (xRegistro.HasRows)
                {
                    xRegistro.Read();
                    obj.Id = Convert.ToInt32(xRegistro["id"]);
                    obj.Nome = Convert.ToString(xRegistro["nome"]);
                    obj.Email = Convert.ToString(xRegistro["email"]);
                    obj.Senha = Convert.ToString(xRegistro["senha"]);

                }

                con.Close();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return obj;

        }

    }
}