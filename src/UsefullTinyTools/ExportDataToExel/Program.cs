using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using ExportDataToExel.Model;
using System.Linq;

namespace ExportDataToExel
{
    class Program
    {
        private const string _connectionString = "Data Source=47.97.155.45,58838;Initial Catalog=RBCNEW_DEV;Persist Security Info=True;User Id=uat_rbc_user;Password=@Ribencun_user2017";

        static void Main( string[] args )
        {
            //类型数组
            var calc = new string[] { "成单额  (K) ", "留学", "兴趣课", "能力考", "高考日语", "考研", "工作/商务", "日常会话", "月人均成单额" };
            //读取数据
            var dataList = new List<CDModel>();
            var depList = new List<DepartmentModel>();
            ExcelRead(dataList, depList);

            Dictionary<int, List<decimal?>> dicData = new Dictionary<int, List<decimal?>>();

            var depNames = new List<string>();
            depNames.Add("类别");
            for (var i = 0; i < calc.Length; i++)
            {
                var moneyList = new List<decimal?>();

                CalcData( dataList, depList, 0, i, moneyList, 0, depNames);
                dicData.Add(i, moneyList);
            }

            foreach (var item in dicData)
            {
                Console.WriteLine("cid: " + item.Key + " values: ");
                foreach (var i in item.Value)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            ExcelWrite(dicData, depNames);
            Console.WriteLine("Hello World!");
        }

        private static void FindLowestDepartment( List<DepartmentModel> departmentModels, List<DepartmentModel> newModel, int id )
        {
            foreach (var d in departmentModels.FindAll(x => x.ParentId == id))
            {
                if (departmentModels.Any(x => d.Id == d.ParentId))
                {
                    FindLowestDepartment(departmentModels, newModel, d.Id);
                }
                newModel.IndexOf(d, 0);
            }
        }

        private static void CalcData( List<CDModel> cDModels, List<DepartmentModel> departmentModels, int pid, int cid, List<decimal?> moneyList, decimal? sum, List<string> depNames )
        {
            //var dvalue = new List<decimal?>();
            int i = 0;
            var curDepartment = departmentModels.FindAll(x => x.ParentId == pid).OrderBy(x=>x.Id);
            foreach (var d in curDepartment)
            {
                if (departmentModels.Any(x => d.Id == x.ParentId))
                {
                    CalcData( cDModels, departmentModels, d.Id, cid, moneyList, 0, depNames);
                }
                var sumcd = cDModels.Where(xd => xd.DepId == d.Id && xd.CalcId < 9).Sum(x => x.CDMoney);
                depNames.Add(d.DepartmentName);
                if (cid == 0)
                {
                    if (sumcd == 0)
                    {
                        moneyList.Add(null);
                    }
                    else
                    {
                        moneyList.Add(sumcd);
                    }
                }
                else if (cid == 8)
                {
                    if (sumcd == 0)
                    {
                        moneyList.Add(null);
                    }
                    else
                    {
                        moneyList.Add(Math.Round(sumcd / d.UserNumber, 3));
                    }
                }
                else
                {
                    var value = cDModels.FirstOrDefault(xd => xd.DepId == d.Id && xd.CalcId == cid)?.CDMoney;
                    sum += value == null ? 0 : value;
                    moneyList.Add(value);
                }
                if (i == curDepartment.Count() - 1)
                {
                    moneyList.Add(sum);
                    depNames.Add("合计");
                }
                i++;
            }
        }

        private static void ExcelRead( List<CDModel> cDModels, List<DepartmentModel> departmentModels )
        {
            var fileName = @"C:\Users\82755\Desktop\独立核算\【汇总】导入模板.xlsx";
            using (var fs = File.OpenRead(fileName))//new FileStream(fileName,FileMode.Open,FileAccess.Read)
            {
                var workbook = new XSSFWorkbook(fs);
                var sheetdata = workbook.GetSheet("Test1");
                var sheetDep = workbook.GetSheet("Test2");

                for (int i = 1; i <= sheetdata.LastRowNum; i++)
                {
                    var row = sheetdata.GetRow(i);
                    if (row == null)
                        continue;
                    var obj = new CDModel();
                    obj.Month = (int)row.Cells[0].NumericCellValue;
                    obj.DepId = (int)(row.Cells[1].NumericCellValue);
                    obj.CalcId = (int)(row.Cells[2].NumericCellValue);
                    obj.CDMoney = (int)(row.Cells[3].NumericCellValue);
                    cDModels.Add(obj);
                }

                for (int i = 1; i <= sheetdata.LastRowNum; i++)
                {
                    var row = sheetDep.GetRow(i);
                    if (row == null)
                        continue;
                    var obj = new DepartmentModel();
                    obj.Id = (int)(row.Cells[0].NumericCellValue);
                    obj.DepartmentName = row.Cells[1].StringCellValue;
                    obj.ParentId = (int)(row.Cells[2].NumericCellValue);
                    obj.UserNumber = (int)(row.Cells[3].NumericCellValue);
                    departmentModels.Add(obj);
                }
            }

        }


        private static void ExcelWrite( Dictionary<int, List<decimal?>> dicData, List<string> depNames )
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("ResultData");
            //填写表头
            var row1 = sheet.CreateRow(0);
            for (int x = 0; x < depNames.Count; x++)
            {
                var cell = row1.CreateCell(x);
                cell.SetCellValue(depNames[x]);
            }

            int i = 1;
            foreach (var item in dicData)
            {
                var row = sheet.CreateRow(i);
                var cell1 = row.CreateCell(0);
                cell1.SetCellValue(item.Key);
                for (var j = 1; j <= item.Value.Count; j++)
                {
                    var cell = row.CreateCell(j);
                    cell.SetCellValue(item.Value[j - 1].ToString());
                }
                i++;
            }
            using (var fstream = File.OpenWrite(@"C:\Users\82755\Desktop\独立核算\导出数据测试\result2.xls"))
            {
                workbook.Write(fstream);
            }

        }


        public static void ExcelReadaWrite()
        {
            var dbhelper = new DBHelper();
            var data = dbhelper.ConnectDB();

            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("users");
            for (var i = 0; i < data.Rows.Count; i++)
            {
                var row = sheet.CreateRow(i);
                for (var j = 0; j < data.Columns.Count; j++)
                {
                    var cell = row.CreateCell(j);
                    cell.SetCellValue(data.Rows[i][j].ToString());
                }
            }
            using (var fstream = File.OpenWrite(@"C:\Users\82755\Desktop\独立核算\导出数据测试\userdatatest.xls"))
            {
                workbook.Write(fstream);
            }

        }
    }
}
