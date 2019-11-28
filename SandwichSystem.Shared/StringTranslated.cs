
using SandwichSystem.Shared.Enumerations;

namespace SandwichSystem.Shared
{
    public class StringTranslated
    {
        public StringTranslated(string English, string French, string Dutch)
        {
            this.English = English;
            this.French = French;
            this.Dutch = Dutch;
        }
        public string English { get; set; }
        public string French { get; set; }
        public string Dutch { get; set; }

        public string ToString(Language Langue)
        {
            switch (Langue)
            {
                case Language.English:
                    return English;
                case Language.French:
                    return French;
                case Language.Dutch:
                    return Dutch;
                default:
                    throw new System.Exception("Language Unknown or not properly configured.");
            }
        }
    }
}