using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.BusinessLayer
{
    public class Ingredient
    {
        public StringTranslated Name { get; set; }
        public bool IsAllergene { get; set; }

        public Ingredient(StringTranslated Name, bool isAllergene)
        {
            this.Name = Name;
            this.IsAllergene = isAllergene;
        }

        public string ShowAllergene()
        {
            if (IsAllergene == true)
            {
                return "*";
            }
            else
                return "";
        } 

        public string ToString(Language Langue)
        {
            string ReturnValue ="";
            switch (Langue)
            {
                case Language.English:
                    ReturnValue = Name.English;
                    break;
                case Language.French:
                    ReturnValue = Name.French;
                    break;
                case Language.Dutch:
                    ReturnValue = Name.Dutch;
                    break;
                default:
                    break;
            }

            return ReturnValue + ShowAllergene();
        }


    }

}
