using Portal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Portal.DAL
{
    public class DALCategoria
    {
        private System.Configuration.ConnectionStringSettings connString;

        public DALCategoria()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");

            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
        }
        public void Inserir(Model.Categoria obj)
        {

            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {

                cmd.CommandText = "Insert into categorias (categoria) values (@categoria);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("categoria", obj.Nome);

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

        public void Alterar(Model.Categoria obj)
        {
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {

                cmd.CommandText = "update categorias set categoria = @categoria where id = @id;";
                cmd.Parameters.AddWithValue("categoria", obj.Nome);
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
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {

                cmd.CommandText = "delete from categorias where id = " + id.ToString();
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

                SqlDataAdapter adapter = new SqlDataAdapter("Select * From categorias", connString.ConnectionString);

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

                SqlDataAdapter adapter = new SqlDataAdapter("Select * From categorias where categoria  like '%" + valor + "'%'" , connString.ConnectionString);

                adapter.Fill(tabela);

                return tabela;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }
        public Model.Categoria GetRegistro(int id)
        {
            Model.Categoria obj = new Model.Categoria();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "select * from categorias  where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.Id = Convert.ToInt32(registro["id"]);
                    obj.Nome = Convert.ToString(registro["categoria"]);

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