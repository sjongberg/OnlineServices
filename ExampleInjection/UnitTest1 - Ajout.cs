using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleInjection
{
    
    public class UnitTestAjout
    {
        private IMath a;

        public UnitTestAjout(IMath MathInjected)
        {
            //METHOD 2b Dans Contructor
            a = MathInjected ?? new Add();
        }

        
        public void ProgramTest()
        {
            //METHOD 1: INSTATIATION DIRECT
            //IMath a = new Add();

            var result = a.Calculate(12,3);

            Assert.AreEqual(result, 15);
        }
    }
}
