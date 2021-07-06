using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Matrix
{
    public partial class Form1 : Form
    {
        public int r1, r2, c1, c2, a, b, c;
        Creator mc = new ConcreteCreator();
        Matrix<double> result;

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(tbrow1.Text) == Convert.ToInt32(tbrow2.Text)) && (Convert.ToInt32(tbcolumn1.Text) == Convert.ToInt32(tbcolumn2.Text)))
            {
                bool Ra = true;

                foreach (DataGridViewRow rw1 in this.dataGridView1.Rows)
                {
                    for (int i = 0; i < rw1.Cells.Count; i++)
                    {
                        if (rw1.Cells[i].Value == null || rw1.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw1.Cells[i].Value.ToString()))
                        {
                            MessageBox.Show(string.Format("There have some empty spaces in Matrix A, Row : {0}, Column : {1}", rw1.Index + 1, i + 1));
                            Ra = false;
                        }
                    }
                }


                foreach (DataGridViewRow rw2 in this.dataGridView2.Rows)
                {
                    for (int j = 0; j < rw2.Cells.Count; j++)
                    {
                        if (rw2.Cells[j].Value == null || rw2.Cells[j].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw2.Cells[j].Value.ToString()))
                        {
                            Ra = false;
                            MessageBox.Show(string.Format("There have some empty spaces in Matrix B, Row : {0}, Column : {1}", rw2.Index + 1, j + 1));
                        }
                    }
                }


                if (Ra)
                {
                    for (c = 0; c < dataGridView2.ColumnCount; c++)
                    {

                        IMatrix Matrixx = mc.GetMatrixSide(dataGridView1);
                        IMatrix Matrixxx = mc.GetMatrixSide(dataGridView2);

                        result = Matrixx.create_matrix(dataGridView1) + Matrixxx.create_matrix(dataGridView2);

                        dataGridView3.RowCount = Convert.ToInt32(tbrow1.Text);
                        dataGridView3.ColumnCount = Convert.ToInt32(tbcolumn1.Text);
                        dataGridView3.AutoResizeColumns();
                        dataGridView3.AutoResizeRows();

                        for (int d = 0; d < dataGridView3.RowCount; d++)
                        {
                            for (int col = 0; col < dataGridView3.ColumnCount; col++)
                            {
                                dataGridView3.Rows[d].Cells[col].Value = result[d, col];
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Matrix for Add cannot be processed. Please follow the guideline.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(tbrow1.Text) == Convert.ToInt32(tbrow2.Text)) && (Convert.ToInt32(tbcolumn1.Text) == Convert.ToInt32(tbcolumn2.Text)))
            {
                bool Ra = true;

                foreach (DataGridViewRow rw1 in this.dataGridView1.Rows)
                {
                    for (int i = 0; i < rw1.Cells.Count; i++)
                    {
                        if (rw1.Cells[i].Value == null || rw1.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw1.Cells[i].Value.ToString()))
                        {
                            MessageBox.Show(string.Format("There have some empty spaces in Matrix A, Row : {0}, Column : {1}", rw1.Index + 1, i + 1));
                            Ra = false;
                        }
                    }
                }


                foreach (DataGridViewRow rw2 in this.dataGridView2.Rows)
                {
                    for (int j = 0; j < rw2.Cells.Count; j++)
                    {
                        if (rw2.Cells[j].Value == null || rw2.Cells[j].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw2.Cells[j].Value.ToString()))
                        {
                            Ra = false;
                            MessageBox.Show(string.Format("There have some empty space in Matrix B, Row : {0}, Column : {1}", rw2.Index + 1, j + 1));
                        }
                    }
                }


                if (Ra)
                {
                    for (c = 0; c < dataGridView2.ColumnCount; c++)
                    {

                        IMatrix Matrixx = mc.GetMatrixSide(dataGridView1);
                        IMatrix Matrixxx = mc.GetMatrixSide(dataGridView2);

                        result = Matrixx.create_matrix(dataGridView1) - Matrixxx.create_matrix(dataGridView2);

                        dataGridView3.RowCount = Convert.ToInt32(tbrow1.Text);
                        dataGridView3.ColumnCount = Convert.ToInt32(tbcolumn1.Text);
                        dataGridView3.AutoResizeColumns();
                        dataGridView3.AutoResizeRows();

                        for (int d = 0; d < dataGridView3.RowCount; d++)
                        {
                            for (int col = 0; col < dataGridView3.ColumnCount; col++)
                            {
                                dataGridView3.Rows[d].Cells[col].Value = result[d, col];
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Matrix for Subtract cannot be processed. Please follow the guideline.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            bool Ra = true;

            foreach (DataGridViewRow rw1 in this.dataGridView1.Rows)
            {
                for (int i = 0; i < rw1.Cells.Count; i++)
                {
                    if (rw1.Cells[i].Value == null || rw1.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw1.Cells[i].Value.ToString()))
                    {
                        MessageBox.Show(string.Format("There have some empty space in MatrixA, Row : {0}, Column : {1}", rw1.Index + 1, i + 1));
                        Ra = false;
                    }
                }
            }


            if (Ra)
            {
                try
                {
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        int R = row.Index;
                        {
                            for (b = 0; b < dataGridView1.RowCount; b++)
                            {
                                a = 0;
                                for (c = 0; c < dataGridView1.ColumnCount; c++)
                                {

                                    IMatrix Matrixx = mc.GetMatrixSide(dataGridView1);

                                    result = Matrixx.create_matrix(dataGridView1).Transpose();

                                    dataGridView3.RowCount = Convert.ToInt32(tbcolumn1.Text);
                                    dataGridView3.ColumnCount = Convert.ToInt32(tbrow1.Text);
                                    dataGridView3.AutoResizeColumns();
                                    dataGridView3.AutoResizeRows();

                                    for (int d = 0; d < dataGridView3.RowCount; d++)
                                    {
                                        for (int col = 0; col < dataGridView3.ColumnCount; col++)
                                        {
                                            dataGridView3.Rows[d].Cells[col].Value = result[d, col];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbcolumn1.Clear();
            tbcolumn2.Clear();

            tbrow1.Clear();
            tbrow2.Clear();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void multiply_btn_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(tbrow2.Text)) == (Convert.ToInt32(tbcolumn1.Text)))
            {

                bool Ra = true;

                foreach (DataGridViewRow rw1 in this.dataGridView1.Rows)
                {
                    for (int i = 0; i < rw1.Cells.Count; i++)
                    {
                        if (rw1.Cells[i].Value == null || rw1.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw1.Cells[i].Value.ToString()))
                        {
                            MessageBox.Show(string.Format("There have some empty space in MatrixA, Row : {0}, Column : {1}", rw1.Index + 1, i + 1));
                            Ra = false;
                        }
                    }
                }


                foreach (DataGridViewRow rw2 in this.dataGridView2.Rows)
                {
                    for (int j = 0; j < rw2.Cells.Count; j++)
                    {
                        if (rw2.Cells[j].Value == null || rw2.Cells[j].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw2.Cells[j].Value.ToString()))
                        {
                            Ra = false;
                            MessageBox.Show(string.Format("There have some empty space in MatrixB, Row : {0}, Column : {1}", rw2.Index + 1, j + 1));
                        }
                    }
                }


                if (Ra)
                {
                    try
                    {
                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
                        {
                            int R = row.Index;
                            {
                                for (b = 0; b < dataGridView2.RowCount; b++)
                                {
                                    a = 0;
                                    for (c = 0; c < dataGridView2.ColumnCount; c++)
                                    {

                                        IMatrix Matrixx = mc.GetMatrixSide(dataGridView1);
                                        IMatrix Matrixxx = mc.GetMatrixSide(dataGridView2);

                                        result = Matrixx.create_matrix(dataGridView1) * Matrixxx.create_matrix(dataGridView2);

                                        dataGridView3.RowCount = Convert.ToInt32(tbrow1.Text);
                                        dataGridView3.ColumnCount = Convert.ToInt32(tbcolumn1.Text);
                                        dataGridView3.AutoResizeColumns();
                                        dataGridView3.AutoResizeRows();

                                        for (int d = 0; d < dataGridView3.RowCount; d++)
                                        {
                                            for (int col = 0; col < dataGridView3.ColumnCount; col++)
                                            {
                                                dataGridView3.Rows[d].Cells[col].Value = result[d, col];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                    }
                }     

            }
            else
            {
                MessageBox.Show("Please check the guideline towards to Multiplication.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tbrow1.Text != "" && tbcolumn1.Text != "")
            {
                // create rows
                dataGridView1.RowCount = (Convert.ToInt32(tbrow1.Text));
                r1 = dataGridView1.RowCount;
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AutoResizeRows();

                // create columns
                dataGridView1.ColumnCount = Convert.ToInt32(tbcolumn1.Text);
                c1 = dataGridView1.ColumnCount;
                dataGridView1.AutoResizeColumns();
            }
            else
            {
                MessageBox.Show("Please fill in the right format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createB_btn_Click(object sender, EventArgs e)
        {
            if (tbrow2.Text != "" && tbcolumn2.Text != "")
            {
                // create rows
                dataGridView2.RowCount = (Convert.ToInt32(tbrow2.Text));
                r2 = dataGridView2.RowCount;
                dataGridView2.AutoResizeRows();

                // create columns
                dataGridView2.ColumnCount = Convert.ToInt32(tbcolumn2.Text);
                c2 = dataGridView2.ColumnCount;
                dataGridView2.AutoResizeColumns();

            }
            else
            {
                MessageBox.Show("Please fill in the right format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
