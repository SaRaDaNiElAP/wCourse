using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/// <summary>
/// Fecha: 9 de Mayo 2022
/// Autores: Natalia Úsuga Manco, Sara Daniela Parra, Maicol Arroyave 
/// Descripción: Proyecto de carga de archivo
/// </summary>

namespace wCourse
{
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            cmbRH.Items.Add("A+");
            cmbRH.Items.Add("A-");
            cmbRH.Items.Add("B+");
            cmbRH.Items.Add("B-");
            cmbRH.Items.Add("AB+");
            cmbRH.Items.Add("AB-");
            cmbRH.Items.Add("O+");
            cmbRH.Items.Add("O-");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var Course = new clsPerson();
                Course.Nombre = txtNombre.Text;
                Course.Apellido = txtApellido.Text;
                Course.Direccion = txtDireccion.Text;
                Course.Telefono = txtTelefono.Text;
                Course.Ciudad = txtCiudad.Text;
                Course.Comuna = txtComuna.Text;
                Course.RH = cmbRH.Text;

                DialogResult Guardar = MessageBox.Show($"Nombre: {Course.Nombre} \r\nApellido: {Course.Apellido} \r\nDirección: {Course.Direccion}" +
                    $"\r\nTelefono: {Course.Telefono} \r\nCiudad: {Course.Ciudad} \r\nComuna: {Course.Comuna} \r\nRH: {Course.RH}", "Información", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private Stream myStream;
        int counter = 0;
        string Line;
        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Cod Curso";
            col1.Width = 200;
            col1.ReadOnly = true;
            dtgCSV.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Nombre Curso";
            col2.Width = 200;
            col2.ReadOnly = true;
            dtgCSV.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Categoría Curso";
            col3.Width = 200;
            col3.ReadOnly = true;
            dtgCSV.Columns.Add(col3);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Tema";
            col4.Width = 200;
            col4.ReadOnly = true;
            dtgCSV.Columns.Add(col4);

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Observaciones";
            col5.Width = 200;
            col5.ReadOnly = true;
            dtgCSV.Columns.Add(col5);

            char delimitador = ';';
            string[] valores;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos (*.CSV) | *.CSV";

            if ((openFileDialog.ShowDialog()) == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);

                        while ((Line = file.ReadLine()) != null)
                        {
                            if (counter >= 1)
                            {
                                valores = Line.Split(delimitador);

                                dtgCSV.Rows.Add(valores.ToArray());
                                counter++;
                            }
                            else
                            {
                                counter++;
                            }
                        }

                        file.Close();

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmCourse_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Salir = MessageBox.Show("¿Realmente desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            e.Cancel = (Salir == DialogResult.No);
        }
    }
}
