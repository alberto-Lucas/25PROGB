using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMetodoFuncao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIF_Click(object sender, EventArgs e)
        {
            //Ao clicar no botão, iremos apresentar
            //a opção numerica que o usuario
            //selecionou

            string opcao;

            //Fazer a cascata de IF
            //utilizado quando podemos ter condições
            //diferentes

            //O combobox é nada mais doque um Array
            //começando posição 0
            //Ou seja cada item possui um Index = Id da posição

            //Estou pegando o Indice Selecionado do Array
            if (cbbOpcoes.SelectedIndex == 0)
                opcao = "Opção 1 Selecionada.";
            else if (cbbOpcoes.SelectedIndex == 1)
                opcao = "Opção 2 Selecionada.";
            else if (cbbOpcoes.SelectedIndex == 2)
                opcao = "Opção 3 Selecionada.";
            else if (cbbOpcoes.SelectedIndex == 3)
                opcao = "Opção 4 Selecionada.";
            else
                opcao = "Nenhuma opção selecionada";
            //Exibir o texto para o usuario
            MessageBox.Show(opcao);
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            //seguir o principio do botao IF

            //Switch é utilizado qunado possui
            //variação fixa
            //ou seja tenho uma varição de um tipo de dados

            string opcao;

            switch(cbbOpcoes.SelectedIndex)
            {
                case 0: opcao = "Opção 1 Selecionada";
                    break;
                case 1: opcao = "Opção 2 Selecionada";
                    break;
                case 2: opcao = "Opção 3 Selecionada";
                    break;
                case 3: opcao = "Opção 4 Selecionada";
                    break;
                default: opcao = "Nenuma Opção Selecionada";
                    break;
            }

            MessageBox.Show(opcao);
        }

        private void btnMetodo_Click(object sender, EventArgs e)
        {
            //Chamo o método pelo nome
            MetodoSomar();
        }

        //Como criar metodo
        //Definir o tipo de retorno
        //Metódo não possui retorno portanto
        //sera do tipo VOID
        //VOID = sem retorno

        //Void = Tipo
        //MetodoSomear = Nome do metodo
        void MetodoSomar()
        {
            //Um método vai executar um bloco de
            //código

            //Vamos definir as variaveis
            int v1, v2, resultado;

            //Atribuir o valor da campo em 
            //em cada variavel valor

            //Converter o texto em inteiro
            //definir o tipo de dado final
            //e chamar a conversão
            v1 = int.Parse(txtValor1.Text);
            v2 = int.Parse(txtValor2.Text);

            resultado = v1 + v2;

            MessageBox.Show("Resultado: " + 
                            resultado.ToString());
        }

    }
}
