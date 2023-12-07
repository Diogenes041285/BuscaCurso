using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BuscaCurso.AluraWebDriver.Pages
{
	public class PageBase
	{
		public static IWebDriver _driver;

        public PageBase()
        {
			IniciarChrome();   
        }

        private void IniciarChrome() 
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("start-maximized");
			_driver = new ChromeDriver(options);
		}
		public bool Aguardar(string xpath, int until)
		{
			bool carregou = true;
			int count = 1;

			while (TemAlerta() || _driver.FindElements(By.XPath(xpath)).Count == 0)
			{
				if (TemAlerta())
					AceitarAlerta();

				count++;
				Thread.Sleep(1000);
				if (count > until)
				{
					carregou = false;
					break;
				}
			}


			return carregou;
		}

		public bool TemAlerta()
		{
			bool tem = false;
			try
			{
				_driver.SwitchTo().Alert();
				tem = true;
			}
			catch (Exception) { }

			return tem;
		}

		public void AceitarAlerta()
		{
			try
			{
				_driver.SwitchTo().Alert().Accept();
			}
			catch (Exception) { }
		}
	}
}
