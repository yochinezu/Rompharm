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
using Excel = Microsoft.Office.Interop.Excel;

namespace RPH.ExcelToSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        bool ValidInputs()
        {          
            if (Path.GetExtension(textBox1.Text) != ".xlsx")
            {
                MessageBox.Show("Locatia excel gresita", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Numarul de linii trebuie sa fie un numar intreg", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Nu este selectat ghidul", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidInputs())
            {
                string pathSql = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\sql.txt";
                StreamWriter sw = File.AppendText(pathSql);

                string excelPath = textBox1.Text;

                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = excel.Workbooks.Open(excelPath);
                Excel.Worksheet excelSheet = wb.ActiveSheet;

                int n = Convert.ToInt32(textBox2.Text);
                int m = 12;
                string ghid = comboBox1.Text;

                for (int i = 2; i <= n; ++i)
                {
                    string querry = "INSERT INTO `Medicament`(`Ghid`, `Tip`, `Crt`, `Substanta`, `FormaFarmaceutica`, `DenumireComerciala`, `CoplataPacient`, `PretFarmacie`, `CompanieProducatoare`, `ModDeActiune`, `ReducereIop`, `ContraIndicatii`, `EfecteAdverse`) VALUES (\"" + ghid + "\"";

                    for (int j = 1; j <= m; ++j)
                    {
                        string value;
                        try
                        {
                            value = excelSheet.Cells[i, j].Value.ToString();
                        }
                        catch
                        {
                            value = "~";
                        }
                        querry += ",\"" + value + "\"";
                    }
                    querry = querry + ");";
                    sw.WriteLine(querry);
                }

                sw.Close();
                wb.Close();

                MessageBox.Show("Terminat", "Excel to SQL", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mesaj = "Se vor procesa medicamentele incepand cu randul 2 de pe prima pagina. Ordinea coloanelor este: `Ghid`, `Tip`, `Crt`, `Substanta`, `FormaFarmaceutica`, `DenumireComerciala`, `CoplataPacient`, `PretFarmacie`, `CompanieProducatoare`, `ModDeActiune`, `ReducereIop`, `ContraIndicatii`, `EfecteAdverse`";
            MessageBox.Show(mesaj, "Cum se foloseste programul", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
