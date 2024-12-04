using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapingSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            // en el drive vamos a hacer todo es el navegador
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.sunat.gob.pe/sol.html");

            var searchBoton = driver.FindElement(By.XPath("/html/body/section[1]/div/div/section[2]/div[2]/div/a"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", searchBoton);
            Thread.Sleep(2000);
            searchBoton.Click();

            // Obtener los identificadores de las ventanas abiertas
            var windowHandles = driver.WindowHandles;

            // Si hay más de una ventana abierta, cambia a la ventana 2
            if (windowHandles.Count > 1)
            {
                driver.SwitchTo().Window(windowHandles[2]); // Cambia a la ventana de notificacion
                driver.Close();  // Cierra la ventana de la notificacion
                Console.WriteLine("La ventana de notificacion se cerro");
    
                driver.SwitchTo().Window(windowHandles[3]); // Cambia a la ventana de ruc
            }
            else
            {
                Console.WriteLine("Solo hay una ventana abierta.");
            }
            Thread.Sleep(2000);

            // encontrar las cajas de texto
            var cajaRuc = driver.FindElement(By.Id("txtRuc"));
            var cajaUsuario = driver.FindElement(By.Id("txtUsuario"));
            var cajaContra = driver.FindElement(By.Id("txtContrasena"));

            cajaRuc.SendKeys("****");
            cajaUsuario.SendKeys("****");
            cajaContra.SendKeys("****");

            var inicioBtn = driver.FindElement(By.Id("btnAceptar"));
            inicioBtn.Click();

            var navBtn = driver.FindElement(By.Id("btnNavbar"));
            navBtn.Click();

            var buzonBtn = driver.FindElement(By.Id("aOpcionBuzon"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", buzonBtn);
            Thread.Sleep(1000);
            buzonBtn.Click();

            // TO DO: Aun no se puede regresarBtn
            var regresarBtn = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/div/div[2]/div[1]/button"));
            regresarBtn.Click();

            var textNot = driver.FindElement(By.Id("aListNoti"));
            Console.WriteLine(textNot.Text);

            var textMss = driver.FindElement(By.Id("aListMen"));
            Console.WriteLine(textMss.Text);
        }
    }
}
