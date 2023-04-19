using EllipticCurve.Utils;
using System.Windows.Forms.Design.Behavior;

namespace Gerador_De_Combinacoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Clear();
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            string valor = string.Empty;
            int nrCOmbinacoes = 0;
            int n = Convert.ToInt32(textBox2.Text); // número de elementos
            int[,] combinations = GenerateCombinations(n);
            for (int i = 0; i < combinations.GetLength(0); i++)
            {
                for (int j = 0; j < combinations.GetLength(1); j++)
                {
                    //Console.Write(combinations[i, j] + ",");
                    valor += combinations[i, j] + ",";
                }
                //Console.WriteLine();

                if (i == 0)
                {
                    textBox1.Text = valor;
                }
                else
                {
                    textBox1.Text += "\r\n" + valor;
                }
                valor = string.Empty;
                nrCOmbinacoes++;
            }
            //Console.ReadLine();
            label2.Visible = true;
            label2.Text = "Foram identificadas "+nrCOmbinacoes+" combinações possíveis";


            #region ORIGINAL NÃO EXCLUIR
            // inserir ou retiar FORs conforme necessidade de numero de colunas a combina
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        for (int k = 0; k < 2; k++)
            //        {
            //            for (int l = 0; l < 2; l++)
            //            {
            //                for (int m = 0; m < 2; m++)
            //                {

            //                    textBox1.Text += "\r\n" + i.ToString() +";"+ j.ToString() + ";" + k.ToString() + ";" + l.ToString() + ";" + m.ToString();// System.out.println("" + i + j + k + l + m);
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
        }

        static int[,] GenerateCombinations(int n)
        {
            int numCombinations = (int)Math.Pow(2, n);
            int[,] combinations = new int[numCombinations, n];
            for (int i = 0; i < numCombinations; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    combinations[i, j] = (i >> j) & 1;
                }
            }
            return combinations;
        }
    }
}