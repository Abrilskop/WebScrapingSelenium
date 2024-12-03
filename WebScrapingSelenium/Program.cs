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

            // navega al aurl
            driver.Navigate().GoToUrl("https://www.sunat.gob.pe/sol.html");

            var searchBoton = driver.FindElement(By.XPath("/html/body/section[1]/div/div/section[2]/div[2]/div/a"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", searchBoton);

            searchBoton.Click();

            //

            // Obtén todos los identificadores de las ventanas abiertas
            var windowHandles = driver.WindowHandles;

            // Si hay más de una ventana abierta, cambia al contexto de la última ventana
            if (windowHandles.Count > 1)
            {
                // Cambia al contexto de la primera ventana abierta
                driver.SwitchTo().Window(windowHandles[2]);

                // Realiza las acciones necesarias en la primera ventana
                Console.WriteLine("Ahora estás en la primera ventana abierta.");

                // Cierra la primera ventana
                driver.Close();
                Console.WriteLine("La primera ventana ha sido cerrada.");
            }
            else
            {
                Console.WriteLine("Solo hay una ventana abierta.");
            }

            //var BotonDni = driver.FindElement(By.Id("btnPorDni"));
            //BotonDni.Click();
        }
    }
}
