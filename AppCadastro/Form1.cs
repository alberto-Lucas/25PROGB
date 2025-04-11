﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadCliente_Click(object sender, EventArgs e)
        {
            //Primeiro devemos
            //instanciar a tela em memoria
            //Precisar criar uma variavel
            //como mesmo tipo da tela
            //para ser o ponteiro
            //frmCadCliente é o tipo de dado
            //tela é a variavel ponteiro
            //new palavra reservada 
            //para instanciar algo em memoria
            //frmCadCliente() é a tela em si
            frmCadCliente tela =
                new frmCadCliente();

            //Aqui a tela de cadastro de cliente
            //ja esta em memoria
            //precisamos exibir ela
            //Show() ira abrir a tela de maneira
            //independente
            //ShowDialog() ira abrir a tela
            //sobrepondo a anterior
            //bloqueando a tela q estiver atras

            //tela.Show();
            tela.ShowDialog();  
        }
    }
}
