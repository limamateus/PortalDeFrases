using Portal.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class PageAutor : System.Web.UI.Page
    {

        Model.Autor obj = new Model.Autor();
        DALAutor dal = new DALAutor();

        string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }



        public void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            btnAdd.Text = "Salvar";

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            obj.Nome = txtNome.Text;
            


            try
            {   // Para salvar uma fot
                string xCaminho = Server.MapPath(@"Imagens\Autores\");
                if(fuFoto.PostedFile.FileName != "")
                {
                    obj.Foto = fuFoto.PostedFile.FileName;
                    string img = xCaminho + obj.Foto;
                    fuFoto.PostedFile.SaveAs(img);

                }

                if(btnAdd.Text == "Salvar")
                {
                   
                    dal.Inserir(obj);

                    msg = $"<script> ShowMsg('Cadastro','o autor {obj.Nome} " + "foi cadastrado com sucesso ');</script>";
                }
                else
                {
                  
                    obj.Id = Convert.ToInt32(txtId.Text);
                    // Verificar se existe uma foto e deletar.
                    Model.Autor autor = dal.GetRegistro(obj.Id);

                    if(autor.Foto != "")
                    {
                        File.Delete(xCaminho + obj.Foto);
                    }

                    dal.Alterar(obj);
                  
                    msg = $"<script> alert('o autor {obj.Nome} " + "foi atualizado com sucesso ');</script>";
                }
                AtualizarGrid();
                Response.Write(msg);
                LimparCampos();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void AtualizarGrid()
        {
            DALAutor dal = new DALAutor();

            GridView1.DataSource = dal.Localizar();

            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int xIndex = GridView1.SelectedIndex;

            int xId = Convert.ToInt32(GridView1.Rows[xIndex].Cells[2].Text);

            try
            {
                obj = dal.GetRegistro(xId);

                if(obj.Id != 0)
                {
                    txtId.Text = obj.Id.ToString();
                    txtNome.Text = obj.Nome;                    
                    btnAdd.Text = "Atualizar";
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);

            int id = Convert.ToInt32(GridView1.Rows[index].Cells[2].Text);

            try
            {

                Model.Autor autor = dal.GetRegistro(id);
                string xCaminho = Server.MapPath(@"Imagens\Autores\");
                if (autor.Foto != "")
                {
                    File.Delete(xCaminho + autor.Foto);
                }

                dal.Excluir(id);
                AtualizarGrid();
            }
            catch (Exception erro)
            {

                Response.Write("<script> alert(' " + erro.Message + "');</script>");
            }
        }
    }
}