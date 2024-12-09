﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace Mantenimiento_1
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();

        void mantenimiento(String accion)
        {
            objent.id = Convert.ToInt32(txtcodigo.Text);
            objent.nombre = txtnombre.Text;
            objent.apellido = txtapellido.Text;
            objent.fechacontratacion = Convert.ToDateTime(txtcontratacion.Text);
            objent.salario = Convert.ToDecimal(txtsalario.Text);
            objent.accion = accion;
            String men = objneg.N_mantenimiento_Empleados(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void limpiar()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcontratacion.Text = "";
            txtsalario.Text = "";
            txtbuscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_empleados();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_empleados();
        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a  " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    mantenimiento("1");
                limpiar();
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a  " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    mantenimiento("3");
                limpiar();
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                objent.nombre = txtbuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_Empleados(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_empleados();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtcodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtnombre.Text = dataGridView1[1, fila].Value.ToString();
            txtapellido.Text = dataGridView1[2, fila].Value.ToString();
            txtcontratacion.Text = dataGridView1[3, fila].Value.ToString();
            txtsalario.Text = dataGridView1[4, fila].Value.ToString();

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}

