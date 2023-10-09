using CalculadoraDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testeSoma()
        {
            //Arrange
            int a = 3;
            int b = 2;
            int r = 5;

            //Act
            calculadora c = new calculadora();
            int result = c.somar(a, b);

            //Assert
            Assert.AreEqual(result, r);

        }

        [TestMethod]
        public void testeSubt()
        {
            //Arrange
            int a = 15;
            int b = 5;
            int r = 10;

            //Act
            calculadora c = new calculadora();
            int result = c.subtracao(a, b);

            //Assert
            Assert.AreEqual(result, r);

        }

        [TestMethod]
        public void testeMult()
        {
            //Arrange
            int a = 3;
            int b = 2;
            int r = 6;

            //Act
            calculadora c = new calculadora();
            int result = c.multiplicacao(a, b);

            //Assert
            Assert.AreEqual(result, r);

        }

        [TestMethod]
        public void testeDiv()
        {
            //Arrange
            int a = 10;
            int b = 2;
            int r = 5;

            //Act
            calculadora c = new calculadora();
            int result = c.divisao(a, b);

            //Assert
            Assert.AreEqual(result, r);

        }

        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(-1, -2, -3)]
        [DataRow(5, 7, 12)]
        public void somar_e_retornar(int num1, int num2, int resul_esperado)
        {
            //Act
            calculadora c = new calculadora();
            int result = c.somar(num1, num2);

            //Assert
            Assert.AreEqual(result, resul_esperado);
        }

        [DataTestMethod]
        [DataRow(4, 2, 2)]
        [DataRow(10, 2, 5)]
        [DataRow(7, 2, 3)]
        public void dividir_e_retornar(int num1, int num2, int resul_esperado)
        {
            //Act
            calculadora c = new calculadora();
            int result = c.divisao(num1, num2);

            //Assert
            Assert.AreEqual(result, resul_esperado);
        }

        [DataTestMethod]
        [DataRow(4, 3, 12)]
        [DataRow(30, 2, 60)]
        [DataRow(10, 7, 70)]
        public void mult_e_retornar(int num1, int num2, int resul_esperado)
        {
            //Act
            calculadora c = new calculadora();
            int result = c.multiplicacao(num1, num2);

            //Assert
            Assert.AreEqual(result, resul_esperado);
        }

        [DataTestMethod]
        [DataRow(2, 1, 1)]
        [DataRow(10, 5, 5)]
        [DataRow(5, 3, 2)]
        public void sub_e_retornar(int num1, int num2, int resul_esperado)
        {
            //Act
            calculadora c = new calculadora();
            int result = c.subtracao(num1, num2);

            //Assert
            Assert.AreEqual(result, resul_esperado);
        }

        [TestMethod]
        public void FatorialF()
        {
            //Arrange
            int a = 5;
            int r = 120;

            //Act
            calculadora c = new calculadora();
            int result = c.fatorial(a);

            //Assert
            Assert.AreEqual(result, r);

        }

        [DataTestMethod]
        [DataRow(5, 120)]
        [DataRow(4, 24)]
        [DataRow(3, 6)]
        public void fatorialT(int num1, int resul_esperado)
        {
            //Act
            calculadora c = new calculadora();
            int result = c.fatorial(num1);

            //Assert
            Assert.AreEqual(result, resul_esperado);
        }
    }
}
