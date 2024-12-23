﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Classes
{
    public class Aluno
    {
        public Aluno(int id=0, string nome=null, string email=null, string telefone=null, string senha=null, bool ativo=false)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Insert alunos values(null, '"+Nome+"','"+Email+"','"+Telefone+"',md5('"+Senha+"'),1)";
            Id=cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@identify";
            //Id = Convert.ToInt32(cmd.ExecuteScalar());

        }
        public List<Aluno> ListarAlunos(int inicio=0, int limite=0)
        {
            List<Aluno> lista = new List<Aluno>();
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            if(limite>0)
            cmd.CommandText = "select * from alunos limit "+ inicio +","+ limite;
            else
            cmd.CommandText = "select * from alunos";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Aluno(
                    Convert.ToInt32(dr.GetValue(0)),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetBoolean(5)
                    ));
            }


            return lista;
        }
        public void ConsultarPorId(int id)
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from alunos where id = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Email = dr.GetString(2);
                Telefone = dr.GetString(3);
                Senha = dr.GetString(4);
                Ativo = dr.GetBoolean(5);

            }
        }
        public static int ObterQuantidadedeRegistros()
        {
            var cmd = Banco.Abrir();
            cmd.CommandText = "select count(*) from alunos";
            return Convert.ToInt32(cmd.ExecuteScalar());      
        }
        public void Alterar(Aluno aluno)
        {
            String ativo = (aluno.Ativo) ? "1" : "0";
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update aluno set nome='"+aluno.Nome+"', telefone='"+aluno.Telefone+", senha=md5('"+aluno.Senha+"'), ativo='"+ativo+"'where id = "+aluno.Id;
            cmd.ExecuteNonQuery();
        }
    }
}

    

   

        
    


