using SandwichSystem.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class MealsCompositionExtentions
    {
        public static MealCompositionEF UpdateFieldsFromDetached(this MealCompositionEF AttachedEF, MealCompositionEF DetachedEF)
        {
            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Meal = AttachedEF.Meal.UpdateFieldsFromDetached(DetachedEF.Meal);
                AttachedEF.Ingredient = AttachedEF.Ingredient.UpdateFieldsFromDetached(DetachedEF.Ingredient);
            }

            return AttachedEF;
        }


        public static List<MealCompositionEF> UpdateListFromDetached(this List<MealCompositionEF> AttachedList, List<MealCompositionEF> DetachedList)
        {
            var ListNotModified = AttachedList.Except(DetachedList);
            var ListAdd = DetachedList.Except(AttachedList);
            var ListModifiedDetached = DetachedList.Intersect(AttachedList);
                //Notes: DetachedEF.Except(ListAdd); Same Result

            foreach (var DetachedEF in ListModifiedDetached)
            {
                var AttachedEF = AttachedList.Find(x => x.Equals(DetachedEF));
                AttachedEF = AttachedEF.UpdateFieldsFromDetached(DetachedEF);
            }

            
            return ListModifiedDetached.Concat(ListNotModified).Concat(ListAdd).ToList();
        }
    }
}
