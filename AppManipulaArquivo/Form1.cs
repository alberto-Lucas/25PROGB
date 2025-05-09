using System;
using System.IO;
using System.Windows.Forms;

namespace AppManipulaArquivo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, System.EventArgs e)
        {
            //Utilizar o componente folferBrowser
            //Iremos apresentar a tela de
            //seleção de pastas do proprio Windows
            //Precisamos coletar o resultado da tela
            DialogResult resultado
                = folderBrowserDialog1.ShowDialog();
            //Verificar se foi clicado no
            //Ok ou Cancelar
            //Se Cancelar: iremos ignorar e abortar a rotina
            //Se OK: iremos validar o diretorio selecionadio
            //Se tudo ocorrer certo, iremos apresentar
            //o diretorio selecionado no campos txtCaminho
            if(resultado == DialogResult.OK &&
               !string.IsNullOrEmpty(
                   folderBrowserDialog1.SelectedPath))
            {
                //Apresentamos o diretorio no textBox
                txtCaminho.Text = 
                    folderBrowserDialog1.SelectedPath;
            }
        }

        //Função para validar o diretorio
        bool ValidarDiretorio(
            string diretorio, string nomeArquivo)
        {
            //Validar o preenchimento dos campos
            if (string.IsNullOrEmpty(diretorio) ||
               string.IsNullOrEmpty(nomeArquivo))

            {
                MessageBox.Show(
                    "Informe um diretório e " +
                    "nome do arquivo, válidos",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                //Abortar a operação e retornar
                //false, por o diretorio não é valido
                return false;
            }

            //Validar se de fato o diretorio é valido
            if (!Directory.Exists(diretorio))
            {
                MessageBox.Show(
                    "O diretório informado não existe.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            //Se chegou até, está tudo ok
            return true;
        }

        //Função para retornar o diretorio completo
        string GetDiretorioCompleto()
        {
            //Diretorio + Nome Arquivo + Extensão
            return
                Path.Combine(
                    txtCaminho.Text,
                    txtNomeArquivo.Text + ".txt");
        }

        private void btnCriar_Click(object sender, System.EventArgs e)
        {
            //Validar os dados do diretorio
            if(!ValidarDiretorio(
                txtCaminho.Text, txtNomeArquivo.Text))
            {
                //Se não for validor aborto a rotina
                return;
            }

            //Recurperar o diretorio completo
            string caminhoCompleto =
                GetDiretorioCompleto();

            //Utilizamos o Try Catch para
            //criação do arquivo, pois caso ocorra
            //uma falha iremos tratar a mensagem
            //Principal, é a permissão da pasta
            try
            {
                //Verificar se o arquivo ja existe
                if (File.Exists(GetDiretorioCompleto()))
                {
                    //Notificar o usuario
                    MessageBox.Show(
                        "O arquivo já existe.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return; //abortar a rotina
                }

                //se chegou até aqui, podemos criar o arquivo
                //Iremos criar um arquivo vazio
                File.WriteAllText(caminhoCompleto, "");
                //Apos criado iremos notificar o usuario
                MessageBox.Show(
                    "Arquivo criado com sucesso.",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information); 
            }
            //Exception para extrair o motivo do erro
            catch (Exception ex)
            {
                //Caso ocorra uma falha, iremos
                //notificar o usuario
                //Só iremos notificar se ocorrer
                //algum erro na execução da rotina
                MessageBox.Show(
                    "Falha ao criar o arquivo." +
                    Environment.NewLine + //Quebrar a linha
                    "Erro original: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
