using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleInjection
{
  
    public class UnitTestMultiplication
    {
        //METHOD 3: by PROPERTIEs
        public IMath a { get;  set; }

        public UnitTestMultiplication()
        {
            a = new Multiplication();
        }
       
        public void ProgramTest()
        {
            //METHOD 1: INSTATIATION DIRECT
            //IMath a = new Add();

            var result = a.Calculate(12,3);

            Assert.AreEqual(result, 36);
        }
    }
}
