using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Mail;

namespace Westvleteren
{
    class Program
    {
        static void Main(string[] args)
        {
            var startUrl = "https://www.trappistwestvleteren.be/nl/bierverkoop";
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(startUrl);
            

            if (Equals(driver.Url, startUrl))
            {
                Waiter.WaitForCondition(() => driver.Url == startUrl);
            }
            else
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("your mail@gmail.com"); // hier een 'van' gmailadres invullen
                mail.To.Add("to_mail@gmail.com"); // hier een 'naar' e-mail adres invullen
                mail.Subject = "Bier Bestellen";
                mail.Body = "Bier Bestellen";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("your mail@gmail.com", "your password"); // Hier je gmail + ww invullen
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
        }
    }
}
