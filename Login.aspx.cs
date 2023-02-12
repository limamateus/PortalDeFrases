using Portal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Login : System.Web.UI.Page
    {
        DALUsuario dal = new DALUsuario();
        Model.Usuario xUsuario = new Model.Usuario();
        string msg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnEntra_Click(object sender, EventArgs e)
        {
            string email = txtLogin.Text;
            string senha = txtSenha.Text;

            try
            {
                var validarLogin = dal.GetRegistro(email);

                if(validarLogin.Email == email && validarLogin.Senha == senha)
                {
                    Session["id"] = validarLogin.Id;
                    Session["nome"] = validarLogin.Nome;
                    Session["email"] = validarLogin.Email;
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    msg ="<script> alert('Não foi possivel localizar sua conta, verifique o e-mail e a senha digitado');</script>";
                    Response.Write(msg);

                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}