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
                0,txtNome.Text,txtEmail.Text,txtTelefone.Text,txtSenha.Text,true
                );
            aluno.Inserir();
            txtId.Text = aluno.Id.ToString();
            MessageBox.Show("Aluno inserido com sucesso!");
            LimparCampos();
            
        }

        private void LimparCampos()
        {
            txtNome.Clear(); txtEmail.Clear(); txtTelefone.Clear(); txtSenha.Clear(); txtConfirmaSenha.Clear(); chkAtivo.Checked = false; txtId.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();
            Aluno aluno = new Aluno(0);
            var lista = aluno.ListarAlunos();
            lista.ForEach(a =>{
                dgvLista.Rows.Add();
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnId.Index].Value = a.Id;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnNome.Index].Value = a.Nome;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnEmail.Index].Value = a.Email;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnTelefone.Index].Value = a.Telefone;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnAtivo.Index].Value = a.Ativo;
            });
                
            
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = (decimal)Aluno.ObterQuantidadedeRegistros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();
            Aluno aluno = new Aluno(0);
            var lista = aluno.ListarAlunos(0,(int)numericUpDown1.Value);
            lista.ForEach(a => {
                dgvLista.Rows.Add();
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnId.Index].Value = a.Id;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnNome.Index].Value = a.Nome;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnEmail.Index].Value = a.Email;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnTelefone.Index].Value = a.Telefone;
                dgvLista.Rows[lista.IndexOf(a)].Cells[clnAtivo.Index].Value = a.Ativo;
            });
        }
    }
}
    