using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace IndigoTest
{
    static class Program
    {
        private static void Item01(IWebDriver driver)
        {
            //Conta quantidade de itens dentro da tabela
            decimal countRows = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
            IWebElement qtdRows = driver.FindElement(By.Id("qtdItens"));
            qtdRows.SendKeys(countRows.ToString());

            //Ordenar pelo codigo
            var rowsId = driver.FindElements(By.XPath("//*[@id = 'tabela']/tbody/tr")).ToList();
            IOrderedEnumerable<IWebElement> orderedRowsId = rowsId.OrderBy(c => c.Text);
            foreach (var row in orderedRowsId)
            {
                IWebElement textArea = driver.FindElement(By.Id("orderedByCodigo"));
                textArea.SendKeys(row.Text);
            }

            //Ordenar pelo Apelido
            var rowsNick = driver.FindElements(By.XPath("//*[@id = 'tabela']/tbody/tr/td[@id='apelido']")).ToList();
            IOrderedEnumerable<IWebElement> orderedRowsNick = rowsNick.OrderBy(c => c.Text);
            foreach (var row in orderedRowsNick)
            {
                IWebElement textArea = driver.FindElement(By.Id("orderedByApelido"));
                textArea.SendKeys(row.Text);
            }

            driver.FindElement(By.Id("goToItem02")).Click();

        }

        private static void Item02(IWebDriver driver)
        {
            var text = driver.FindElement(By.XPath("//*[@id = 'text']/p"));

            IWebElement textAreaPaste = driver.FindElement(By.Id("textArea"));
            textAreaPaste.SendKeys(text.Text);

            driver.FindElement(By.Id("goToItem03")).Click();
        }

        private static void Item03(IWebDriver driver)
        {
            //Preencher input com nome, input com e-mail, selecionar em checkbox os SO que não são da microsoft, selecionar sexo no radiobutton, selecionar cargo no dropdown
            throw new NotImplementedException();
        }

        private static void Item04(IWebDriver driver)
        {
            //Copiar texto de dois inputs, no terceiro input informar a soma dos dois numeros, no quarto imprimir a subtração dos dois 
            throw new NotImplementedException();
        }

        private static void Item05(IWebDriver driver)
        {
            //Clicar no botão de OK dos alerts ou desabilita-los antes de dispararem
            throw new NotImplementedException();
        }

        private static void Login(IWebDriver driver)
        {
            IWebElement login = driver.FindElement(By.Id("login"));
            IWebElement password = driver.FindElement(By.Id("Password"));

            login.SendKeys("caio.silva");
            password.SendKeys("Desenvolvedor@2018");

            driver.FindElement(By.Id("Submit")).Click();
        }

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4200/#/home");
            driver.FindElement(By.Id("iniciarTeste")).Click();

            //Login(driver);
            //Item01(driver);
            //Item02(driver);
            Item03(driver);
            //Item04(driver);
            //Item05(driver);
        }
    }
}
