using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace Reports.Common
{
    internal class PdfReport
    {
        private DateTime testStart = new DateTime();
        private DateTime testEnd = new DateTime();
        private List<string> log = new List<string>();
        private List<Image> evidences = new List<Image>();
        private string testEnviroment = null;
        private string testName = null;
        private Exception Exception = null;

        internal PdfReport(string testEnviroment, string testName)
        {
            this.testEnviroment = testEnviroment;
            this.testName = testName;
        }

        internal void AddEvidence(System.Drawing.Image evidence)
        {
            MemoryStream imageStream = new MemoryStream();
            evidence.Save(imageStream, evidences.RawFormat);

        }
    }
}
