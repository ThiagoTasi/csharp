using csharp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(
                txtNome.Text,txtEmail.Text,txtTelefone.Text,txtSenha.Text,true
                );
            aluno.Inserir();
            txtId.Text = aluno.Id.ToString();
            MessageBox.Show("Aluno inserido com sucesso!");
            txtNome.Clear();txtEmail.Clear();txtTelefone.Clear();txtSenha.Clear();txtConfirmaSenha.Clear();chkAtivo.Checked = false;txtId.Clear();   
            
        }
    }
}
