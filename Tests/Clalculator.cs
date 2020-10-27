using System;
using NUnit.Framework;

namespace SEB.Tests
{
    class Calculator
    {
        [TestFixture]
        [Parallelizable]
        public class Fixture_1 : TestBase
        {
            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test001_Addition()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                for (int i = 0; i < 5; i++)
                {
                    var random = new Random();
                    obj.VerifyAddition(random.Next(0, 999999999), random.Next(0, 999999999));
                    obj.ClearEntries();
                }
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test002_Subtraction()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                for (int i = 0; i < 5; i++)
                {
                    var random = new Random();
                    obj.VerifySubtraction(random.Next(0, 999999999), random.Next(0, 999999999));
                    obj.ClearEntries();
                }
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test003_Multiplication()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                for (int i = 0; i < 5; i++)
                {
                    var random = new Random();
                    obj.VerifyMultiplication(random.Next(0, 9999999), random.Next(0, 9999999));
                    obj.ClearEntries();
                }
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test004_Division()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                for (int i = 0; i < 5; i++)
                {
                    var random = new Random();
                    obj.VerifyDivision(random.Next(0, 99999999), random.Next(0, 99999999));
                    obj.ClearEntries();
                }
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test005_Multiplication10x10()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                obj.VerifyMultiplicationTable();
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test006_MR_MC_Verification()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                obj.VerifyMRMC();
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test007_Division_By_0()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                for (int i = 0; i < 5; i++)
                {
                    var random = new Random();
                    obj.VerifyDivisionBy0(random.Next(0, 99999999), 0);
                    obj.ClearEntries();
                }
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test008_Addition_Negative_Numbers()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                for (int i = 0; i < 5; i++)
                {
                    var random = new Random();
                    obj.VerifyAdditionNegativeNumbers(random.Next(0, 999999999), random.Next(0, 999999999));
                    obj.ClearEntries();
                }
            }

            [TestCase]
            [Category("Regression"), Category("Functional")]
            public void Test009_Subtraction_Negative_Numbers()
            {
                UI.NavigateTo(driver, "www.calculator.net");
                UI.WaitForPageToLoad(driver);
                var obj = new CalculatorPageObject(driver);
                obj.VerifyOnLandingPage(); // verifies that text matches the expected text on the landing page
                for (int i = 0; i < 50; i++)
                {
                    var random = new Random();
                    obj.VerifySubtractionNegativeNumbers(random.Next(0, 999999999), random.Next(0, 999999999));
                    obj.ClearEntries();
                }
            }

        }
    }
}
