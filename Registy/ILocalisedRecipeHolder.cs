using KitchenData;
using System.Collections.Generic;

namespace Bruschetta.Registry
{
    public interface ILocalisedRecipeHolder
    {
        IDictionary<Locale, string> LocalisedRecipe { get; }

    }
}