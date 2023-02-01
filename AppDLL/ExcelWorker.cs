using AppDLL.Entity;
using OfficeOpenXml;

namespace AppDLL;

public class ExcelWorker
{
    public static byte[] Generate(Human human, List<Order> orders)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var report = new ExcelPackage();
        var sheet = report.Workbook.Worksheets.Add("Отчет по заказам");
        sheet.Cells["B2"].Value = "Пользователь:";
        sheet.Cells["C2"].Value = human.Login;
        sheet.Cells["B3"].Value = "Дата создания отчета:";
        sheet.Cells["C3"].Value = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");


        // Шапка
        sheet.Cells["B7"].Value = "Дата";
        sheet.Cells["C7"].Value = "Адрес от";
        sheet.Cells["D7"].Value = "Адрес до";
        sheet.Cells["E7"].Value = "Комментарий";
        sheet.Cells["F7"].Value = "Стоимость";

        int row = 8;
        int column = 2;

        foreach (var order in orders)
        {
            sheet.Cells[row, column + 0].Value = order.OrderTime.ToString("dd.MM.yyyy hh:mm:ss");
            sheet.Cells[row, column + 1].Value = order.AddressFrom;
            sheet.Cells[row, column + 2].Value = order.AddressTo;
            sheet.Cells[row, column + 3].Value = order.Commentary;
            sheet.Cells[row, column + 4].Value = order.Price;
            row++;
        }

        return report.GetAsByteArray();
    }
}
