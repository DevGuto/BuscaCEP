using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaCEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskCEP_Leave(object sender, EventArgs e)
        {
            BuscarCEP(mskCEP.Text);
        }

        async Task BuscarCEP (string cep)
        {

            try
            {
                var cepBuscar = RestService.For<ICepApiService>("https://viacep.com.br/");
                var endereco = await cepBuscar.GetAddressAsync(cep);
               
                txtLogradouro.Text = endereco.Logradouro;
                txtBairro.Text = endereco.Bairro;
                txtMunicipio.Text = endereco.Localidade;
                txtEstado.Text = endereco.Uf;

            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: \n" + e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            mskCEP.Text = "";
            txtBairro.Text = "";
            txtComplemento.Text = "";
        }
    }
}
