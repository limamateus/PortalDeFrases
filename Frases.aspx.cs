using Portal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Frases : System.Web.UI.Page
    {

        DALFrase dal = new DALFrase();
        Model.Frase frase = new Model.Frase();
        DALAutor dalAutor = new DALAutor();
        DALCategoria dalCategoria = new DALCategoria();

        string msg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            AtulizarGrid();

            if (!IsPostBack)
            {
                AtulizarAutor();
                AtulizarCategoria();
            }
            
        }

        public void AtulizarGrid()
        {
            GridView1.DataSource = dal.Localizar();
            GridView1.DataBind();
        }

        public void AtulizarAutor()
        {
            ddlAutor.DataSource = dalAutor.Localizar();
            ddlAutor.DataTextField = "nome";
            ddlAutor.DataValueField = "id";
            ddlAutor.DataBind();
        }

        public void AtulizarCategoria()
        {
            ddlCategoria.DataSource = dalCategoria.Localizar();
            ddlCategoria.DataTextField = "categoria";
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
        }

        public void LimparCampos()
        {
            txtId.Text = "";
            txtTexto.Text = "";
            btnSalvarOuAtualizar.Text = "Salvar";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void btnSalvarOuAtualizar_Click(object sender, EventArgs e)
        {
            frase.Texto = txtTexto.Text;
            frase.Categoria = Convert.ToInt32(ddlCategoria.SelectedValue);
            frase.Autor = Convert.ToInt32(ddlAutor.SelectedValue);

          

            try
            {
               if(btnSalvarOuAtualizar.Text == "Salvar")
                {
                    dal.Inserir(frase);
                    msg = "<script> alert('Frase Cadastrada com sucesso');</script>";
                }
                else
                {
                    frase.Id = Convert.ToInt32(txtId.Text);
                    dal.Alterar(frase);
                    msg = "<script> alert('Frase Alterado com sucesso');</script>";
                }
                AtulizarGrid();
                Response.Write(msg);
                LimparCampos();

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GridView1.SelectedIndex;
                int cod = Convert.ToInt32(GridView1.Rows[index].Cells[2].Text);

               frase = dal.GetRegistro(cod);
                if(frase.Id != 0)
                {
                    txtId.Text = frase.Id.ToString();
                    txtTexto.Text = frase.Texto;
                    btnSalvarOuAtualizar.Text = "Alterar";
                    ddlAutor.SelectedValue = frase.Autor.ToString();
                    ddlCategoria.SelectedValue = frase.Categoria.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = GridView1.SelectedIndex;
            int cod = Convert.ToInt32(GridView1.Rows[index].Cells[2].Text);

            dal.Excluir(cod);
            AtulizarGrid();
        }
    }
}