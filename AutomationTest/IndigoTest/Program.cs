using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
            //Copiar texto de um paragrafo e colar em um textarea
            var text = driver.FindElement(By.XPath("//*[@id = 'text']/p"));

            IWebElement textAreaPaste = driver.FindElement(By.Id("textArea"));
            textAreaPaste.SendKeys(text.Text);

            driver.FindElement(By.Id("goToItem03")).Click();
        }

        private static void Item03(IWebDriver driver)
        {
            //Preencher input com nome, input com e-mail, selecionar em checkbox os SO que não são da microsoft, selecionar sexo no radiobutton, selecionar cargo no dropdown
            IWebElement nome = driver.FindElement(By.Id("textName"));
            IWebElement email = driver.FindElement(By.Id("textEmail"));
            nome.SendKeys("Caio Pires Silva");
            email.SendKeys("caiopirees@hotmail.com");

            // Selecionar os sistemas operacionais que não pertencem a microsoft
            // Procuro por elementos com o name SO
            IList<IWebElement> chkBx_SO = driver.FindElements(By.Name("SO"));

            // Com a contagem dos elementos posso controlar quantidade de checkboxs
            int aux = chkBx_SO.Count;

            // inicio um loop para varrer todos os checkboxs
            for (int i = 0; i < aux; i++)
            {
                // Armazeno na variavel o atributo id
                String Value = chkBx_SO.ElementAt(i).GetAttribute("id");

                // faço uma verificação para excluir os SO da microsoft
                if (!Value.Equals("win10") && !Value.Equals("winXP") && !Value.Equals("msDOS"))
                {
                    chkBx_SO.ElementAt(i).Click();
                }
            }

            //Seleciona o sexo
            IList<IWebElement> rdBtn_Sexo = driver.FindElements(By.Name("sex"));
            rdBtn_Sexo.ElementAt(0).Click();

            //Selecionar Cargo no DropList
            SelectElement dropList = new SelectElement(driver.FindElement(By.Id("dropListCargo")));
            dropList.SelectByText("Analista Desenvolvedor");

            driver.FindElement(By.Id("goToItem04")).Click();
        }

        private static void Item04(IWebDriver driver)
        {
            //Acionar botão de realizar operação e capturar o resultado da soma e subtração informados
            driver.FindElement(By.Id("btnOperacao")).Click();

            var soma = driver.FindElement(By.Id("soma")).GetAttribute("ng-reflect-model");
            var subtracao = driver.FindElement(By.Id("subtracao")).GetAttribute("ng-reflect-model");
            IWebElement result = driver.FindElement(By.Id("textResult"));
            result.SendKeys("Soma igual a "+ soma + " " + " e subtração igual a " + subtracao);
            
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
            Item01(driver);
            Item02(driver);
            Item03(driver);
            Item04(driver);
            //Item05(driver);
        }
    }
}
