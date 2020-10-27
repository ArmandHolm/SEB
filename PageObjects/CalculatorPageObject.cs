using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace SEB.Tests

{
    public class CalculatorPageObject
    {
        #region locators
        private By logo = By.CssSelector("#logo img");
        private By txtFreeonlineCalc = By.CssSelector("h1");

        //Calculator Buttons
        private By btn1 = By.CssSelector("div:nth-child(3) > .scinm:nth-child(1)");
        private By btn2 = By.CssSelector("div:nth-child(3) > .scinm:nth-child(2)");
        private By btn3 = By.CssSelector("div:nth-child(3) > .scinm:nth-child(3)");
        private By btn4 = By.CssSelector("div:nth-child(2) > .scinm:nth-child(1)");
        private By btn5 = By.CssSelector("div:nth-child(2) > .scinm:nth-child(2)");
        private By btn6 = By.CssSelector("div:nth-child(2) > .scinm:nth-child(3)");
        private By btn7 = By.CssSelector("div:nth-child(1) > .scinm:nth-child(1)");
        private By btn8 = By.CssSelector("div:nth-child(1) > .scinm:nth-child(2)");
        private By btn9 = By.CssSelector("div:nth-child(1) > .scinm:nth-child(3)");
        private By btn0 = By.CssSelector("div:nth-child(4) > .scinm:nth-child(1)");
        private By btnMultiply = By.CssSelector("div:nth-child(3) > .sciop:nth-child(4)");
        private By btnDivide = By.CssSelector("div:nth-child(4) > .sciop:nth-child(4)");
        private By btnSubtract = By.CssSelector("div:nth-child(2) > .sciop:nth-child(4)");
        private By btnAdd = By.CssSelector("div:nth-child(1) > .sciop:nth-child(4)");
        private By btnEquals = By.CssSelector(".scieq:nth-child(4)");
        private By btnMC_MR = By.Id("scimrc");
        private By btnAC = By.CssSelector(".scieq:nth-child(3)");
        private By txtResult = By.Id("sciOutPut");

        #endregion
        public CalculatorPageObject(IWebDriver driver)
        { pageDriver = driver; }

        public IWebDriver pageDriver { get; }

        public void VerifyOnLandingPage()
        {
            var txth1 = UI.GetText(pageDriver.FindElement(txtFreeonlineCalc));
            Assert.AreEqual("Free Online Calculators", txth1);
        }

        public void EnterNumber(int number)
        {

            var digits = Math.Abs(number).ToString().Length;

            for (int i = 0; i < digits;)
            {
                int result = number / (int)Math.Pow(10, digits - 1) % 10;
                digits--;
                switch (result.ToString())
                {
                    case "1":
                        UI.ClickElement(pageDriver, btn1);
                        break;

                    case "2":
                        UI.ClickElement(pageDriver, btn2);
                        break;

                    case "3":
                        UI.ClickElement(pageDriver, btn3);
                        break;

                    case "4":
                        UI.ClickElement(pageDriver, btn4);
                        break;

                    case "5":
                        UI.ClickElement(pageDriver, btn5);
                        break;

                    case "6":
                        UI.ClickElement(pageDriver, btn6);
                        break;

                    case "7":
                        UI.ClickElement(pageDriver, btn7);
                        break;

                    case "8":
                        UI.ClickElement(pageDriver, btn8);
                        break;

                    case "9":
                        UI.ClickElement(pageDriver, btn9);
                        break;

                    case "0":
                        UI.ClickElement(pageDriver, btn0);
                        break;
                    case "-":
                        UI.ClickElement(pageDriver, btnSubtract);
                        break;
                }
            }
        }

        public void ClearEntries()
        {
            UI.ClickElement(pageDriver, btnAC);
        }

        public void VerifyAddition(int numfirst, int numSecond)
        {
            var result = numfirst + numSecond;
            EnterNumber(numfirst);
            UI.ClickElement(pageDriver, btnAdd);
            EnterNumber(numSecond);
            UI.ClickElement(pageDriver, btnEquals);
            Assert.AreEqual(result.ToString(), pageDriver.FindElement(txtResult).Text.Trim());
        }

        public void VerifySubtraction(int numfirst, int numSecond)
        {
            var result = numfirst - numSecond;
            EnterNumber(numfirst);
            UI.ClickElement(pageDriver, btnSubtract);
            EnterNumber(numSecond);
            UI.ClickElement(pageDriver, btnEquals);
            Assert.AreEqual(result.ToString(), pageDriver.FindElement(txtResult).Text.Trim());
        }

        public void VerifyMultiplication(int numfirst, int numSecond)
        {
            BigInteger result = BigInteger.Multiply(BigInteger.Parse(numfirst.ToString()), 
                BigInteger.Parse(numSecond.ToString()));
            EnterNumber(numfirst);
            UI.ClickElement(pageDriver, btnMultiply);
            EnterNumber(numSecond);
            UI.ClickElement(pageDriver, btnEquals);
            BigInteger answer = BigInteger.Parse(pageDriver.FindElement(txtResult).Text.Trim(),
                CultureInfo.InvariantCulture.NumberFormat);
            Assert.AreEqual(result.ToString(), answer.ToString());
        }

        public void VerifyDivision(int numfirst, int numSecond)
        {
            float result = (float)numfirst / (float)numSecond;
            EnterNumber(numfirst);
            UI.ClickElement(pageDriver, btnDivide);
            EnterNumber(numSecond);
            UI.ClickElement(pageDriver, btnEquals);
            float answer = float.Parse(pageDriver.FindElement(txtResult).Text.Trim(),
                CultureInfo.InvariantCulture.NumberFormat);
            Assert.AreEqual(result.ToString("N5"), answer.ToString("N5"));
        }

        public void VerifyMultiplicationTable()
        {
            var expectedList = new List<string>();
            var actualList = new List<string>();

            for (int i = 0; i < 10 * 10; ++i)
            {
                int firstNumber = i / 10 + 1;
                int secondNumber = i % 10 + 1;
                var test = firstNumber * secondNumber;
                expectedList.Add(test.ToString());

                EnterNumber(firstNumber);
                UI.ClickElement(pageDriver, btnMultiply);
                EnterNumber(secondNumber);
                UI.ClickElement(pageDriver, btnEquals);
                var answer = pageDriver.FindElement(txtResult).Text.Trim();
                actualList.Add(answer.ToString());
            }

            Assert.AreEqual(expectedList, actualList);
        }

        public void VerifyMRMC()
        {
            var buttonTextFirstView = UI.GetText(pageDriver.FindElement(btnMC_MR));
            UI.ClickElement(pageDriver, btnMC_MR);
            var buttonTextAfterClick = UI.GetText(pageDriver.FindElement(btnMC_MR));
            Assert.Multiple(() =>
            {
                Assert.AreEqual("MR", buttonTextFirstView);
                Assert.AreEqual("MC", buttonTextAfterClick);
            });
        }

        public void VerifyDivisionBy0(int numfirst, int numSecond)
        {
            EnterNumber(numfirst);
            UI.ClickElement(pageDriver, btnDivide);
            EnterNumber(numSecond);
            UI.ClickElement(pageDriver, btnEquals);
            var answer = pageDriver.FindElement(txtResult).Text.Trim();
            StringAssert.AreEqualIgnoringCase("ERROR", answer);
        }

        public void VerifyAdditionNegativeNumbers(int numfirst, int numSecond)
        {
            var result = 0 - (numfirst + numSecond);
            UI.ClickElement(pageDriver, btnSubtract);
            EnterNumber(numfirst);
            UI.ClickElement(pageDriver, btnAdd);
            UI.ClickElement(pageDriver, btnSubtract);
            EnterNumber(numSecond);
            UI.ClickElement(pageDriver, btnEquals);
            Assert.AreEqual(result.ToString(), pageDriver.FindElement(txtResult).Text.Trim());
        }

        public void VerifySubtractionNegativeNumbers(int numfirst, int numSecond)
        {
            var result = 0 - (numfirst - numSecond);
            UI.ClickElement(pageDriver, btnSubtract);
            EnterNumber(numfirst);
            UI.ClickElement(pageDriver, btnSubtract);
            UI.ClickElement(pageDriver, btnSubtract);
            EnterNumber(numSecond);
            UI.ClickElement(pageDriver, btnEquals);
            Assert.AreEqual(result.ToString(), pageDriver.FindElement(txtResult).Text.Trim());
        }

    }
}