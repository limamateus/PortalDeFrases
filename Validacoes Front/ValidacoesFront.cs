using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Portal.Validacoes_Front
{
    public class ValidacoesFront
    {

        public  bool ValidarEmail(string xEmail)
        {
            try
            {
                var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var match = regex.Match(xEmail);
                return match.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool ValidarTelefone(string xNumero)
        {
            try
            {
                var regex = new Regex(@"^\d{10,15}$");
                var match = regex.Match(xNumero);
                return match.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}