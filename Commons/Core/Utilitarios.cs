using System;

namespace Commons
{
    public class ReportHandler
    {
        private Report report = Report.PDF;

        private PdfReport pdfReport = new PdfReport("CHROME - HLG", "Test");

        public void InitiateReport(Report report, string testName, string testEnvironment)
        {
            this.report = report;

            switch (this.report.type)
            {
                case "NO_REPORT":
                    break;

                case "PDF":
                    pdfReport = new PdfReport(testEnvironment, testName);
                    pdfReport.StartCounter();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public void AddEvidence(System.Drawing.Image evidence)
        {
            switch (report.type)
            {
                case "NO_REPORT":
                    break;

                case "PDF":
                    pdfReport.AddEvidence(evidence);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public void AddLogLine(string message, bool success)
        {
            if (success)
            {
                switch (report.type)
                {
                    case "NO_REPORT":
                        break;

                    case "PDF":
                        pdfReport.AddLogLine($"[PASSED] {message}");
                        break;

                    default:
                        throw new NotImplementedException();
                }

            }
            else
            {
                switch (report.type)
                {
                    case "NO_REPORT":
                        break;

                    case "PDF":
                        pdfReport.AddLogLine($"[FAILED] {message}");
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public void CatchTestException(string message, Exception testException)
        {
            switch (report.type)
            {
                case "NO_REPORT":
                    break;

                case "PDF":
                    AddLogLine(message, false);
                    pdfReport.CatchTestException(testException);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public void FinishReport()
        {
            switch (this.report.type)
            {
                case "NO_REPORT":
                    break;

                case "PDF":
                    pdfReport.FinishCounter();
                    pdfReport.GenerateReport();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }

}


