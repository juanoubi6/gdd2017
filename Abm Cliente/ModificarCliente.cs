﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class ModificarCliente : Form
    {
        private Cliente clienteAModificar;

        public ModificarCliente(Cliente cliente)
        {
            InitializeComponent();
            this.clienteAModificar = cliente;
        }
    }
}