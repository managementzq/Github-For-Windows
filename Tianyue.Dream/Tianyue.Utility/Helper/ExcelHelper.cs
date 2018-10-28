using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using NPOI.SS.UserModel;
//using NPOI.XSSF.UserModel;

namespace Tianyue.Utility.Helper
{

    //读取Excel文件，自动识别是2003版本还是2007版本
    /// <summary>
    /// 读取Excel文件，自动识别是2003版本还是2007版本
    /// </summary>
    public class FastExcel
    {
        //读取Excel的接口
        /// <summary>
        /// 读取Excel的接口
        /// </summary>
        private readonly IFastExcel _fastExcel;

        //FastExcel
        /// <summary>
        /// FastExcel
        /// </summary>
        /// <param name="fullFileName">Excel文件全路径</param>
        /// <param name="totalSheetCount">总Sheet页数</param>
        /// <param name="columnHeadRow">列头起始行号（从0开始）</param>
        /// <param name="columnHeadCol">列头起始列号（从0开始）</param>
        public FastExcel(string fullFileName, int totalSheetCount, int columnHeadRow, int columnHeadCol)
        {
            if (!File.Exists(fullFileName))
                throw new Exception("文件未找到！");

            var fileInfo = new FileInfo(fullFileName);
            var fileExt = fileInfo.Extension.ToLower();
            switch (fileExt)
            {
                case ".xls":
                    //_fastExcel = new FastExcel2003(fullFileName, totalSheetCount, columnHeadRow, columnHeadCol);
                    break;
                case ".xlsx":
                    //_fastExcel = new FastExcel2007(fullFileName, totalSheetCount, columnHeadRow, columnHeadCol);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("fullFileName", fileExt, "文件后缀名只能为：.xls、.xlsx");
            }
        }

        //错误消息
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _fastExcel.ErrorMessage;
            }
        }

        //读取到的Excel数据
        /// <summary>
        /// 读取到的Excel数据
        /// </summary>
        public DataSet DataSet
        {
            get
            {
                return _fastExcel.DataSet;
            }
        }

        //读取Excel指定Sheet页指定行列的值
        /// <summary>
        /// 读取Excel指定Sheet页指定行列的值
        /// </summary>
        /// <param name="sheetIndex">Sheet页索引（从0开始）</param>
        /// <param name="rowIndex">行索引（从0开始）</param>
        /// <param name="colIndex">列索引（从0开始）</param>
        /// <returns></returns>
        public string ReadCellValue(int sheetIndex, int rowIndex, int colIndex)
        {
            return _fastExcel.ReadCellValue(sheetIndex, rowIndex, colIndex);
        }

        //读取Excel指定Sheet页最后一行
        /// <summary>
        /// 读取Excel指定Sheet页最后一行
        /// </summary>
        /// <param name="sheetIndex">Sheet页索引（从0开始）</param>
        /// <param name="headIndex">表头所在行索引（从0开始）</param>
        /// <returns></returns>
        public DataTable ReadLastRow(int sheetIndex, int headIndex)
        {
            return _fastExcel.ReadLastRow(sheetIndex, headIndex);
        }
    }

    //Excel读取接口
    /// <summary>
    /// Excel读取接口
    /// </summary>
    public interface IFastExcel
    {
        //错误消息
        /// <summary>
        /// 错误消息
        /// </summary>
        string ErrorMessage { get; set; }

        //读取到的Excel数据
        /// <summary>
        /// 读取到的Excel数据
        /// </summary>
        DataSet DataSet { get; set; }

        //读取Excel指定Sheet页指定行列的值
        /// <summary>
        /// 读取Excel指定Sheet页指定行列的值
        /// </summary>
        /// <param name="sheetIndex">Sheet页索引（从0开始）</param>
        /// <param name="rowIndex">行索引（从0开始）</param>
        /// <param name="colIndex">列索引（从0开始）</param>
        /// <returns></returns>
        string ReadCellValue(int sheetIndex, int rowIndex, int colIndex);

        //读取Excel指定Sheet页最后一行
        /// <summary>
        /// 读取Excel指定Sheet页最后一行
        /// </summary>
        /// <param name="sheetIndex">Sheet页索引（从0开始）</param>
        /// <param name="headIndex">表头所在行索引（从0开始）</param>
        /// <returns></returns>
        DataTable ReadLastRow(int sheetIndex, int headIndex);
    }
    
    ////Excel处理
    ///// <summary>
    ///// Excel处理
    ///// </summary>
    //public class FastExcel2003 : IFastExcel
    //{
    //    //FastExcel
    //    /// <summary>
    //    /// FastExcel
    //    /// </summary>
    //    /// <param name="fullFileName">Excel文件全路径</param>
    //    /// <param name="totalSheetCount">总Sheet页数</param>
    //    /// <param name="columnHeadRow">列头起始行号（从0开始）</param>
    //    /// <param name="columnHeadCol">列头起始列号（从0开始）</param>
    //    public FastExcel2003(string fullFileName, int totalSheetCount, int columnHeadRow, int columnHeadCol)
    //    {
    //        BuildFileInfo(fullFileName);
    //        BuildWorkbook();

    //        _totalSheetCount = totalSheetCount;
    //        _columnHeadRow = columnHeadRow;
    //        _columnHeadCol = columnHeadCol;

    //        ReadToDataSet();
    //    }

    //    //Excel文件信息
    //    /// <summary>
    //    /// Excel文件信息
    //    /// </summary>
    //    private FileInfo _fileInfo;
    //    //总Sheet页数
    //    /// <summary>
    //    /// 总Sheet页数
    //    /// </summary>
    //    private readonly int _totalSheetCount;
    //    //列头起始行号
    //    /// <summary>
    //    /// 列头起始行号
    //    /// </summary>
    //    private readonly int _columnHeadRow;
    //    //列头起始列号
    //    /// <summary>
    //    /// 列头起始列号
    //    /// </summary>
    //    private readonly int _columnHeadCol;
    //    //Excel工作表
    //    /// <summary>
    //    /// Excel工作表
    //    /// </summary>
    //    private HSSFWorkbook _workbook;

    //    //错误消息
    //    /// <summary>
    //    /// 错误消息
    //    /// </summary>
    //    public string ErrorMessage { get; set; }
    //    //读取到的Excel数据
    //    /// <summary>
    //    /// 读取到的Excel数据
    //    /// </summary>
    //    public DataSet DataSet { get; set; }

    //    //读取Excel指定Sheet页指定行列的值
    //    /// <summary>
    //    /// 读取Excel指定Sheet页指定行列的值
    //    /// </summary>
    //    /// <param name="sheetIndex">Sheet页索引（从0开始）</param>
    //    /// <param name="rowIndex">行索引（从0开始）</param>
    //    /// <param name="colIndex">列索引（从0开始）</param>
    //    /// <returns></returns>
    //    public string ReadCellValue(int sheetIndex, int rowIndex, int colIndex)
    //    {
    //        var sheet = (HSSFSheet)_workbook.GetSheetAt(sheetIndex);
    //        var row = sheet.GetRow(rowIndex);
    //        if (row == null)
    //            return "";
    //        var cell = row.GetCell(colIndex);
    //        return cell == null ? "" : cell.ToString();
    //    }

    //    //读取Excel指定Sheet页最后一行
    //    /// <summary>
    //    /// 读取Excel指定Sheet页最后一行
    //    /// </summary>
    //    /// <param name="sheetIndex">Sheet页索引（从0开始）</param>
    //    /// <param name="headIndex">表头所在行索引（从0开始）</param>
    //    /// <returns></returns>
    //    public DataTable ReadLastRow(int sheetIndex, int headIndex)
    //    {
    //        var sheet = (HSSFSheet)_workbook.GetSheetAt(sheetIndex);
    //        var rows = sheet.LastRowNum;

    //        if (rows <= 0)
    //            throw new Exception("There is not rows in Sheet ");

    //        var row = sheet.GetRow(rows);
    //        var cols = row.LastCellNum;

    //        var headrow = sheet.GetRow(headIndex);
    //        var table = BuildDataTable(headrow, cols);
    //        var dataRow = table.NewRow();

    //        for (var j = _columnHeadCol; j < cols; j++)
    //        {
    //            var cell = (HSSFCell)(row.GetCell(j));
    //            if (cell == null)
    //            {
    //                dataRow[j] = "";
    //                continue;
    //            }
    //            var value = cell.CellType == CellType.NUMERIC ? cell.NumericCellValue.ToString().Replace("_", "") : cell.ToString();
    //            if (cell.CellType == CellType.FORMULA) //公式型：FORMULA
    //            {
    //                if (cell.CachedFormulaResultType == CellType.STRING)
    //                    value = cell.StringCellValue;
    //                if (cell.CachedFormulaResultType == CellType.NUMERIC)
    //                    value = cell.NumericCellValue.ToString();
    //            }
    //            dataRow[j] = value;
    //        }

    //        table.Rows.Add(dataRow);

    //        return table;
    //    }

    //    //读取Excel数据到DataSet
    //    /// <summary>
    //    /// 读取Excel数据到DataSet
    //    /// </summary>
    //    private void ReadToDataSet()
    //    {
    //        DataSet = new DataSet();
    //        for (var i = 0; i < _totalSheetCount; i++)
    //        {
    //            var sheet = (HSSFSheet)_workbook.GetSheetAt(i);
    //            ReadToDataTable(sheet, i);
    //        }
    //    }

    //    //读取Excel数据到DataTable
    //    /// <summary>
    //    /// 读取Excel数据到DataTable
    //    /// </summary>
    //    /// <param name="sheet"></param>
    //    /// <param name="currentSheetIndex"></param>
    //    private void ReadToDataTable(ISheet sheet, int currentSheetIndex)
    //    {
    //        var rows = sheet.LastRowNum + 1;
    //        if (rows <= 0)
    //            throw new Exception("There is not rows in Sheet " + currentSheetIndex);
    //        var row = sheet.GetRow(_columnHeadRow);
    //        var cols = row.LastCellNum;

    //        var table = BuildDataTable(row, cols);

    //        ReadRecordsToDataTable(table, sheet, rows, cols);
    //    }

    //    //构造DataTable
    //    /// <summary>
    //    /// 构造DataTable
    //    /// </summary>
    //    /// <param name="row"></param>
    //    /// <param name="cols"></param>
    //    /// <returns></returns>
    //    private DataTable BuildDataTable(IRow row, int cols)
    //    {
    //        var table = new DataTable();

    //        for (var i = _columnHeadCol; i < cols; i++)
    //        {
    //            var cell = row.GetCell(i);
    //            if (cell == null)
    //                throw new Exception("Excel格式不正确");
    //            var col =
    //                new DataColumn(
    //                    cell.ToString().Trim().Replace("(", "").Replace(")", "").Replace(" ", "").Replace(":", "").
    //                        Replace(".", ""), typeof(string));
    //            table.Columns.Add(col);
    //        }

    //        return table;
    //    }

    //    //读取数据到DataTable
    //    /// <summary>
    //    /// 读取数据到DataTable
    //    /// </summary>
    //    /// <param name="table"></param>
    //    /// <param name="sheet"></param>
    //    /// <param name="rows"></param>
    //    /// <param name="cols"></param>
    //    private void ReadRecordsToDataTable(DataTable table, ISheet sheet, int rows, int cols)
    //    {
    //        for (var i = _columnHeadRow + 1; i < rows; i++)
    //        {
    //            var row = sheet.GetRow(i);
    //            if (row == null)
    //                break;

    //            var dataRow = table.NewRow();

    //            for (var j = _columnHeadCol; j < cols; j++)
    //            {
    //                var cell = (HSSFCell)(row.GetCell(j));
    //                if (cell == null)
    //                {
    //                    dataRow[j] = "";
    //                    continue;
    //                }
    //                var value = cell.CellType == CellType.NUMERIC ? cell.NumericCellValue.ToString().Replace("_", "") : cell.ToString();
    //                if (cell.CellType == CellType.FORMULA) //公式型：FORMULA
    //                {
    //                    if (cell.CachedFormulaResultType == CellType.STRING)
    //                        value = cell.StringCellValue;
    //                    if (cell.CachedFormulaResultType == CellType.NUMERIC)
    //                        value = cell.NumericCellValue.ToString();
    //                }
    //                dataRow[j] = value;
    //            }

    //            table.Rows.Add(dataRow);
    //        }
    //        DataSet.Tables.Add(table);
    //    }

    //    //构造Excel文件信息
    //    /// <summary>
    //    /// 构造Excel文件信息
    //    /// </summary>
    //    /// <param name="fullFileName"></param>
    //    private void BuildFileInfo(string fullFileName)
    //    {
    //        if (!File.Exists(fullFileName))
    //            throw new Exception("文件未找到！");

    //        _fileInfo = new FileInfo(fullFileName);

    //        CheckExcelVersion();
    //    }

    //    //判断Excel版本
    //    /// <summary>
    //    /// 判断Excel版本
    //    /// </summary>
    //    private void CheckExcelVersion()
    //    {
    //        if (_fileInfo == null)
    //            throw new Exception("");

    //        if (_fileInfo.Extension.ToLower() != ".xls")
    //            throw new Exception("只支持1997--2003版本的Excel文件");
    //    }

    //    //构造Excel工作表
    //    /// <summary>
    //    /// 构造Excel工作表
    //    /// </summary>
    //    private void BuildWorkbook()
    //    {
    //        try
    //        {
    //            var stream = new FileStream(_fileInfo.FullName, FileMode.Open, FileAccess.Read);
    //            _workbook = new HSSFWorkbook(stream);
    //            stream.Close();
    //            stream.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Excel打开失败：" + ex.Message);
    //        }
    //    }
    //}

    ////Excel处理
    ///// <summary>
    ///// Excel处理
    ///// </summary>
    //public class FastExcel2007 : IFastExcel
    //{
    //    //FastExcel
    //    /// <summary>
    //    /// FastExcel
    //    /// </summary>
    //    /// <param name="fullFileName">Excel文件全路径</param>
    //    /// <param name="totalSheetCount">总Sheet页数</param>
    //    /// <param name="columnHeadRow">列头起始行号</param>
    //    /// <param name="columnHeadCol">列头起始列号</param>
    //    public FastExcel2007(string fullFileName, int totalSheetCount, int columnHeadRow, int columnHeadCol)
    //    {
    //        BuildFileInfo(fullFileName);
    //        BuildWorkbook();

    //        _totalSheetCount = totalSheetCount;
    //        _columnHeadRow = columnHeadRow;
    //        _columnHeadCol = columnHeadCol;

    //        ReadToDataSet();
    //    }

    //    //Excel文件信息
    //    /// <summary>
    //    /// Excel文件信息
    //    /// </summary>
    //    private FileInfo _fileInfo;
    //    //总Sheet页数
    //    /// <summary>
    //    /// 总Sheet页数
    //    /// </summary>
    //    private readonly int _totalSheetCount;
    //    //列头起始行号
    //    /// <summary>
    //    /// 列头起始行号
    //    /// </summary>
    //    private readonly int _columnHeadRow;
    //    //列头起始列号
    //    /// <summary>
    //    /// 列头起始列号
    //    /// </summary>
    //    private readonly int _columnHeadCol;
    //    //Excel工作表
    //    /// <summary>
    //    /// Excel工作表
    //    /// </summary>
    //    private IWorkbook _workbook;

    //    //错误消息
    //    /// <summary>
    //    /// 错误消息
    //    /// </summary>
    //    public string ErrorMessage { get; set; }
    //    //读取到的Excel数据
    //    /// <summary>
    //    /// 读取到的Excel数据
    //    /// </summary>
    //    public DataSet DataSet { get; set; }

    //    //读取Excel指定Sheet页指定行列的值
    //    /// <summary>
    //    /// 读取Excel指定Sheet页指定行列的值
    //    /// </summary>
    //    /// <param name="sheetIndex">Sheet页索引（从0开始）</param>
    //    /// <param name="rowIndex">行索引（从0开始）</param>
    //    /// <param name="colIndex">列索引（从0开始）</param>
    //    /// <returns></returns>
    //    public string ReadCellValue(int sheetIndex, int rowIndex, int colIndex)
    //    {
    //        var sheet = _workbook.GetSheetAt(sheetIndex);
    //        var row = sheet.GetRow(rowIndex);
    //        if (row == null)
    //            return "";
    //        var cell = row.GetCell(colIndex);
    //        return cell == null ? "" : cell.ToString();
    //    }

    //    //读取Excel指定Sheet页最后一行
    //    /// <summary>
    //    /// 读取Excel指定Sheet页最后一行
    //    /// </summary>
    //    /// <param name="sheetIndex"></param>
    //    /// <param name="headIndex"></param>
    //    /// <returns></returns>
    //    public DataTable ReadLastRow(int sheetIndex, int headIndex)
    //    {
    //        var sheet = _workbook.GetSheetAt(sheetIndex);
    //        var rows = sheet.LastRowNum;

    //        if (rows <= 0)
    //            throw new Exception("There is not rows in Sheet ");

    //        var row = sheet.GetRow(rows);
    //        var cols = row.LastCellNum;

    //        var headrow = sheet.GetRow(headIndex);
    //        var table = BuildDataTable(headrow, cols);
    //        var dataRow = table.NewRow();

    //        for (var j = _columnHeadCol; j < cols; j++)
    //        {
    //            var cell = row.GetCell(j);
    //            if (cell == null)
    //            {
    //                dataRow[j] = "";
    //                continue;
    //            }
    //            var value = cell.CellType == CellType.NUMERIC ? cell.NumericCellValue.ToString().Replace("_", "") : cell.ToString();
    //            if (cell.CellType == CellType.FORMULA) //公式型：FORMULA
    //            {
    //                if (cell.CachedFormulaResultType == CellType.STRING)
    //                    value = cell.StringCellValue;
    //                if (cell.CachedFormulaResultType == CellType.NUMERIC)
    //                    value = cell.NumericCellValue.ToString();
    //            }
    //            dataRow[j] = value;
    //        }

    //        table.Rows.Add(dataRow);

    //        return table;
    //    }

    //    //读取Excel数据到DataSet
    //    /// <summary>
    //    /// 读取Excel数据到DataSet
    //    /// </summary>
    //    private void ReadToDataSet()
    //    {
    //        DataSet = new DataSet();
    //        for (var i = 0; i < _totalSheetCount; i++)
    //        {
    //            var sheet = _workbook.GetSheetAt(i);
    //            ReadToDataTable(sheet, i);
    //        }
    //    }

    //    //读取Excel数据到DataTable
    //    /// <summary>
    //    /// 读取Excel数据到DataTable
    //    /// </summary>
    //    /// <param name="sheet"></param>
    //    /// <param name="currentSheetIndex"></param>
    //    private void ReadToDataTable(ISheet sheet, int currentSheetIndex)
    //    {
    //        var rows = sheet.LastRowNum + 1;
    //        if (rows <= 0)
    //            throw new Exception("There is not rows in Sheet " + currentSheetIndex);
    //        var row = sheet.GetRow(_columnHeadRow);
    //        var cols = row.LastCellNum;

    //        var table = BuildDataTable(row, cols);

    //        ReadRecordsToDataTable(table, sheet, rows, cols);
    //    }

    //    //构造DataTable
    //    /// <summary>
    //    /// 构造DataTable
    //    /// </summary>
    //    /// <param name="row"></param>
    //    /// <param name="cols"></param>
    //    /// <returns></returns>
    //    private DataTable BuildDataTable(IRow row, int cols)
    //    {
    //        var table = new DataTable();

    //        for (var i = _columnHeadCol; i < cols; i++)
    //        {
    //            var cell = row.GetCell(i);
    //            var col =
    //                new DataColumn(
    //                    cell.ToString().Trim().Replace("(", "").Replace(")", "").Replace(" ", "").Replace(":", "").
    //                        Replace(".", ""), typeof(string));
    //            table.Columns.Add(col);
    //        }

    //        return table;
    //    }

    //    //读取数据到DataTable
    //    /// <summary>
    //    /// 读取数据到DataTable
    //    /// </summary>
    //    /// <param name="table"></param>
    //    /// <param name="sheet"></param>
    //    /// <param name="rows"></param>
    //    /// <param name="cols"></param>
    //    private void ReadRecordsToDataTable(DataTable table, ISheet sheet, int rows, int cols)
    //    {
    //        for (var i = _columnHeadRow + 1; i < rows; i++)
    //        {
    //            var row = sheet.GetRow(i);
    //            if (row == null)
    //                break;

    //            var dataRow = table.NewRow();

    //            for (var j = _columnHeadCol; j < cols; j++)
    //            {
    //                var cell = row.GetCell(j);
    //                if (cell == null)
    //                {
    //                    dataRow[j] = "";
    //                    continue;
    //                }
    //                var value = cell.CellType == CellType.NUMERIC ? cell.NumericCellValue.ToString().Replace("_", "") : cell.ToString();
    //                if (cell.CellType == CellType.FORMULA) //公式型：FORMULA
    //                {
    //                    if (cell.CachedFormulaResultType == CellType.STRING)
    //                        value = cell.StringCellValue;
    //                    if (cell.CachedFormulaResultType == CellType.NUMERIC)
    //                        value = cell.NumericCellValue.ToString();
    //                }
    //                dataRow[j] = value;
    //            }

    //            table.Rows.Add(dataRow);
    //        }
    //        DataSet.Tables.Add(table);
    //    }

    //    //构造Excel文件信息
    //    /// <summary>
    //    /// 构造Excel文件信息
    //    /// </summary>
    //    /// <param name="fullFileName"></param>
    //    private void BuildFileInfo(string fullFileName)
    //    {
    //        if (!File.Exists(fullFileName))
    //            throw new Exception("文件未找到！");

    //        _fileInfo = new FileInfo(fullFileName);

    //        CheckExcelVersion();
    //    }

    //    //判断Excel版本
    //    /// <summary>
    //    /// 判断Excel版本
    //    /// </summary>
    //    private void CheckExcelVersion()
    //    {
    //        if (_fileInfo == null)
    //            throw new Exception("");

    //        if (_fileInfo.Extension.ToLower() != ".xlsx")
    //            throw new Exception("只支持2007以上版本的Excel文件");
    //    }

    //    //构造Excel工作表
    //    /// <summary>
    //    /// 构造Excel工作表
    //    /// </summary>
    //    private void BuildWorkbook()
    //    {
    //        try
    //        {
    //            var stream = new FileStream(_fileInfo.FullName, FileMode.Open, FileAccess.Read);
    //            _workbook = new XSSFWorkbook(stream);
    //            stream.Close();
    //            stream.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Excel打开失败：" + ex.Message);
    //        }
    //    }
    //}
    
    public class FastCSV
    {
        public FastCSV(string cSvFile)
        {
            _csvFile = cSvFile;
        }

        /// <summary>
        /// CSV文件
        /// </summary>
        private readonly string _csvFile;

        #region 读CSV文件

        /// <summary>
        /// 读1
        /// </summary>
        /// <returns></returns>
        public DataTable Read()
        {
            var fi = new FileInfo(_csvFile);

            if (!fi.Exists) return null;

            using (var reader = new StreamReader(_csvFile))
            {
                string line;
                var lineNumber = 0;

                var dt = new DataTable();

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber == 0)
                    {
                        dt = CreateDataTable(line);
                        if (dt.Columns.Count == 0) return null;
                    }
                    else
                    {
                        var isSuccess = CreateDataRow(ref dt, line);
                        if (!isSuccess) return null;
                    }

                    lineNumber++;
                }

                return dt;
            }
        }

        /// <summary>
        /// 读2
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static DataTable CreateDataTable(string line)
        {
            var dt = new DataTable();
            foreach (var field in line.Split(FormatSplit, StringSplitOptions.None))
            {
                var fieldstr =
                    field.Trim().Replace("(", "").Replace(")", "").Replace(" ", "").Replace(":", "").Replace(".", "");
                dt.Columns.Add(fieldstr);
            }
            return dt;
        }

        /// <summary>
        /// 读3
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private static bool CreateDataRow(ref DataTable dt, string line)
        {
            var dr = dt.NewRow();

            var fileds = line.Split(FormatSplit, StringSplitOptions.None);

            if (fileds.Length == 0 || fileds.Length != dt.Columns.Count) return false;

            for (var i = 0; i < fileds.Length; i++)
            {
                dr[i] = fileds[i];
            }

            dt.Rows.Add(dr);
            return true;
        }

        #endregion

        #region 写CSV文件

        /// <summary>
        /// 写1
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool Write(DataTable dt)
        {
            var fi = new FileInfo(_csvFile);
            if (!fi.Exists) return false;

            if (dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0) return false;

            var writer = new StreamWriter(_csvFile);
            //writer.AutoFlush = true;  

            var line = CreateTitle(dt);
            writer.WriteLine(line);

            foreach (DataRow dr in dt.Rows)
            {
                line = CretreLine(dr);
                writer.WriteLine(line);
            }

            writer.Flush();

            return true;
        }

        /// <summary>
        /// 写2
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static string CreateTitle(DataTable dt)
        {
            var line = string.Empty;

            for (var i = 0; i < dt.Columns.Count; i++)
            {
                line += string.Format("{0}{1}", dt.Columns[i].ColumnName, FormatSplit[0]);
            }

            line.TrimEnd(FormatSplit[0]);

            return line;
        }

        /// <summary>
        /// 写2
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static string CretreLine(DataRow dr)
        {
            var line = string.Empty;

            for (var i = 0; i < dr.ItemArray.Length; i++)
            {
                line += string.Format("{0}{1}", dr[i], FormatSplit[0]);
            }

            line.TrimEnd(FormatSplit[0]);

            return line;
        }

        private static char[] FormatSplit
        {
            get { return new[] { ',' }; }
        }

        #endregion
    }

    ///// <summary>
    ///// DataTable导出到Excel文件
    ///// </summary>
    ///// <param name="dtSource">源DataTable</param>
    ///// <param name="strHeaderText">表头文本</param>
    ///// <param name="strFileName">保存位置</param>
    ///// <Author>柳永法 http://www.yongfa365.com/ 2010-5-8 22:21:41</Author>
    //public static void ExportToExcel(DataTable dtSource, string strHeaderText, string strFileName)
    //{
    //    var saveDialog = new SaveFileDialog
    //    {
    //        DefaultExt = "xls",
    //        Filter = "Excel 文件|*.xls",
    //        FileName = strFileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls"
    //    };

    //    if (saveDialog.ShowDialog() != DialogResult.OK)
    //        return;

    //    var fileName = saveDialog.FileName;

    //    if (string.IsNullOrEmpty(fileName))
    //        return;


    //    HSSFWorkbook workbook = new HSSFWorkbook();

    //    using (MemoryStream ms = ExportExcel(dtSource, strHeaderText, out workbook))
    //    {
    //        using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
    //        {
    //            //byte[] data = ms.ToArray();
    //            //fs.Write(data, 0, data.Length);
    //            //fs.Flush();

    //            var file = new FileStream(fileName, FileMode.Create);
    //            workbook.Write(file);
    //            file.Close();

    //        }
    //    }
    //}

    ///// <summary>
    ///// DataTable导出到Excel的MemoryStream
    ///// </summary>
    ///// <param name="dtSource">源DataTable</param>
    ///// <param name="strHeaderText">表头文本</param>
    ///// <Author>柳永法 http://www.yongfa365.com/ 2010-5-8 22:21:41</Author>
    //public static MemoryStream ExportExcel(DataTable dtSource, string strHeaderText, out HSSFWorkbook workbook)
    //{
    //    workbook = new HSSFWorkbook();
    //    HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();

    //    #region 右击文件 属性信息
    //    {
    //        DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
    //        dsi.Company = "http://www.yongfa365.com/";
    //        workbook.DocumentSummaryInformation = dsi;

    //        SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
    //        si.Author = "柳永法"; //填加xls文件作者信息
    //        si.ApplicationName = "NPOI测试程序"; //填加xls文件创建程序信息
    //        si.LastAuthor = "柳永法2"; //填加xls文件最后保存者信息
    //        si.Comments = "说明信息"; //填加xls文件作者信息
    //        si.Title = "NPOI测试"; //填加xls文件标题信息
    //        si.Subject = "NPOI测试Demo";//填加文件主题信息
    //        si.CreateDateTime = DateTime.Now;
    //        workbook.SummaryInformation = si;
    //    }
    //    #endregion

    //    HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
    //    HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
    //    dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

    //    //取得列宽
    //    int[] arrColWidth = new int[dtSource.Columns.Count];
    //    foreach (DataColumn item in dtSource.Columns)
    //    {
    //        arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
    //    }
    //    for (int i = 0; i < dtSource.Rows.Count; i++)
    //    {
    //        for (int j = 0; j < dtSource.Columns.Count; j++)
    //        {
    //            int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
    //            if (intTemp > arrColWidth[j])
    //            {
    //                arrColWidth[j] = intTemp;
    //            }
    //        }
    //    }



    //    int rowIndex = 0;

    //    foreach (DataRow row in dtSource.Rows)
    //    {
    //        #region 新建表，填充表头，填充列头，样式
    //        if (rowIndex == 65535 || rowIndex == 0)
    //        {
    //            if (rowIndex != 0)
    //            {
    //                sheet = (HSSFSheet)workbook.CreateSheet();
    //            }

    //            #region 表头及样式
    //            {
    //                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
    //                headerRow.HeightInPoints = 25;
    //                headerRow.CreateCell(0).SetCellValue(strHeaderText);

    //                HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
    //                //headStyle.Alignment = CellHorizontalAlignment.CENTER;
    //                HSSFFont font = (HSSFFont)workbook.CreateFont();
    //                font.FontHeightInPoints = 20;
    //                font.Boldweight = 700;
    //                headStyle.SetFont(font);

    //                headerRow.GetCell(0).CellStyle = headStyle;

    //                //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
    //                //headerRow.Dispose();
    //            }
    //            #endregion


    //            #region 列头及样式
    //            {
    //                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(1);


    //                HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
    //                //headStyle.Alignment = CellHorizontalAlignment.CENTER;
    //                HSSFFont font = (HSSFFont)workbook.CreateFont();
    //                font.FontHeightInPoints = 10;
    //                font.Boldweight = 700;
    //                headStyle.SetFont(font);


    //                foreach (DataColumn column in dtSource.Columns)
    //                {
    //                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
    //                    headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

    //                    //设置列宽
    //                    sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

    //                }
    //                //headerRow.Dispose();
    //            }
    //            #endregion

    //            rowIndex = 2;
    //        }
    //        #endregion


    //        #region 填充内容
    //        HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
    //        foreach (DataColumn column in dtSource.Columns)
    //        {
    //            HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

    //            string drValue = row[column].ToString();

    //            switch (column.DataType.ToString())
    //            {
    //                case "System.String"://字符串类型
    //                    newCell.SetCellValue(drValue);
    //                    break;
    //                case "System.DateTime"://日期类型
    //                    DateTime dateV;
    //                    DateTime.TryParse(drValue, out dateV);
    //                    newCell.SetCellValue(dateV);

    //                    newCell.CellStyle = dateStyle;//格式化显示
    //                    break;
    //                case "System.Boolean"://布尔型
    //                    bool boolV = false;
    //                    bool.TryParse(drValue, out boolV);
    //                    newCell.SetCellValue(boolV);
    //                    break;
    //                case "System.Int16"://整型
    //                case "System.Int32":
    //                case "System.Int64":
    //                case "System.Byte":
    //                    int intV = 0;
    //                    int.TryParse(drValue, out intV);
    //                    newCell.SetCellValue(intV);
    //                    break;
    //                case "System.Decimal"://浮点型
    //                case "System.Double":
    //                    double doubV = 0;
    //                    double.TryParse(drValue, out doubV);
    //                    newCell.SetCellValue(doubV);
    //                    break;
    //                case "System.DBNull"://空值处理
    //                    newCell.SetCellValue("");
    //                    break;
    //                default:
    //                    newCell.SetCellValue("");
    //                    break;
    //            }

    //        }
    //        #endregion

    //        rowIndex++;
    //    }


    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        workbook.Write(ms);
    //        ms.Flush();
    //        ms.Position = 0;

    //        //sheet.Dispose();
    //        //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
    //        return ms;
    //    }

    //}

    //public static void DataGridViewToExcel(DataGridView dgv)
    //{
    //    SaveFileDialog saveFileDialog = new SaveFileDialog();
    //    saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
    //    saveFileDialog.FilterIndex = 0;
    //    saveFileDialog.RestoreDirectory = true;
    //    saveFileDialog.CreatePrompt = true;
    //    saveFileDialog.Title = "Export Excel File";
    //    saveFileDialog.ShowDialog();
    //    if (saveFileDialog.FileName == "")
    //        return;
    //    Stream myStream;
    //    myStream = saveFileDialog.OpenFile();
    //    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

    //    string str = "";
    //    try
    //    {
    //        for (int i = 0; i < dgv.ColumnCount; i++)
    //        {
    //            if (!dgv.Columns[i].Visible) continue;
    //            if (i > 0)
    //            {
    //                str += "\t";
    //            }
    //            str += dgv.Columns[i].HeaderText;
    //        }
    //        sw.WriteLine(str);
    //        for (int j = 0; j < dgv.Rows.Count; j++)
    //        {
    //            string tempStr = "";
    //            for (int k = 0; k < dgv.Columns.Count; k++)
    //            {
    //                if (!dgv.Columns[k].Visible) continue;
    //                if (k > 0)
    //                {
    //                    tempStr += "\t";
    //                }
    //                if (dgv.Rows[j].Cells[k].Value == null)
    //                    tempStr += string.Empty;
    //                else
    //                {
    //                    var value = dgv.Rows[j].Cells[k].Value.ToString();

    //                    switch (dgv.Rows[j].Cells[k].Value.GetType().Name)
    //                    {
    //                        default:
    //                            tempStr += value + "";//以文本形式显示
    //                            break;
    //                        case "DateTime"://转换时间格式
    //                            var format = dgv.Columns[k].DefaultCellStyle.Format;
    //                            if (string.IsNullOrEmpty(format))
    //                            {
    //                                tempStr += value + "";//以文本形式显示
    //                            }
    //                            else
    //                            {
    //                                tempStr += Convert.ToDateTime(value).ToString(format) + ""; //以文本形式显示
    //                            }
    //                            break;
    //                    }

    //                }

    //            }
    //            sw.WriteLine(tempStr);
    //        }
    //        sw.Close();
    //        myStream.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        //ExceptUtil.Throw(ErrorCodeContract.ExceptionCode, inner: ex, emType: ErrorMsgType.Info);
    //    }
    //    finally
    //    {
    //        sw.Close();
    //        myStream.Close();
    //    }
    //}

}
