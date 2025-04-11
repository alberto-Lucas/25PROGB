using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCadastro
{
    public partial class frmCadCliente : Form
    {
        public frmCadCliente()
        {
            InitializeComponent();
            //Desativar a validação automatica
            AutoValidate = AutoValidate.Disable;
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            //Aqui que vamos definir a validação
            //do campo
            //Validar se o campos esta preenchido
            if(string.IsNullOrEmpty(txtNome.Text))
            {
                //Aqui vamos cancelar a ação da tela
                //Marca q a ação sera cancelada
                //e é a nossa ação
                e.Cancel = true;
                //Defino uma mensagem para o usuario
                errErro.SetError(
                    txtNome,
                    "Preencha o nome.");
            }
            else
            {
                //Se estiver tudo ok
                //precisamos cancelar o cancelamento
                //e remover a mensagem
                e.Cancel= false;
                errErro.SetError(
                    txtNome, "");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Vamos dispara a validação dos campos
            //ValidateChildren scaneia
            //os campos da tela
            //ValidationConstraints identifica os problema
            //Enabled retorna true, qunado estiver tudo ok
            if (ValidateChildren(
                ValidationConstraints.Enabled))
            {
                MessageBox.Show(
                    "Registro salvo com sucesso.",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                //Caso ocorreu algum problema
                //Iremos notificar o usuário
                //e disparar o icones de erro
                MessageBox.Show(
                    "É necessário preencher todos " + 
                    "campos corretamente.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        //Criar a função para retornar
        //somente numeros de uma string
        string SoNumero(string pTexto)
        {
            string retorno = "";

            for(int i = 0; i < pTexto.Length; i++)
                if (char.IsNumber(pTexto[i]))
                    retorno += pTexto[i];
            return retorno;
        }

        private void mskCPF_Validating(object sender, CancelEventArgs e)
        {
            //Removo a mascara do CPF
            string CPF = SoNumero(mskCPF.Text);

            //Agora podemos realizar as 
            //validações
            if(string.IsNullOrEmpty(CPF))
            {
                e.Cancel = true;
                errErro.SetError(
                    mskCPF,
                    "Preencha o CPF.");
            }
            else if(CPF.Length != 11)
            {
                e.Cancel = true;
                errErro.SetError(
                    mskCPF,
                    "Preencha o CPF corretamente.");
            }
            else
            {
                e.Cancel = false;
                errErro.SetError(
                    mskCPF,
                    "");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Apresentar uma mensagem 
            //de SIM ou Não, para o usuario
            //Confirmar o cancelamento
            //Precisamos configurar o MessageBox
            //MessageBoxButtons.YesNo defino q sera
            //uma mensagem de sim ou não
            //Definir o botão padrão q recebera o 
            //foco
            //MessageBoxDefaultButton.Button2
            //defino o botão NÃO como padrão
            //Para coleta o retorno da tela
            //Utilizo o DialogResult
            //Se o usuario clicar em SIM
            //fecho a tela
            if(MessageBox.Show(
                "Deseja realmente descartar "+
                "as alterações?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
