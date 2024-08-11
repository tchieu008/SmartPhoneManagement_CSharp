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
using System.Globalization;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PhoneManagement
{
    public partial class SmartPhoneManagement : Form
    {
        public SmartPhoneManagement()
        {
            InitializeComponent();
        }

        public List<SmartPhone> SPList = new List<SmartPhone>();
        //loadData = 0 (chua co du lieu);
        //loadData = 1 (co du lieu tu excel);
        //loadData = 2 (co du lieu tu sql);
        public int loadData = 0;
        static string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string ExcelFilePath = ProjectPath + "\\Data\\SmartPhoneList.xlsx";
        string connetionString = "Data Source=TCHIEU;Initial Catalog=SmartPhoneDB;Integrated Security=SSPI"; 
        int CurrentPhoneIndex = -1;
        DataTable datatable;
        BindingSource binding = new BindingSource();

        private void btnLoadExcel_Click(object sender, EventArgs e) 
        {
            loadData = 1;
            datatable = new DataTable();
            SPList.Clear();

            int colCount = 10;
            int NumDataRow = ReadDataFromFile(SPList, ExcelFilePath, colCount);
            var sublist = SPList.Select(x => new
            {
                SmartPhoneID = x.SmartPhoneID,
                SmartPhoneName = x.SmartPhoneName,
                SmartPhoneType = x.SmartPhoneType,
                AnnouncedDate = x.AnnouncedDate.ToString("dd/MM/yyyy"),
                Platform = x.Platform,
                Camera = x.Camera,
                RAM = x.RAM,
                Battery = x.Battery,
                Price = x.Price.ToString() + " USD",

            }).ToList();

            datatable.Columns.Add("SmartPhoneID");
            datatable.Columns.Add("SmartPhoneName");
            datatable.Columns.Add("SmartPhoneType");
            datatable.Columns.Add("AnnouncedDate");
            datatable.Columns.Add("Platform");
            datatable.Columns.Add("Camera");
            datatable.Columns.Add("RAM");
            datatable.Columns.Add("Battery");
            datatable.Columns.Add("Price");

            DataRow newrow;
            foreach (var bi in sublist)
            {
                newrow = datatable.NewRow();
                newrow["SmartPhoneID"] = bi.SmartPhoneID;
                newrow["SmartPhoneName"] = bi.SmartPhoneName;
                newrow["SmartPhoneType"] = bi.SmartPhoneType;
                newrow["AnnouncedDate"] = bi.AnnouncedDate;
                newrow["Platform"] = bi.Platform;
                newrow["Camera"] = bi.Camera;
                newrow["RAM"] = bi.RAM;
                newrow["Battery"] = bi.Battery;
                newrow["Price"] = bi.Price;
                datatable.Rows.Add(newrow);
                datatable.AcceptChanges();
            }

            binding.AllowNew = true;
            binding.DataSource = datatable;
            dgwPhoneList.AutoGenerateColumns = false;
            dgwPhoneList.DataSource = binding;
        }

        public int ReadDataFromFile(List<SmartPhone> DataList, string FilePath, int colCount)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FilePath, ReadOnly: true);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            xlWorksheet.Columns.ClearFormats();
            xlWorksheet.Rows.ClearFormats();

            int rowCount = xlWorksheet.UsedRange.Rows.Count;

            int numPhone = 0;
            string SmartPhoneID = "";
            string SmartPhoneName = "";
            string SmartPhoneType = "";
            DateTime AnnouncedDate = DateTime.Now;
            string Platform = "";
            string Camera = "";
            string RAM = "";
            string Battery = "";
            int Price = 0;
            string Avatar = "";

            for (int i = 2; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    switch (j)
                    {
                        case 1: //column SmartPhoneID
                            SmartPhoneID = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 2: //column SmartPhoneName
                            SmartPhoneName = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 3: //column SmartPhoneType
                            SmartPhoneType = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 4: //column Announced Date
                            AnnouncedDate = DateTime.ParseExact(xlRange.Cells[i, j].Value2.ToString(),
                                "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            break;
                        case 5: //column Platform
                            Platform = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 6: //column Camera
                            Camera = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 7: //column RAM
                            RAM = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 8: //column Battery
                            Battery = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 9: //column Price
                            Price = Convert.ToInt32(xlRange.Cells[i, j].Value2.ToString());
                            break;
                        case 10: //column Avatar
                            Avatar = xlRange.Cells[i, j].Value2.ToString();
                            break;
                    }
                }
                DataList.Add(new SmartPhone());
                DataList[numPhone].SmartPhoneID = SmartPhoneID;
                DataList[numPhone].SmartPhoneName = SmartPhoneName;
                DataList[numPhone].SmartPhoneType = SmartPhoneType;
                DataList[numPhone].AnnouncedDate = AnnouncedDate;
                DataList[numPhone].Platform = Platform;
                DataList[numPhone].Camera = Camera;
                DataList[numPhone].RAM = RAM;
                DataList[numPhone].Battery = Battery;
                DataList[numPhone].Price = Price;
                DataList[numPhone].Avatar = Avatar;
                numPhone = numPhone + 1;
            }
            xlWorkbook.Close(false, Type.Missing, Type.Missing); //dong workbook ma khong luu
            xlApp.Quit();

            // Giai phong tai nguyen
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Load Data From Excel Finished! :" + (rowCount - 1).ToString() + " Records");
            return (rowCount - 1); //Khong tinh dong tieu de
        }

        private void dgwPhoneList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SPList.Count == 0 || datatable.Rows.Count == 0) return;

            CurrentPhoneIndex = dgwPhoneList.CurrentRow.Index;
            if (CurrentPhoneIndex >= 0 && CurrentPhoneIndex < SPList.Count)
            {
                picPhoneImage.Image = Image.FromFile(ProjectPath + "\\Data\\" + SPList[CurrentPhoneIndex].Avatar);
            }
        }

        private void btnLoadSQL_Click(object sender, EventArgs e)
        {
            loadData = 2;
            datatable = new DataTable();
            SPList.Clear();

            int NumDataRow = ReadDataFromSQLServe(SPList, connetionString);

            var sublist = SPList.Select(x => new
            {
                SmartPhoneID = x.SmartPhoneID,
                SmartPhoneName = x.SmartPhoneName,
                SmartPhoneType = x.SmartPhoneType,
                AnnouncedDate = x.AnnouncedDate.ToString("dd/MM/yyyy"),
                Platform = x.Platform,
                Camera = x.Camera,
                RAM = x.RAM,
                Battery = x.Battery,
                Price = x.Price.ToString() + " USD",

            }).ToList();

            datatable.Columns.Add("SmartPhoneID");
            datatable.Columns.Add("SmartPhoneName");
            datatable.Columns.Add("SmartPhoneType");
            datatable.Columns.Add("AnnouncedDate");
            datatable.Columns.Add("Platform");
            datatable.Columns.Add("Camera");
            datatable.Columns.Add("RAM");
            datatable.Columns.Add("Battery");
            datatable.Columns.Add("Price");

            DataRow newrow;
            foreach (var bi in sublist)
            {
                newrow = datatable.NewRow();
                newrow["SmartPhoneID"] = bi.SmartPhoneID;
                newrow["SmartPhoneName"] = bi.SmartPhoneName;
                newrow["SmartPhoneType"] = bi.SmartPhoneType;
                newrow["AnnouncedDate"] = bi.AnnouncedDate;
                newrow["Platform"] = bi.Platform;
                newrow["Camera"] = bi.Camera;
                newrow["RAM"] = bi.RAM;
                newrow["Battery"] = bi.Battery;
                newrow["Price"] = bi.Price;
                datatable.Rows.Add(newrow);
                datatable.AcceptChanges();
            }

            binding.AllowNew = true;
            binding.DataSource = datatable;
            dgwPhoneList.AutoGenerateColumns = false;
            dgwPhoneList.DataSource = binding;
        }

        public int ReadDataFromSQLServe(List<SmartPhone> DataList, string connetionString)
        {
            SqlConnection cnn = new SqlConnection(connetionString);

            int iRow = 0;
            int NumRecords = 0;
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open!");

                string SqlString = @"SELECT
                                    SmartPhoneID, 
                                    SmartPhoneName, 
                                    SmartPhoneType,
                                    AnnouncedDate = Convert(varchar(10)),CONVERT(date,AnnouncedDate,106),103),
                                    Platform,
                                    Camera,
                                    RAM,
                                    Battery,
                                    Price,
                                    ImageName
                                    FROM dbo.SmartPhone";

                using (var command = new SqlCommand(SqlString, cnn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SPList.Add(new SmartPhone());
                            SPList[iRow].SmartPhoneID = reader.GetString(0);
                            SPList[iRow].SmartPhoneName = reader.GetString(1);
                            SPList[iRow].SmartPhoneType = reader.GetString(2);
                            SPList[iRow].AnnouncedDate = DateTime.ParseExact(reader.GetString(3), "dd/MM/yyyy",
                                                                             CultureInfo.InvariantCulture);
                            SPList[iRow].Platform = reader.GetString(4);
                            SPList[iRow].Camera = reader.GetString(5);
                            SPList[iRow].RAM = reader.GetString(6);
                            SPList[iRow].Battery = reader.GetString(7);
                            SPList[iRow].Price = reader.GetInt32(8);
                            SPList[iRow].Avatar = reader.GetString(9);

                            iRow = iRow + 1;
                        }
                    }
                }

                SqlCommand cmd = new SqlCommand("select count(*) from SmartPhone", cnn);
                object result = cmd.ExecuteScalar();
                NumRecords = int.Parse(result.ToString());

                MessageBox.Show("Finish Load Data From SQL" + NumRecords.ToString() + " Records");
                cnn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Can not open connection!: " + ex.Message);
            }

            return NumRecords;
        }

        private void dgwPhoneList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnPrice_KeyPress);
            if (dgwPhoneList.CurrentCell.ColumnIndex == 8) //Column Price
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnPrice_KeyPress);
                }
            }
        }

        private void ColumnPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SmartPhone sp = new SmartPhone();
            sp.SmartPhoneID = "Not assigned";
            sp.SmartPhoneName = "Not assigned";
            sp.SmartPhoneType = "Not assigned";
            sp.AnnouncedDate = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            sp.Camera = "Not assigned";
            sp.RAM = "Not assigned";
            sp.Battery = "Not assigned";
            sp.Price = 0;
            sp.Avatar = "smartphone.jpg";
            SPList.Add(sp);

            DataRow newrow;
            newrow = datatable.NewRow();
            newrow["SmartPhoneID"] = sp.SmartPhoneID;
            newrow["SmartPhoneName"] = sp.SmartPhoneName;
            newrow["SmartPhoneType"] = sp.SmartPhoneType;
            newrow["AnnouncedDate"] = sp.AnnouncedDate;
            newrow["Platform"] = sp.Platform;
            newrow["Camera"] = sp.Camera;
            newrow["RAM"] = sp.RAM;
            newrow["Battery"] = sp.Battery;
            newrow["Price"] = sp.Price;
            datatable.Rows.Add(newrow);
            datatable.AcceptChanges();

            MessageBox.Show("Finish Adding");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SmartPhone sp;
            if (CurrentPhoneIndex > 0)
            {
                sp = SPList[CurrentPhoneIndex];
            }
            else
            {
                return;
            }

            string question = "Do You Want to delete Phone:" + sp.SmartPhoneID;
            DialogResult result = MessageBox.Show(question, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SPList.RemoveAt(CurrentPhoneIndex);
                binding.RemoveAt(CurrentPhoneIndex);
            }
            MessageBox.Show("Finish Delete");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row;
            for(int i=0; i<datatable.Rows.Count; i++)
            {
                row = datatable.Rows[i];

                SPList[i].SmartPhoneID = row["SmartPhoneID"].ToString();
                SPList[i].SmartPhoneName = row["SmartPhoneName"].ToString();
                SPList[i].SmartPhoneType = row["SmartPhoneType"].ToString();
                SPList[i].AnnouncedDate = DateTime.ParseExact(row["AnnouncedDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                SPList[i].Platform = row["Platform"].ToString();
                SPList[i].Camera = row["Camera"].ToString();
                SPList[i].RAM = row["RAM"].ToString();
                SPList[i].Battery = row["Battery"].ToString();
                string sPrice = row["Price"].ToString();

                SPList[i].Price = Convert.ToInt32(sPrice.Substring(0, sPrice.IndexOf(" ")));
            }
        }

        private void btnUpdateSource_Click(object sender, EventArgs e)
        {
            if (loadData == 1)
            {
                WriteDataToExcelFile(SPList, ExcelFilePath);
            }
            else
            {
                WriteDataToSQLServer(SPList, connetionString);
            }
        }

        public void WriteDataToExcelFile(List<SmartPhone> SPList, string ExcelFilePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ExcelFilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            Excel.Range xlRange;
            string[,] Data = new string[1, 10];

            int idxRow = 2;
            foreach(SmartPhone sp in SPList)
            {
                Data[0, 0] = sp.SmartPhoneID;
                Data[0, 1] = sp.SmartPhoneName;
                Data[0, 2] = sp.SmartPhoneType;
                Data[0, 3] = sp.AnnouncedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                Data[0, 4] = sp.Platform;
                Data[0, 5] = sp.Camera;
                Data[0, 6] = sp.RAM;
                Data[0, 7] = sp.Battery;
                Data[0, 8] = sp.Price.ToString();
                Data[0, 9] = sp.Avatar;

                xlRange = xlWorksheet.get_Range("A" + idxRow.ToString(), "J" + idxRow.ToString());
                xlRange.Value2 = Data;

                idxRow = idxRow + 1;
            }

            xlWorkbook.Save();
            xlWorkbook.Close();
            xlApp.Quit();

            MessageBox.Show("Finish Update to DataSource Excel");
        }

        public void WriteDataToSQLServer(List<SmartPhone> SPList, string connetionString)
        {
            SqlConnection cnn;
            SqlCommand myCommand = new SqlCommand();
            string query;

            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open!");
                query = "TRUNCATE TABLE SmartPhone";
                myCommand.CommandText = query;
                myCommand.Connection = cnn;
                myCommand.ExecuteNonQuery();

                query = @"INSERT INTO SmartPhone(SmartPhoneID,SmartPhoneName,SmartPhoneType,
                                                    AnnouncedDate,Platform,Camera,RAM,Battery,Price,ImageName)";

                query += @"VALUES (@SmartPhoneID,@SmartPhoneName,@SmartPhoneType,
                                                    @AnnouncedDate,@Platform,@Camera,@RAM,@Battery,@Price,@ImageName)";

                myCommand.CommandText = query;
                myCommand.Connection = cnn;

                myCommand.Parameters.Add(new SqlParameter("@SmartPhoneID", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@SmartPhoneName", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@SmartPhoneType", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@AnnouncedDate", SqlDbType.DateTime));
                myCommand.Parameters.Add(new SqlParameter("@Platform", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@Camera", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@RAM", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@Battery", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int));
                myCommand.Parameters.Add(new SqlParameter("@ImageName", SqlDbType.NVarChar));

                foreach (SmartPhone sp in SPList)
                {
                    myCommand.Parameters[0].Value = sp.SmartPhoneID;
                    myCommand.Parameters[1].Value = sp.SmartPhoneName;
                    myCommand.Parameters[0].Value = sp.SmartPhoneType;
                    myCommand.Parameters[0].Value = sp.AnnouncedDate.ToString("yyyy-MM-dd",
                                                                               CultureInfo.InvariantCulture);
                    myCommand.Parameters[0].Value = sp.Platform;
                    myCommand.Parameters[0].Value = sp.Camera;
                    myCommand.Parameters[0].Value = sp.RAM;
                    myCommand.Parameters[0].Value = sp.Battery;
                    myCommand.Parameters[0].Value = sp.Price;
                    myCommand.Parameters[0].Value = sp.Avatar;

                    myCommand.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }

            MessageBox.Show("Finish Update to DataSource SQL Server");
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
