using Portal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Categoria : System.Web.UI.Page
    {
        string msg = "";
        Model.Categoria obj = new Model.Categoria();
        DALCategoria dal = new DALCategoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }


        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            btnAdd.Text = "Inserir";

        }

        public void AtualizaGrid()
        {// Estacio  minha class de comunicação com banco especifico
            DALCategoria dal = new DALCategoria();
            // Passo para minha GridView os dados que estão no banco            
            GridView1.DataSource = dal.Localizar();
            // e carrego;
            GridView1.DataBind();


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
           

            obj.Nome = txtNome.Text;

            try
            {
                if (btnAdd.Text == "Inserir")
                {
                    // Inserir

                    dal.Inserir(obj);

                    msg = "<script> ShowMsg('Cadastro','O codigo gerado foi " + obj.Id.ToString() + "');</script>";


                }
                else
                {
                    // Alterar
                    obj.Id = Convert.ToInt32(txtId.Text);
                    dal.Alterar(obj);
                    msg = "<script> ShowMsg('Cadastro','Registro alterado corretamente ');</script>";
                    AtualizaGrid();

                }
                AtualizaGrid();

                //  Response.Write(msg);
                PH1.Controls.Add(new LiteralControl(msg));
                this.LimparCampos();
            }
            catch (Exception erro)
            {

                 msg ="<script> alert(' " + erro.Message + "');</script>";
                 PH1.Controls.Add(new LiteralControl(msg));

            }

           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);

            int Id = Convert.ToInt32(GridView1.Rows[index].Cells[2].Text);
            try
            {
                dal.Excluir(Id);

                AtualizaGrid();

            }
            catch (Exception erro)
            {

                Response.Write("<script> alert(' " + erro.Message + "');</script>");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int xIndex = GridView1.SelectedIndex; // Passo o index selecionado para uma variavel local

            int xId = Convert.ToInt32(GridView1.Rows[xIndex].Cells[2].Text); // Converto o campo de para intero

            try
            {
               Model.Categoria categoria = dal.GetRegistro(xId);

                if(categoria.Id !=0)
                {
                    txtId.Text = categoria.Id.ToString();

                    txtNome.Text = categoria.Nome;

                    btnAdd.Text = "Alterar";


                }

               

              


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}