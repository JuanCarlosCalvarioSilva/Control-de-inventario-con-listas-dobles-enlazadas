﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario
{
    public partial class frmprincipal : Form
    {
        public frmprincipal()
        {
            InitializeComponent();
        }

        Inventario inventario = new Inventario();
        Producto nuevoProducto; 

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Busqueda por código
            Producto x = inventario.buscar(int.Parse(txtCodigo.Text));
            if (x == null)
            {
                MessageBox.Show("No se encontro ningun registro con ese código");
                txtNombre.Text = "";
                txtCantidad.Text = "";
                txtCosto.Text = "";
            }                
            else
            {
                txtCodigo.Text = x.codigo.ToString();
                txtNombre.Text = x.nombre.ToString();
                txtCantidad.Text = x.cantidad.ToString();
                txtCosto.Text = x.costo.ToString();
            }                                    
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agrega producto
            nuevoProducto = new Producto();

            if (txtCodigo.Text == "" || txtNombre.Text ==""|| txtCantidad.Text ==""|| txtCosto.Text == "")
                MessageBox.Show("Llenar todos los campos");
            else
            {
                nuevoProducto.codigo = int.Parse(txtCodigo.Text);
                nuevoProducto.nombre = txtNombre.Text;
                nuevoProducto.cantidad = int.Parse(txtCantidad.Text);
                nuevoProducto.costo = int.Parse(txtCosto.Text);

                inventario.agregar(nuevoProducto);

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtCantidad.Text = "";
                txtCosto.Text = "";
            }                          
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Elimina producto
            inventario.borrar(int.Parse(txtCodigo.Text));
            txtCodigo.Text = "";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Inserta producto en posicion indicada
            nuevoProducto = new Producto();
            nuevoProducto.codigo = int.Parse(txtCodigo.Text);
            nuevoProducto.nombre = txtNombre.Text;
            nuevoProducto.cantidad = int.Parse(txtCantidad.Text);
            nuevoProducto.costo = int.Parse(txtCosto.Text);

            inventario.insertar(nuevoProducto,int.Parse(txtPosicion.Text));
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtCosto.Text = "";
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //Reporte
            txtReporte.Text = inventario.reporte();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nuevoProducto = new Producto();

            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtCantidad.Text == "" || txtCosto.Text == "")
                MessageBox.Show("Llenar todos los campos");
            else
            {
                nuevoProducto.codigo = int.Parse(txtCodigo.Text);
                nuevoProducto.nombre = txtNombre.Text;
                nuevoProducto.cantidad = int.Parse(txtCantidad.Text);
                nuevoProducto.costo = int.Parse(txtCosto.Text);

                inventario.AgregarEnInicio(nuevoProducto);

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtCantidad.Text = "";
                txtCosto.Text = "";
            }           
        }

        private void btnReporteInverso_Click(object sender, EventArgs e)
        {
            //Reporte inverso
            txtReporte.Text = inventario.reporteInv();
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            //elimina el ultimo elemento
            inventario.eliminarUltimo();
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            //elimina el primer elemento
            inventario.eliminarPrimero();
        }
    }
}
