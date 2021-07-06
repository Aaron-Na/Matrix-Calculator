using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Windows.Forms;



namespace Matrix
{
    

    interface IMatrix
    {
        Matrix<double> create_matrix(DataGridView gridview);
    }
    class ConcreteMatrix_A : IMatrix
    {
        public Matrix<double> create_matrix(DataGridView gridview)
        {

            int ROW = gridview.Rows.Count;
            int COL = gridview.Columns.Count;

            double[,] N = new double[ROW, COL];

            for (int i = 0; i < gridview.Rows.Count; i++)
            {
                for (int j = 0; j < gridview.Columns.Count; j++)
                {
                    N[i, j] = Convert.ToDouble(gridview.Rows[i].Cells[j].Value);
                }
            }

            Matrix<double> MatrixA = DenseMatrix.OfArray(N);

            return MatrixA;

        }
    }


    class ConcreteMatrix_B : IMatrix
    {
        public Matrix<double> create_matrix(DataGridView gridview)
        {

            int ROW = gridview.Rows.Count;
            int COL = gridview.Columns.Count;

            double[,] N = new double[ROW, COL];

            for (int i = 0; i < gridview.Rows.Count; i++)
            {
                for (int j = 0; j < gridview.Columns.Count; j++)
                {
                    N[i, j] = Convert.ToDouble(gridview.Rows[i].Cells[j].Value);
                }
            }

            Matrix<double> MatrixB = DenseMatrix.OfArray(N);

            return MatrixB;

        }
    }

    abstract class Creator
    {
        public abstract IMatrix GetMatrixSide(DataGridView gridview);
    }

    class ConcreteCreator : Creator
    {
        public override IMatrix GetMatrixSide(DataGridView gridview)
        {
            string gridviewn = Convert.ToString(gridview.Name);


            switch (gridviewn)
            {
                case "dataGridView1": return new ConcreteMatrix_A();
                case "dataGridView2": return new ConcreteMatrix_B();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}

