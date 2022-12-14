using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _211077.Models;

namespace _211077.Views
{
    public partial class FrmCategorias : Form
    {
        Categoria c;
        public FrmCategorias()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtCategorias.Clear();
            txtPesquisa.Clear();
        
        }

        void carregarGrid(string pesquisa)
        {
            c = new Categoria()
            {
                categoria = pesquisa
            };
            dgvCategorias.DataSource = c.consultar();


        }

        
        private void btnIncluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCategorias.Text == String.Empty) return;

                c = new Categoria()
                {
                    categoria = txtCategorias.Text

                };
                c.insert();

                limpaControles();
                carregarGrid("");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategorias_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCategorias.RowCount > 0)
                {
                    txtID.Text = dgvCategorias.CurrentRow.Cells["id"].Value.ToString();
                    txtCategorias.Text = dgvCategorias.CurrentRow.Cells["categoria"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == String.Empty) return;

                if (MessageBox.Show("Deseja mesmo excluir essa categoria do registro?", "Excluir?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    c = new Categoria()
                    {
                        id = int.Parse(txtID.Text),
                    };
                    c.delete();

                    limpaControles();
                    carregarGrid("");
                }

                MessageBox.Show("Categoria excluida com sucesso!", "Operação bem sucedida!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
            dgvCategorias.SelectedRows.Equals(0);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == String.Empty) return;

                c = new Categoria()
                {
                    id = int.Parse(txtID.Text),
                    categoria = txtCategorias.Text
                };
                c.update();

                limpaControles();
                carregarGrid("");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }
    }
}
