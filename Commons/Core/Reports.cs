using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace Commons
{
    public class PdfReport
    {
        private DateTime testStart = new DateTime();
        private DateTime testEnd = new DateTime();
        private List<string> log = new List<string>();
        private List<Image> evidences = new List<Image>();
        private string testEnviroment = "CHROME - HLG";
        private string testName = null;
        private Exception testException = null;

        public PdfReport(string testEnviroment, string testName)
        {
            this.testEnviroment = testEnviroment;
            this.testName = testName;
        }

        internal void AddEvidence(System.Drawing.Image evidence)
        {
            MemoryStream imageStream = new MemoryStream();
            evidence.Save(imageStream, evidence.RawFormat);
            Image image = new Image(ImageDataFactory.Create(imageStream.ToArray()));
            evidences.Add(image);
        }

        internal void AddLogLine(string line)
        {
            log.Add(line);
        }

        internal void CatchTestException(Exception testException)
        {
            this.testException = testException;
        }

        internal DateTime StartCounter()
        {
            return testStart = DateTime.Now;
        }

        internal string GetTimeSpent()
        {
            TimeSpan timeSpent = testEnd.Subtract(testStart);
            return $"{timeSpent.Hours} h {timeSpent.Minutes} min {timeSpent.Seconds} s";
        }

        internal DateTime FinishCounter()
        {
            return testEnd = DateTime.Now;
        }

        internal void GenerateReport()
        {
            // Create PDF document
            string evidenceDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin/Debug", "").Replace(@"bin/Release", "") + @"\Evidences\";
            string filePath = evidenceDirectory + @"\" + testName + @"_" + testStart.ToString("dd-MM-yyyy_HH-mm-ss") + ".pdf";

            if (!Directory.Exists(evidenceDirectory))
                Directory.CreateDirectory(evidenceDirectory);

            Document report = new Document(new PdfDocument(new PdfWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write))));
            report.SetMargins(75, 35, 70, 35);


            // Tables
            Table evidenceTable = new Table(1).UseAllAvailableWidth();
            Table lastScreenshotTable = new Table(1).UseAllAvailableWidth();
            Table resultTable = new Table(1).UseAllAvailableWidth();
            Table stepsTable = new Table(1).UseAllAvailableWidth();
            Table summaryTable = new Table(1).UseAllAvailableWidth();

            // Stylles
            Style center = new Style().SetTextAlignment(TextAlignment.CENTER);
            Style failed = new Style().SetBackgroundColor(ColorConstants.RED).SetTextAlignment(TextAlignment.CENTER);
            Style failedStepBackgroudColor = new Style().SetBackgroundColor(ColorConstants.RED);
            Style failedStepFontColor = new Style().SetFontColor(ColorConstants.WHITE);
            Style log = new Style().SetTextAlignment(TextAlignment.LEFT).SetFontSize(9).SetBorderTop(Border.NO_BORDER);
            Style logBottom = new Style().SetTextAlignment(TextAlignment.LEFT).SetFontSize(9).SetBorderBottom(Border.NO_BORDER).SetBorderTop(Border.NO_BORDER);
            Style passed = new Style().SetBackgroundColor(ColorConstants.GREEN).SetTextAlignment(TextAlignment.CENTER);
            Style summaryTitle = new Style().SetMaxWidth(65).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.LEFT);
            Style summaryValue = new Style().SetTextAlignment(TextAlignment.LEFT);
            Style title = new Style().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);

            // Paragraphs
            Paragraph environmentTitle = new Paragraph("Ambiente");
            Paragraph environmentValue = new Paragraph(testEnviroment);
            Paragraph executionDateTitle = new Paragraph("Data de execução"); 
            Paragraph executionDateValue = new Paragraph(testStart.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo("pt-BR"))); 
            Paragraph failedTitle = new Paragraph("Failed");
            Paragraph passedTitle = new Paragraph("Passed");
            Paragraph runtimeTitle = new Paragraph("Tempo de execução");
            Paragraph runtimeValue = new Paragraph(GetTimeSpent());
            Paragraph space = new Paragraph(" ");
            Paragraph stepsTitle = new Paragraph("Log");
            Paragraph testTitle = new Paragraph("Caso de teste");
            Paragraph testValue = new Paragraph(testName);

            // Sumário 
            summaryTable.AddCell(new Cell().Add(testTitle).AddStyle(summaryTitle));
            summaryTable.AddCell(new Cell().Add(testValue).AddStyle(summaryValue));

            summaryTable.AddCell(new Cell().Add(environmentTitle).AddStyle(summaryTitle));
            summaryTable.AddCell(new Cell().Add(environmentValue).AddStyle(summaryValue));

            summaryTable.AddCell(new Cell().Add(executionDateTitle).AddStyle(summaryTitle));
            summaryTable.AddCell(new Cell().Add(executionDateValue).AddStyle(summaryValue));

            summaryTable.AddCell(new Cell().Add(runtimeTitle).AddStyle(summaryTitle));
            summaryTable.AddCell(new Cell().Add(runtimeValue).AddStyle(summaryValue));

            report.Add(summaryTable);
            report.Add(space);

            // Result
            if (testException == null)
                resultTable.AddHeaderCell(new Cell().Add(passedTitle).AddStyle(passed));
            else
            {
                resultTable.AddHeaderCell(new Cell().Add(failedTitle).AddStyle(failed));
                resultTable.AddCell(new Cell().Add(new Paragraph(testException.Message)).AddStyle(center));
                resultTable.AddCell(new Cell().Add(new Paragraph(this.log.Last())).AddStyle(center));
            }
            report.Add(resultTable);
            report.Add(space);

            if (evidences.Count != 0)
            {
                Image LastImage = evidences.Last();
                LastImage.ScaleToFit(PageSize.A4.GetWidth() - 80, PageSize.A4.GetHeight());
                LastImage.SetMaxHeight(400);
                LastImage.SetHorizontalAlignment(HorizontalAlignment.CENTER);

                lastScreenshotTable.AddCell(new Cell().Add(new Paragraph("Last Screenshot")).AddStyle(title));
                lastScreenshotTable.AddCell(new Cell().Add(LastImage));

                report.Add(lastScreenshotTable);
            }

            // Steps
            report.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            stepsTable.AddHeaderCell(new Cell().Add(stepsTitle).AddStyle(title));
            foreach (string step in this.log)
            {
                if (step == this.log.Last())
                {
                    if (testException == null)
                    {
                        stepsTable.AddCell(new Cell().Add(new Paragraph(step).AddStyle(log)));
                    }
                    else
                    {
                        stepsTable.AddCell(new Cell().Add(new Paragraph(step).AddStyle(log).AddStyle(failedStepBackgroudColor).AddStyle(failedStepFontColor)));
                    }
                }
                else
                {
                    stepsTable.AddCell(new Cell().Add(new Paragraph(step).AddStyle(logBottom)));
                }

            }
            report.Add(stepsTable);
            report.Add(space);

            // Screenshots
            if (evidences.Count != 0)
            {
                report.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                foreach(Image Evidence in evidences)
                {
                    Evidence.ScaleToFit(PageSize.A4.GetWidth() - 80, PageSize.A4.GetHeight());
                    Evidence.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    evidenceTable.AddCell(new Cell().Add(Evidence));
                }

                report.Add(evidenceTable);
            }

            // Finish report generation and close file connection
            report.Close();
        }

    }

    public class Report
    {
        internal readonly string type;

        internal static readonly Report NO_REPORT = new Report("NO REPORT");

        public static readonly Report PDF = new Report("PDF");

        public Report(string value)
        {
            this.type = value;
        }

    }
}
