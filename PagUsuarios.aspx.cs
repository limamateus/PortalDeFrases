using Portal.DAL;
using Portal.Validacoes_Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class PagUsuarios : System.Web.UI.Page
    {
        Model.Usuario xUsuario = new Model.Usuario();
        ValidacoesFront validacoesFront = new ValidacoesFront();
        DALUsuario dal = new DALUsuario();
        string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        public void LimparCampos()
        {
            txtId.Text = "";
            txtEmail.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";

            btnSalvarOuAtualizar.Text = "Salvar";

        }
        protected void btnSalvarOuAtualizar_Click(object sender, EventArgs e)
        {
            xUsuario.Nome = txtNome.Text;
            xUsuario.Email = txtEmail.Text;

            try
            {
                var validarEmail = dal.GetRegistro(txtEmail.Text);

                if (btnSalvarOuAtualizar.Text == "Salvar")
                {
                   

                    xUsuario.Senha = txtSenha.Text;
                   

                    if (validarEmail.Id != 0)
                    {
                        msg = "<script> alert('Email já cadastrado');</script>";

                    }
                    else
                    {
                        dal.Inserir(xUsuario);
                        msg = "<script> alert('O codigo gerado foi " + xUsuario.Id.ToString() + " | " + xUsuario.Nome + "');</script>";
                        LimparCampos();
                    }


                }
                else
                {
                    xUsuario.Id = Convert.ToInt32(txtId.Text);
                    bool xFlag = true;

                    if(validarEmail.Id != 0 && validarEmail.Id != xUsuario.Id)
                    {
                        xFlag = false;
                        msg = "<script> alert('Email já cadastrado');</script>";
                    }
                    else
                    {
                        dal.Alterar(xUsuario);

                        msg = "<script> alert('Registro alterado corretamente');</script>";
                        LimparCampos();
                    }


                   
                }
                AtualizarGrid();
                Response.Write(msg);
               
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }

        }


        public void AtualizarGrid()
        {
            DALUsuario dal = new DALUsuario();

            gridUsuarios.DataSource = dal.Localizar();

            gridUsuarios.DataBind();
        }

        protected void gridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int xIndex = gridUsuarios.SelectedIndex;

            int xId = Convert.ToInt32(gridUsuarios.Rows[xIndex].Cells[2].Text);

            try
            {
                xUsuario = dal.GetRegistro(xId);

                if (xUsuario.Id != 0)
                {
                    txtId.Text = xUsuario.Id.ToString();
                    txtNome.Text = xUsuario.Nome;
                    txtEmail.Text = xUsuario.Email;
                    txtSenha.Enabled = false;
                    btnSalvarOuAtualizar.Text = "Atualizar";

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void gridUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);

            int id = Convert.ToInt32(gridUsuarios.Rows[index].Cells[2].Text);

            try
            {
                dal.Excluir(id);
                AtualizarGrid();
            }
            catch (Exception erro)
            {

                Response.Write("<script> alert(' " + erro.Message + "');</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }



    }
}