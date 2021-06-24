using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace Commons.Core
{
    public class WebDriver : Driver
    {
        private readonly Browser browser;
        private IWebDriver driver = null;

        public WebDriver(Browser browser)
        {
            this.browser = browser;
            this.reportHandler = new ReportHandler();
            driver = GetWebDriver();
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(DRIVER_TIMEOUT);
            Maximize();
            driver.Manage().Window.Size = new Size(1024, 768);
        }

        private void DownloadWebDriverExecutable(string webDriverPath)
        {
            Directory.CreateDirectory(webDriverPath);
            WebClient client = new WebClient();
            string url = string.Empty;

            switch (browser.name)
            {
                case "CHROME":
                    url = "https://chromedriver.storage.googleapis.com/%1/chromedriver_win32.zip";
                    switch (GetBrowserVersion().Split('.')[0])
                    {
                        case "92":
                            url = url.Replace("%1", "92.0.4515.43");
                            break;

                        case "91":
                            url = url.Replace("%1", "90.0.4430.24");
                            break;

                        case "90":
                            url = url.Replace("%1", "90.0.4430.24");
                            break;

                        case "89":
                            url = url.Replace("%1", "89.0.4389.23");
                            break;

                        default:
                            throw new NotSupportedException("Chrome version not supported.");
                    }
                    break;

                default:
                    throw new NotSupportedException("Browser not supported.");
            }

            string file = Path.GetFileName(url);
            string filePath = webDriverPath + file;
            string tempFilePath = @"C:\Temp\" + file;
            client.DownloadFile(url, tempFilePath);
            ZipFile.ExtractToDirectory(tempFilePath, webDriverPath);
            File.Delete(filePath);
        }

        private ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;
            options.AddArgument("--headless");
            //options.EnableMobileEmulation("Pixel 2");
            return options;
        }

        private string GetBrowserVersion()
        {
            switch (browser.name)
            {
                case "CHROME":
                    return FileVersionInfo.GetVersionInfo(Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null).ToString()).FileVersion;

                default:
                    throw new Exception("Browser not supported");
            }
        }

        private IWebDriver GetWebDriver()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug", "").Replace(@"bin\Release", "") + @"Resources\Drivers\";
            string webDriverPath = basePath + browser.name + @"\" + GetBrowserVersion().Split('.')[0];

            if (!Directory.Exists(webDriverPath) || !Directory.EnumerateFileSystemEntries(webDriverPath).Any())
                DownloadWebDriverExecutable(webDriverPath);

            switch (browser.name)
            {
                case "CHROME":
                    return new ChromeDriver(webDriverPath, GetChromeOptions(), TimeSpan.FromSeconds(DRIVER_TIMEOUT));

                default:
                    throw new NotSupportedException("Browser not supported");
            }
        }

        internal override IWebElement FindElement(By by)
        {
            var element = driver.FindElement(by);
            driver.ExecuteJavaScript("arguments[0].scrollIntoView()", element);
            return element;
        }

        public override void InitiateReport(Report report, string testName)
        {
            reportHandler = new ReportHandler();
            reportHandler.InitiateReport(Report.PDF, testName, browser.name);
        }

        public void FinishReport()
        {
            reportHandler.FinishReport();
        }

        public override void GetScreenshot()
        {
            string message = "Tirou screenshot";

            try
            {
                reportHandler.AddEvidence(ScreenshotToImage(driver.TakeScreenshot()));
                reportHandler.AddLogLine(message, true);
            }
            catch (Exception methodException)
            {
                reportHandler.CatchTestException(message, methodException);
                throw methodException;
            }
        }

        public int GetElementCount(string by, double timeout)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeout);
            Exception methodException = new Exception();

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    return driver.ElementCount(by);
                }
                catch (Exception e)
                {
                    throw methodException = e;
                }

            }

            return 0;
        }
        public void Close()
        {
            string message = "Fechou aba";

            try
            {
                driver.Close();
                reportHandler.AddLogLine(message, true);
            }
            catch (Exception methodException)
            {
                reportHandler.CatchTestException(message, methodException);
                throw methodException;
            }
        }

        public void Maximize()
        {
            string message = "Maximizou a aba";

            try
            {
                driver.Manage().Window.Maximize();
                reportHandler.AddLogLine(message, true);
            }
            catch (Exception methodException)
            {
                reportHandler.CatchTestException(message, methodException);
                throw methodException;
            }
        }

        public void NavigateTo(string url)
        {
            string message = "Navegou para " + url;

            try
            {
                driver.Navigate().GoToUrl(new Uri(url));
                reportHandler.AddLogLine(message, true);
            }
            catch (Exception methodException)
            {
                reportHandler.CatchTestException(message, methodException);
                throw methodException;
            }
        }

        public void Quit()
        {
            string message = "Driver finalizado";

            try
            {
                driver.Quit();
                reportHandler.AddLogLine(message, true);
            }
            catch (Exception methodException)
            {
                reportHandler.CatchTestException(message, methodException);
                throw methodException;
            }
        }

        public void Refresh()
        {
            try
            {
                driver.Navigate().Refresh();
            }
            catch (Exception methodException)
            {
                throw methodException;
            }
        }

    }

    public class Browser
    {
        internal readonly string name;

        public static readonly Browser CHROME = new Browser("CHROME");

        private Browser(string value)
        {
            this.name = value;
        }

    }
}
