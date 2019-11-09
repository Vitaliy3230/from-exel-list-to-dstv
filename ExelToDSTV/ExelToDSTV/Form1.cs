using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExelToDSTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "xlsx files(*.xlsx|*.xlsx|All files(*.*)|*.*";                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        void Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            string SFN = openFileDialog1.SafeFileName;
            int ind2 = filename.Length; 
            int ind = SFN.Length;
            int s1 = ind2 - ind;

            string dstvPath = filename.Remove(s1);
            wayFile.Text = filename; //путь файла в тестовое поле
            pathDSTV.Text = dstvPath; 
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string filename = wayFile.Text;
            string pathdstv = pathDSTV.Text;
            int s1 = 2; //считываемый масив профиля(в ексель А=1,В=2... и т.д.)

            Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
            
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(@filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1 лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//1 ячейку
            //-------------------------------------

            int iLastRow = ObjWorkSheet.Cells[ObjWorkSheet.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row;  //последняя заполненная строка в столбце А
            var arrData = (object[,])ObjWorkSheet.Range["A1:Z" + iLastRow].Value;
           
            // Инициализируем данный массив
            ArrayList arrayList = new ArrayList();

            int rows = arrData.GetUpperBound(0);
            int columns = arrData.Length / rows;

            //перебор строки с размерами пластины
            for (int i = 1; i < rows+1; i++)
            {                 
              arrayList.Add(arrData[i, s1]);
            }

            //разбиение пластниы
            ArrayList arrayListPlate = new ArrayList();

            for (int i = 0; i < arrayList.Count; i++)
            {
                string x22 = arrayList[i].ToString();
                string[] x23 = x22.Split(new char[] { 'х' });
                arrayListPlate.Add(x23);
            }

            //--------------создание dstv файлов
            for (int i = 0; i < rows; i++)
            {
                string quantity = arrData[i+1, 1].ToString();
                //габариты детали
                string[] b = arrayListPlate[i] as string[];
                
                string bT = b[0]; //толщина пластины
                string b2 = b[1]; //ширина пластины
                string b3 = b[2]; //высота пластины

                string steel = arrData[i+1, 3].ToString();
                
                System.IO.StreamWriter dstvFile = new StreamWriter(@pathdstv + "\\" + i + ".nc1");
                dstvFile.WriteLine("ST");
                dstvFile.WriteLine($"** {i}.nc1");
                dstvFile.WriteLine("  1");
                dstvFile.WriteLine("  1");
                dstvFile.WriteLine($"  {i}");
                dstvFile.WriteLine($"  {i}");
                dstvFile.WriteLine($"  {steel}");
                dstvFile.WriteLine($"  {quantity}");
                dstvFile.WriteLine($"  PL{bT}");
                dstvFile.WriteLine("  B");
                dstvFile.WriteLine($"     {b2}.00");
                dstvFile.WriteLine($"     {b3}.00");
                dstvFile.WriteLine($"      {bT}.00");
                dstvFile.WriteLine($"      {bT}.00");
                dstvFile.WriteLine($"      {bT}.00");
                dstvFile.WriteLine("       0.00");
                dstvFile.WriteLine("     94.200");
                dstvFile.WriteLine("      2.144");
                dstvFile.WriteLine("      0.000");
                dstvFile.WriteLine("      0.000");
                dstvFile.WriteLine("      0.000");
                dstvFile.WriteLine("      0.000");
                dstvFile.WriteLine("");
                dstvFile.WriteLine("");
                dstvFile.WriteLine("");
                dstvFile.WriteLine("");
                dstvFile.WriteLine("AK");
                dstvFile.WriteLine("  v       0.00u      0.00       0.00       0.00       0.00       0.00       0.00");
                dstvFile.WriteLine($"        {b2}.00       0.00       0.00       0.00       0.00       0.00       0.00");
                dstvFile.WriteLine($"        {b2}.00     {b3}.00       0.00       0.00       0.00       0.00       0.00");
                dstvFile.WriteLine($"          0.00     {b3}.00       0.00       0.00       0.00       0.00       0.00");
                dstvFile.WriteLine("          0.00       0.00       0.00       0.00       0.00       0.00       0.00");
                dstvFile.WriteLine("EN");
                dstvFile.Close();
            }
            //---------------------------------------------------------

            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            ObjWorkExcel.Quit(); // выйти из экселя
            return;
        }

        private void pathDSTV_TextChanged(object sender, EventArgs e)
        {

        }

        private void wayFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
