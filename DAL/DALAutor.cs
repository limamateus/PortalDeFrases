using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Portal.DAL
{
    public class DALAutor
    {

        private System.Configuration.ConnectionStringSettings connString;

        public DALAutor()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");

            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
        }


        public void Inserir(Model.Autor obj)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            try
            {
                cmd.CommandText = "Insert into autores (nome,foto) values (@nome,@foto);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", obj.Nome);
                cmd.Parameters.AddWithValue("foto", obj.Foto);
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


        public void Alterar(Model.Autor obj)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "update autores set nome =@nome, foto =@foto where id =@id;";
                cmd.Parameters.AddWithValue("nome", obj.Nome);
                cmd.Parameters.AddWithValue("foto", obj.Foto);
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
                cmd.CommandText = "delete from autores where id = " + id.ToString();
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
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from autores", connString.ConnectionString);
                adapter.Fill(tabela);

                return tabela;


            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataTable Localizar(string valor)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from autores where autores like '%' " + valor + "'%'", connString.ConnectionString);
                adapter.Fill(tabela);

                return tabela;


            }
            catch (Exception)
            {

                throw;
            }

        }


        public Model.Autor GetRegistro(int id)
        {

            Model.Autor obj = new Model.Autor();


            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "Select * from autores where id =@id";
                cmd.Parameters.AddWithValue("id", id);
                con.Open();


                SqlDataReader xRegistro = cmd.ExecuteReader();


                if (xRegistro.HasRows)
                {
                    xRegistro.Read();

                    obj.Id = Convert.ToInt32(xRegistro["id"]);
                    obj.Nome = Convert.ToString(xRegistro["nome"]);
                    obj.Foto = Convert.ToString(xRegistro["foto"]);
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