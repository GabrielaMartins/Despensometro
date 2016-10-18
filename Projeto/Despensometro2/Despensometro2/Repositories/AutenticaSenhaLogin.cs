using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Despensometro2.Models;
using System.Data.Entity;

namespace Despensometro2.Repositories
{
    public class AutenticaSenhaLogin
    {
        private despensometroEntities db;
        private string senha;
        private string login;

        public AutenticaSenhaLogin(string senha, string login)
        {
            db = new despensometroEntities();
            this.senha = senha;
            this.login = login;
        }

        public AutenticaSenhaLogin(string login)
        {
            db = new despensometroEntities();
            this.login = login;
        }

        public usuario Autentica(){

            usuario u = db.usuario.Where(obj => obj.senha.Equals(senha) && obj.login_usuario.Equals(login)).SingleOrDefault();

            return u;
        }
        
        //verifica se o login já existe
        public Boolean verificaLogin()
        {
            usuario u = db.usuario.Where(obj => obj.login_usuario == login).SingleOrDefault();

            if (u == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

   
}