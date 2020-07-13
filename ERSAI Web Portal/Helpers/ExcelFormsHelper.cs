using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ERSAI_Web_Portal.Helpers
{
    public static class ExcelFormsHelper
    {
        private static string ExcelFormsPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Content/ExcelFormTemplates");

        private const string
            LeaveRequestFormFileName = "ERSAI-HR-008-E-R.xlsx";

        public static XLWorkbook GetLeaveRequestForm(DataModels.Models.IMS.Employee employee)
        {
            var book = new XLWorkbook(Path.Combine(ExcelFormsPath, LeaveRequestFormFileName));
            var sheet = book.Worksheets.First();

            var badgeCellsEnumerator = sheet.Range("D12:O12").Cells().GetEnumerator();

            employee.BadgeNumber.ForEach(symbol =>
            {
                badgeCellsEnumerator.MoveNext();

                badgeCellsEnumerator.Current.Value = symbol;
            });

            //FullName
            sheet.Cell("D13").Value = employee.FullName;

            //Position
            sheet.Cell("D14").Value = $"{employee.ContractPosition?.Name} / {employee.ContractPosition?.DescrLoc}";

            //CostCenter
            sheet.Cell("U12").Value = employee.CostCenter?.Descr;

            //LastVacationLastDate
            sheet.Cell("U13").Value = $"{employee.LastVacationLastDate?.ToShortDateString()}";

            //Hiring Date
            sheet.Cell("U13").Value = $"{employee.ContractStartDate?.ToShortDateString()}";

            //Visa/WP Expiration Date
            sheet.Cell("G35").Value = $"{employee.VisaExpirationDate?.ToShortDateString()}\n{employee.WorkPermitExpirationDate?.ToShortDateString()}";

            if (employee.LastVacationLastDate != null && employee.RotationType?.DayOn != null)
            {
                //Vacation From
                sheet.Cell("G39").Value = (employee.LastVacationLastDate.Value.AddDays(employee.RotationType.DayOn.Value)).ToShortDateString();
            }

            //Ticket class
            if (employee.AirlineTicketTypeID == 0)
                sheet.Cell("G42").Value = "X";
            else if (employee.AirlineTicketTypeID == 0)
                sheet.Cell("G43").Value = "X";

            sheet.Style.Alignment.WrapText = true;

            return book;
        }
    }
}