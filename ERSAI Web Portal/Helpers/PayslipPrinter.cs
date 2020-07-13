using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal.Helpers
{
    public static class PayslipPrinter
    {
        private static MemoryStream _GetPayslipPDF(PayslipModelForPDF model)
        {
            bool grossRowAdded = false;
            using (var memoryStream = new MemoryStream())
            {
                string ARIALUNI_TFF = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("windir"), "Fonts"), "ARIALUNI.TTF");
                BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);


                string Courier_TFF = Path.Combine(Path.Combine(System.Environment.GetEnvironmentVariable("windir"), "Fonts"), "COUR.TTF");
                BaseFont bf3 = BaseFont.CreateFont(Courier_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font cf9 = new Font(bf3, 9, Font.NORMAL);


                Font big = new Font(bf, 18, Font.NORMAL);
                Font f9 = new Font(bf, 9, Font.NORMAL);
                Font f9b = new Font(bf, 9, Font.BOLD);
                Font f20b = new Font(bf, 20, Font.BOLD);
                Font f12 = new Font(bf, 12, Font.NORMAL);
                Font i = new Font(bf, 9, Font.ITALIC);
                Font u = new Font(bf, 9, Font.UNDERLINE);
                Font fb = new Font(bf, 9, Font.BOLD);




                PdfPCell emptyCell = new PdfPCell();
                emptyCell.Border = Rectangle.NO_BORDER;

                Document document = new Document(PageSize.A4, 20, 20, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                //
                PdfPTable CompanyTable = new PdfPTable(1);
                CompanyTable.WidthPercentage = 100f;

                PdfPCell c1 = new PdfPCell();
                c1.VerticalAlignment = Element.ALIGN_MIDDLE;

                if (model.CompanyName.Contains("ERSAI"))
                {
                    c1.AddElement(new Paragraph("ERSAI Caspian Contractor, LLC", big));
                }

                if (model.CompanyName.Contains("SAKAZ"))
                {
                    c1.AddElement(new Paragraph("SAIPEM Kazakhstan, LLC", big));
                }


                if (model.CompanyName.Contains("PROTC"))
                {
                    c1.AddElement(new Paragraph("Proffecianal Training Center, LLC", big));
                }

                c1.Border = PdfPCell.BOTTOM_BORDER;
                c1.BorderWidthBottom = 1f;
                c1.FixedHeight = 37f;

                CompanyTable.AddCell(c1);
                document.Add(CompanyTable);

                //
                PdfPTable secondLine = new PdfPTable(3);

                secondLine.WidthPercentage = 100f;
                float[] widths = new float[] { 2f, 2f, 2f };
                secondLine.SetWidths(widths);

                PdfPCell r2c1 = new PdfPCell();
                r2c1.Border = Rectangle.NO_BORDER;

                if (model.LangCode == "1")
                {
                    r2c1.AddElement(new Paragraph(model.MonthName, f12));
                }
                else if (model.LangCode == "3")
                {
                    r2c1.AddElement(new Paragraph(model.MonthName, f12));
                }
                else
                {
                    r2c1.AddElement(new Paragraph(model.MonthName, f12));
                }

                PdfPCell r2c3 = new PdfPCell();
                r2c3.Border = Rectangle.NO_BORDER;
                if (model.LangCode == "1")
                {
                    r2c3.AddElement(new Paragraph("КОНФИДЕНЦИАЛЬНО", f12));
                }
                else if (model.LangCode == "3")
                {
                    r2c3.AddElement(new Paragraph("КОНФИДЕНЦИАЛЬНО", f12));
                }
                else
                {
                    r2c3.AddElement(new Paragraph("PRIVATE/CONFIDENTIAL", f12));
                }

                r2c3.HorizontalAlignment = Element.ALIGN_RIGHT;

                secondLine.AddCell(r2c1);
                secondLine.AddCell(emptyCell);
                secondLine.AddCell(r2c3);

                secondLine.SpacingAfter = 30f;

                document.Add(secondLine);

                //description table
                PdfPTable descTable = new PdfPTable(11);
                //float[] widths2 = new float[] { 6f, 1f, 3f, 1f, 8f, 1f, 8f, 1f, 13f, 1f, 6f };
                float[] widths2 = new float[] { 6f, 1f, 3f, 1f, 8f, 1f, 8f, 1f, 3f, 1f, 6f };
                descTable.SetWidths(widths2);
                descTable.TotalWidth = PageSize.A4.Width - 40;
                descTable.LockedWidth = true;

                PdfPCell rr1c1;
                if (model.LangCode == "1")
                {
                    rr1c1 = new PdfPCell(new Phrase("Таб. Номері", cf9));
                }
                else if (model.LangCode == "3")
                {
                    rr1c1 = new PdfPCell(new Phrase("Таб. номер", cf9));
                }
                else
                {
                    rr1c1 = new PdfPCell(new Phrase("Badge No.", cf9));
                }

                rr1c1.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr1c1);

                PdfPCell rr1c2 = new PdfPCell(new Phrase(":", cf9));
                rr1c2.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr1c2);


                PdfPCell rr1c3 = new PdfPCell(new Phrase(model.BadgeNumber, cf9));
                rr1c3.Colspan = 2;
                rr1c3.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr1c3);

                descTable.AddCell(emptyCell);
                descTable.AddCell(emptyCell);

                PdfPCell rr1c7;
                if (model.LangCode == "1")
                {
                    rr1c7 = new PdfPCell(new Phrase("Шығын орталығы", cf9));
                }
                else if (model.LangCode == "3")
                {
                    rr1c7 = new PdfPCell(new Phrase("Центр расходов", cf9));
                }
                else
                {
                    rr1c7 = new PdfPCell(new Phrase("Cost Center", cf9));
                }

                rr1c7.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr1c7);

                PdfPCell rr1c8 = new PdfPCell(new Phrase(":", cf9));
                rr1c8.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr1c8);

                PdfPCell rr1c9 = new PdfPCell(new Phrase(model.CostCenter, cf9));
                rr1c9.Border = Rectangle.NO_BORDER;
                rr1c9.Colspan = 3;
                descTable.AddCell(rr1c9);


                //second row!!!
                PdfPCell rr2c1;
                if (model.LangCode == "1")
                {
                    rr2c1 = new PdfPCell(new Phrase("Қызметкердің аты-жөні", cf9));
                }
                else if (model.LangCode == "3")
                {
                    rr2c1 = new PdfPCell(new Phrase("Ф.И.О работника", cf9));
                }
                else
                {
                    rr2c1 = new PdfPCell(new Phrase("Employee Name", cf9));
                }

                rr2c1.Border = Rectangle.NO_BORDER;

                descTable.AddCell(rr2c1);

                PdfPCell rr2c2 = new PdfPCell(new Phrase(":", cf9));
                rr2c2.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr2c2);

                PdfPCell rr2c3 = new PdfPCell(new Phrase(model.Name, cf9));
                rr2c3.Colspan = 3;
                rr2c3.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr2c3);

                descTable.AddCell(emptyCell);

                PdfPCell rr2c7;
                if (model.LangCode == "1")
                {
                    rr2c7 = new PdfPCell(new Phrase("Бөлімі", cf9));
                }
                else if (model.LangCode == "3")
                {
                    rr2c7 = new PdfPCell(new Phrase("Департамент", cf9));
                }
                else
                {
                    rr2c7 = new PdfPCell(new Phrase("Department", cf9));
                }

                rr2c7.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr2c7);

                PdfPCell rr2c8 = new PdfPCell(new Phrase(":", cf9));
                rr2c8.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr2c8);

                PdfPCell rr2c9 = new PdfPCell(new Phrase(model.Department, cf9));
                rr2c9.Border = Rectangle.NO_BORDER;
                rr2c9.Colspan = 3;
                descTable.AddCell(rr2c9);

                //third row!!!
                PdfPCell rr3c1;
                if (model.LangCode == "1")
                {
                    rr3c1 = new PdfPCell(new Phrase("Лауазымы", cf9));
                }
                else if (model.LangCode == "3")
                {
                    rr3c1 = new PdfPCell(new Phrase("Должность", cf9));
                }
                else
                {
                    rr3c1 = new PdfPCell(new Phrase("Position", cf9));
                }

                rr3c1.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr3c1);

                PdfPCell rr3c2 = new PdfPCell(new Phrase(":", cf9));
                rr3c2.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr3c2);


                PdfPCell rr3c3 = new PdfPCell(new Phrase(model.Position, cf9));
                rr3c3.Colspan = 3;
                rr3c3.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr3c3);

                descTable.AddCell(emptyCell);

                PdfPCell rr3c7;
                if (model.LangCode == "1")
                {
                    rr3c7 = new PdfPCell(new Phrase("Жұмыс орыны", cf9));
                }
                else if (model.LangCode == "3")
                {
                    rr3c7 = new PdfPCell(new Phrase("Место работы", cf9));
                }
                else
                {
                    rr3c7 = new PdfPCell(new Phrase("Work Location", cf9));
                }

                rr3c7.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr3c7);

                PdfPCell rr3c8 = new PdfPCell(new Phrase(":", cf9));
                rr3c8.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr3c8);

                PdfPCell rr3c9 = new PdfPCell(new Phrase(model.WorkLocation, cf9));
                rr3c9.Border = Rectangle.NO_BORDER;
                rr3c9.Colspan = 3;
                descTable.AddCell(rr3c9);

                //fourth row!!!

                PdfPCell rr4c1;
                /*
                if (langCode == "1")
                    {
                        rr4c1 = new PdfPCell(new Phrase("Айлық жалақысы", cf9));
                    }
                else if (langCode == "3")
                    {
                        rr4c1 = new PdfPCell(new Phrase("Ежемесячная заработная плата", cf9));
                    }
                else
                    {
                        rr4c1 = new PdfPCell(new Phrase("Monthly Basic Salary", cf9));
                    }
                */
                rr4c1 = new PdfPCell(new Phrase(model.ContractType, cf9));


                rr4c1.Colspan = 3;
                rr4c1.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr4c1);


                PdfPCell rr4c2 = new PdfPCell(new Phrase(":", cf9));
                rr4c2.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr4c2);

                PdfPCell rr4c3 = new PdfPCell(new Phrase(model.Currency + " " + model.BasicSalary, cf9));
                rr4c3.Colspan = 2;
                rr4c3.Border = Rectangle.NO_BORDER;
                descTable.AddCell(rr4c3);


                if (model.EmpCategory == "E")  // exspats ONLY!!
                {
                    PdfPCell rr4c4;
                    if (model.LangCode == "1")
                    {
                        rr4c4 = new PdfPCell(new Phrase("Демалыс соммасы", cf9));
                    }
                    else if (model.LangCode == "3")
                    {
                        rr4c4 = new PdfPCell(new Phrase("Сумма отпуска", cf9));
                    }
                    else
                    {
                        rr4c4 = new PdfPCell(new Phrase("Y-T-D Vacation Amount", cf9));
                    }

                    rr4c4.Colspan = 3;
                    rr4c4.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr4c4);

                    PdfPCell rr4c5 = new PdfPCell(new Phrase(":", cf9));
                    rr4c5.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr4c5);

                    PdfPCell rr4c6 = new PdfPCell(new Phrase(model.Currency + " " + model.ytdVac, cf9));
                    rr4c6.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr4c6);
                }
                else
                {
                    PdfPCell rr4c4;
                    rr4c4 = new PdfPCell(new Phrase("", cf9));
                    rr4c4.Colspan = 3;
                    rr4c4.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr4c4);

                    PdfPCell rr4c5 = new PdfPCell(new Phrase("", cf9));
                    rr4c5.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr4c5);

                    PdfPCell rr4c6 = new PdfPCell(new Phrase("", cf9));
                    rr4c6.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr4c6);
                }

                //fifth row!!!

                if (model.EmpCategory == "E")  // exspats ONLY!!
                {
                    PdfPCell rr5c1;
                    if (model.LangCode == "1")
                    {
                        rr5c1 = new PdfPCell(new Phrase("Үстеме жұмыс үшін төлем мөлшері", cf9));
                    }
                    else if (model.LangCode == "3")
                    {
                        rr5c1 = new PdfPCell(new Phrase("Ставка  за сверхурочную работу", cf9));
                    }
                    else
                    {
                        rr5c1 = new PdfPCell(new Phrase("Overtime Rate", cf9));
                    }

                    rr5c1.Colspan = 3;
                    rr5c1.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr5c1);

                    PdfPCell rr5c2 = new PdfPCell(new Phrase(":", cf9));
                    rr5c2.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr5c2);

                    PdfPCell rr5c3 = new PdfPCell(new Phrase(model.Currency + " " + model.otRate, cf9));
                    rr5c3.Colspan = 2;
                    rr5c3.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr5c3);

                    PdfPCell rr5c4;
                    if (model.LangCode == "1")
                    {
                        rr5c4 = new PdfPCell(new Phrase("Демалыс күндері", cf9));
                    }
                    else if (model.LangCode == "3")
                    {
                        rr5c4 = new PdfPCell(new Phrase("Дни отпуска", cf9));
                    }
                    else
                    {
                        rr5c4 = new PdfPCell(new Phrase("Y-T-D Vacation Days", cf9));
                    }

                    rr5c4.Colspan = 3;
                    rr5c4.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr5c4);

                    PdfPCell rr5c5 = new PdfPCell(new Phrase(":", cf9));
                    rr5c5.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr5c5);

                    PdfPCell rr5c6 = new PdfPCell(new Phrase(model.hFund, cf9));
                    rr5c6.Border = Rectangle.NO_BORDER;
                    descTable.AddCell(rr5c6);
                }

                descTable.SpacingAfter = 30f;
                document.Add(descTable);

                //PAY SLIP CENTER

                PdfPTable payslipTitle = new PdfPTable(1);
                payslipTitle.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell payslipCell;
                if (model.LangCode == "1")
                {
                    payslipCell = new PdfPCell(new Phrase("Есеп айырысу парағы", f20b));
                }
                else if (model.LangCode == "3")
                {
                    payslipCell = new PdfPCell(new Phrase("Расчетный лист", f20b));
                }
                else
                {
                    payslipCell = new PdfPCell(new Phrase("PAYSLIP", f20b));
                }

                payslipCell.HorizontalAlignment = Element.ALIGN_CENTER;
                payslipCell.Border = Rectangle.NO_BORDER;
                payslipTitle.AddCell(payslipCell);

                payslipTitle.SpacingAfter = 20f;

                document.Add(payslipTitle);

                //CREDITS TABLE
                //header
                PdfPTable CreditTable = new PdfPTable(6);
                float[] widths3 = new float[] { 3f, 11f, 11f, 6f, 6f, 7f };

                CreditTable.TotalWidth = PageSize.A4.Width - 40;
                CreditTable.LockedWidth = true;

                CreditTable.SetWidths(widths3);

                PdfPCell row1c1 = new PdfPCell(new Phrase("No.", cf9));
                row1c1.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                CreditTable.AddCell(row1c1);

                PdfPCell row1c2;
                if (model.LangCode == "1")
                {
                    row1c2 = new PdfPCell(new Phrase("Жалақы сипаттамасы", cf9));
                }
                else if (model.LangCode == "3")
                {
                    row1c2 = new PdfPCell(new Phrase("Описание", cf9));
                }
                else
                {
                    row1c2 = new PdfPCell(new Phrase("Pay Description", cf9));
                }

                row1c2.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                CreditTable.AddCell(row1c2);

                PdfPCell row1c3;
                if (model.LangCode == "1")
                {
                    row1c3 = new PdfPCell(new Phrase("Ескертулер", cf9));
                }
                else if (model.LangCode == "3")
                {
                    row1c3 = new PdfPCell(new Phrase("Помечание", cf9));
                }
                else
                {
                    row1c3 = new PdfPCell(new Phrase("Pay Remarks", cf9));
                }

                row1c3.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                CreditTable.AddCell(row1c3);

                PdfPCell row1c4;
                if (model.LangCode == "1")
                {
                    row1c4 = new PdfPCell(new Phrase("Сағат  ", cf9));
                }
                else if (model.LangCode == "3")
                {
                    row1c4 = new PdfPCell(new Phrase("Часы", cf9));
                }
                else
                {
                    row1c4 = new PdfPCell(new Phrase("Unit", cf9));
                }

                row1c4.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                row1c4.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                CreditTable.AddCell(row1c4);

                PdfPCell row1c5;
                if (model.LangCode == "1")
                {
                    row1c5 = new PdfPCell(new Phrase("Төлеу м-лшері", cf9));
                }
                else if (model.LangCode == "3")
                {
                    row1c5 = new PdfPCell(new Phrase("Ставка", cf9));
                }
                else
                {
                    row1c5 = new PdfPCell(new Phrase("Rate", cf9));
                }

                row1c5.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                row1c5.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                CreditTable.AddCell(row1c5);

                PdfPCell row1c6;
                if (model.LangCode == "1")
                {
                    row1c6 = new PdfPCell(new Phrase("Жиыны", cf9));
                }
                else if (model.LangCode == "3")
                {
                    row1c6 = new PdfPCell(new Phrase("Итого", cf9));
                }
                else
                {
                    row1c6 = new PdfPCell(new Phrase("Amount", cf9));
                }

                row1c6.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                row1c6.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                CreditTable.AddCell(row1c6);


                using (var con = new SqlConnection(model.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("exec dbo.SP_GetPaySlip_Details @payMonthSelected, @badge, @Language_Code", con))
                    {
                        command.Parameters.AddWithValue("@payMonthSelected", model.PayMonthSelected);
                        command.Parameters.AddWithValue("@badge", model.BadgeNumber);
                        command.Parameters.AddWithValue("@Language_Code", model.LangCode);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //loop through credist and debits. NESTED QUERY!
                                //adding row here
                                var PayCode = reader["PayCode"].ToString();
                                var PayDesc = reader["PayDesc"].ToString();
                                var PayRemarks = reader["PayRemarks"].ToString();
                                var PayUnit = reader["PayUnit"].ToString();
                                var PayRate = reader["PayRate"].ToString();
                                var PaymentAmt = reader["PayAmount"].ToString();
                                var payType = reader["PayType"].ToString();

                                //dynamic row credit

                                if (payType == "2") //credit
                                {
                                    PdfPCell dynamicCell1 = new PdfPCell(new Phrase(PayCode, cf9));
                                    dynamicCell1.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(dynamicCell1);

                                    PdfPCell dynamicCell2 = new PdfPCell(new Phrase(PayDesc, cf9));
                                    dynamicCell2.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(dynamicCell2);

                                    PdfPCell dynamicCell3 = new PdfPCell(new Phrase(PayRemarks, cf9));
                                    dynamicCell3.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(dynamicCell3);

                                    PdfPCell dynamicCell4 = new PdfPCell(new Phrase(PayUnit, cf9));
                                    dynamicCell4.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                    dynamicCell4.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(dynamicCell4);

                                    PdfPCell dynamicCell5 = new PdfPCell(new Phrase(PayRate, cf9));
                                    dynamicCell5.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                    dynamicCell5.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(dynamicCell5);

                                    PdfPCell dynamicCell6 = new PdfPCell(new Phrase(PaymentAmt, cf9));
                                    dynamicCell6.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                    dynamicCell6.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(dynamicCell6);


                                }

                                if (payType == "3") //debit
                                {
                                    //gross row   <----- add total credit gross row first, then debits

                                    if (grossRowAdded == false)
                                    {
                                        PdfPCell rowGc1;
                                        if (model.LangCode == "1")
                                        {
                                            rowGc1 = new PdfPCell(new Phrase("Салыққа дейін жалпы жалақы сомасы", cf9));
                                        }
                                        else if (model.LangCode == "3")
                                        {
                                            rowGc1 = new PdfPCell(new Phrase("Сумма до обложения налога", cf9));
                                        }
                                        else
                                        {
                                            rowGc1 = new PdfPCell(new Phrase("Gross Salary", cf9));
                                        }

                                        rowGc1.Colspan = 5;
                                        rowGc1.Border = Rectangle.BOTTOM_BORDER;

                                        CreditTable.AddCell(rowGc1);

                                        PdfPCell rowGc2 = new PdfPCell(new Phrase(model.GrossSalary, cf9));
                                        rowGc2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                        rowGc2.Border = Rectangle.BOTTOM_BORDER;
                                        CreditTable.AddCell(rowGc2);

                                        //empty row (spacing) after gross salary
                                        PdfPCell rowEmpty = new PdfPCell(new Phrase(" "));
                                        rowEmpty.Border = Rectangle.NO_BORDER;
                                        rowEmpty.Colspan = 6;
                                        CreditTable.AddCell(rowEmpty);
                                        //

                                        grossRowAdded = true;

                                    }

                                    //dynamic debit rows:

                                    PdfPCell debitCell1 = new PdfPCell(new Phrase(PayCode, cf9));
                                    debitCell1.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(debitCell1);

                                    PdfPCell debitCell2 = new PdfPCell(new Phrase(PayDesc, cf9));
                                    debitCell2.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(debitCell2);

                                    PdfPCell debitCell3 = new PdfPCell(new Phrase(PayRemarks, cf9));
                                    debitCell3.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(debitCell3);

                                    PdfPCell debitCell4 = new PdfPCell(new Phrase(PayUnit, cf9));
                                    debitCell4.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                    debitCell4.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(debitCell4);

                                    PdfPCell debitCell5 = new PdfPCell(new Phrase(PayRate, cf9));
                                    debitCell5.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                    debitCell5.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(debitCell5);

                                    PdfPCell debitCell6 = new PdfPCell(new Phrase(PaymentAmt, cf9));
                                    debitCell6.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                    debitCell6.Border = Rectangle.NO_BORDER;
                                    CreditTable.AddCell(debitCell6);



                                }
                            }
                        }
                    }
                }

                if (grossRowAdded == false)
                {
                    //gross row   <----- add gross row first, then debits IF THERE WERE NO DEBITS:
                    PdfPCell rowGc1;
                    if (model.LangCode == "1")
                    {
                        rowGc1 = new PdfPCell(new Phrase("Салыққа дейін жалпы жалақы сомасы", cf9));
                    }
                    else if (model.LangCode == "3")
                    {
                        rowGc1 = new PdfPCell(new Phrase("Сумма до обложения налога", cf9));
                    }
                    else
                    {
                        rowGc1 = new PdfPCell(new Phrase("Gross Salary", cf9));
                    }

                    rowGc1.Colspan = 5;
                    rowGc1.Border = Rectangle.BOTTOM_BORDER;
                    CreditTable.AddCell(rowGc1);

                    PdfPCell rowGc2 = new PdfPCell(new Phrase(model.GrossSalary, cf9));
                    rowGc2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    rowGc2.Border = Rectangle.BOTTOM_BORDER;
                    CreditTable.AddCell(rowGc2);

                    //empty row (spacing) after gross salary
                    PdfPCell rowEmpty = new PdfPCell(new Phrase(" "));
                    rowEmpty.Border = Rectangle.NO_BORDER;
                    rowEmpty.Colspan = 6;
                    CreditTable.AddCell(rowEmpty);
                    //

                }

                if (model.salaryDeduction != "")
                {
                    //deduction amount row   if deduction is not 0
                    PdfPCell rowGc1;
                    if (model.LangCode == "1")
                    {
                        rowGc1 = new PdfPCell(new Phrase("Жалпы аударымдар", cf9));
                    }
                    else if (model.LangCode == "3")
                    {
                        rowGc1 = new PdfPCell(new Phrase("Общие удержания", cf9));
                    }
                    else
                    {
                        rowGc1 = new PdfPCell(new Phrase("Deductions", cf9));
                    }

                    rowGc1.Colspan = 5;
                    rowGc1.Border = Rectangle.BOTTOM_BORDER;
                    CreditTable.AddCell(rowGc1);

                    PdfPCell rowGc2 = new PdfPCell(new Phrase(model.salaryDeduction, cf9));
                    rowGc2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    rowGc2.Border = Rectangle.BOTTOM_BORDER;
                    CreditTable.AddCell(rowGc2);

                }

                document.Add(CreditTable);

                //footer table
                PdfPTable TableNet = new PdfPTable(3);
                TableNet.SetWidths(new float[] { 10f, 50f, 20f });

                TableNet.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;

                PdfPCell lastC1;
                if (model.LangCode == "1")
                {
                    lastC1 = new PdfPCell(new Phrase("Төлеуге жататын сома", cf9));
                }
                else if (model.LangCode == "3")
                {
                    lastC1 = new PdfPCell(new Phrase("Сумма к выдаче", cf9));
                }
                else
                {
                    lastC1 = new PdfPCell(new Phrase("Net Payment", cf9));
                }

                lastC1.Colspan = 2;
                lastC1.Border = Rectangle.BOTTOM_BORDER;
                TableNet.AddCell(lastC1);

                PdfPCell lastC3 = new PdfPCell(new Phrase(model.Currency + " " + model.NetSalary, f9b));
                lastC3.HorizontalAlignment = Element.ALIGN_RIGHT;
                lastC3.Border = Rectangle.BOTTOM_BORDER;
                TableNet.AddCell(lastC3);

                TableNet.WriteSelectedRows(0, -1, document.LeftMargin, 100, writer.DirectContent);

                document.Close();
                return memoryStream;
            }
        }
        public class PayslipModelForPDF
        {
            public string LangCode { get; set; }
            public string CompanyName { get; set; }
            public string MonthName { get; set; }
            public string BadgeNumber { get; set; }
            public string CostCenter { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string Position { get; set; }
            public string WorkLocation { get; set; }
            public string ContractType { get; set; }
            public string Currency { get; set; }
            public string BasicSalary { get; set; }
            public string GrossSalary { get; set; }
            public string NetSalary { get; set; }
            public string EmpCategory { get; set; }
            public string ytdVac { get; set; }
            public string otRate { get; set; }
            public string hFund { get; set; }
            public string salaryDeduction { get; set; }

            public string PayMonthSelected { get; set; }

            public string ConnectionString { get; set; }
        }

        public static MemoryStream GetPayslipPDF(string payMonthRef, string badge, string langCode, string ConnectionString)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand("exec [dbo].[SP_GetPaySlip_by_Badge_Month] @badge, @payMonth, @Language_Code ", con))
                {
                    command.Parameters.AddWithValue("@badge", badge);
                    command.Parameters.AddWithValue("@payMonth", payMonthRef);
                    command.Parameters.AddWithValue("@Language_Code", langCode);
                    var model = new PayslipModelForPDF()
                    {
                        LangCode = langCode,
                        BadgeNumber = badge,
                        PayMonthSelected = payMonthRef,
                        ConnectionString = ConnectionString
                    };
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Name = reader["Name"].ToString();
                            model.Position = reader["Position"].ToString();
                            model.CostCenter = reader["EmpOCC"].ToString();
                            model.WorkLocation = reader["EmpWorkLoc"].ToString();
                            model.BasicSalary = reader["EmpBasicSal"].ToString();
                            model.otRate = reader["EmpOTRate"].ToString();
                            model.ytdVac = reader["EmpYTDVac"].ToString();
                            model.hFund = reader["EmpHFund"].ToString();
                            model.EmpCategory = reader["EmpEL"].ToString();
                            model.ContractType = reader["ContrType"].ToString();
                            model.Currency = reader["EmpCurr"].ToString();
                            model.NetSalary = reader["EmpSalTotal"].ToString();
                            model.GrossSalary = reader["EmpCredit"].ToString();
                            model.salaryDeduction = reader["EmpDebit"].ToString();
                            model.CompanyName = reader["BussUnit"].ToString();
                            model.Department = reader["EmpDept"].ToString();
                            model.MonthName = reader["Month_Name"].ToString();
                        }
                    }
                    return _GetPayslipPDF(model);
                }
            }
        }
    }
}