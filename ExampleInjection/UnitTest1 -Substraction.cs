using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleInjection
{
    [TestClass]
    public class UnitTestSub
    {
        private IMath a;

        public UnitTestSub()
        {
            //METHOD 2a Dans Contructor
            a = new Substraction();
            //METHOD 2a Dans Contructor
            var b = new UnitTestAjout(a);

            //METHOD 3 
            var c = new UnitTestMultiplication();
            c.a = new Multiplication();
            c.ProgramTest();
            c.a = new Add();
            c.a = new Substraction();
            c.ProgramTest();
        }
        [TestMethod]
        public void ProgramTest()
        {
            //METHOD 1: INSTATIATION DIRECT
            //IMath a = new Add();

            var result = a.Calculate(12,3);

            Assert.AreEqual(result, 9);
        }
    }
}
