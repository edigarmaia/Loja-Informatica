using LojaInformatica.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.Repositorio
{
    public class Acoes
    {
        //Ação do método TestarUsuario
        public Usuario TestarUsuario(Usuario user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbUsuario where NomeUsuario=@user and SenhaUsuario=@senha", con.MyConectarBD());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user.NomeUsuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = user.SenhaUsuario;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Usuario dto = new Usuario();
                    {
                        dto.NomeUsuario = Convert.ToString(leitor["NomeUsuario"]);
                        dto.SenhaUsuario = Convert.ToString(leitor["SenhaUsuario"]);
                    }
                }
            }
            else
            {
                user.NomeUsuario = null;
                user.SenhaUsuario = null;
            }
            return user;
        }
    }
}