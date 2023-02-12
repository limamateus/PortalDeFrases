using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Portal.DAL
{
    public class DALFrase
    {


        private System.Configuration.ConnectionStringSettings connString;

        public DALFrase()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");

            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
        }


        public void Inserir(Model.Frase obj)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            try
            {
                cmd.CommandText = "Insert into frases (frase,autor,categoria) values (@frase,@autor,@categoria);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("frase", obj.Texto);
                cmd.Parameters.AddWithValue("autor", obj.Autor);
                cmd.Parameters.AddWithValue("categoria", obj.Categoria);
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


        public void Alterar(Model.Frase obj)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "update frases set frase =@frase, autor =@autor, categoria = @categoria where id =@id;";
                cmd.Parameters.AddWithValue("frase", obj.Texto);
                cmd.Parameters.AddWithValue("autor", obj.Autor);
                cmd.Parameters.AddWithValue("categoria", obj.Categoria);
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
                cmd.CommandText = "delete from frases where id " + id.ToString();
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

                string sql = "Select f.id, f.frase, f.autor, f.categoria, a.nome as autornome, c.categoria as categorianome " +
                             "from Frases f inner join autores a on f.id = a.id " +
                             "inner join categorias c on f.id = c.id ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connString.ConnectionString);
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
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from frases where autores like '%' " + valor + "'%'", connString.ConnectionString);
                adapter.Fill(tabela);

                return tabela;


            }
            catch (Exception)
            {

                throw;
            }

        }


        public Model.Frase GetRegistro(int id)
        {

            Model.Frase obj = new Model.Frase();


            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "Select * from frases where id =@id";
                cmd.Parameters.AddWithValue("id", id);
                con.Open();


                SqlDataReader xRegistro = cmd.ExecuteReader();


                if (xRegistro.HasRows)
                {
                    xRegistro.Read();

                    obj.Id = Convert.ToInt32(xRegistro["id"]);
                    obj.Texto = Convert.ToString(xRegistro["frase"]);
                    obj.Autor = Convert.ToInt32(xRegistro["autor"]);
                    obj.Categoria = Convert.ToInt32(xRegistro["categoria"]);
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