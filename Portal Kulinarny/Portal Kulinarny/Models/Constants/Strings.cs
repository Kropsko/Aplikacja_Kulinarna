using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal_Kulinarny.Models.Constants
{
    public static class Strings
    {
        public static SelectList UnitNameList = new SelectList(new[]
                {
                    "sztuka", "gram", "dekagram", "kilogram", "mililitr", "litr", "opakowanie","kostka", "plaster", "szklanka",
                    "łyżka", "łyżeczka","ząbek","kropla", "szczypta"
                });
    }
}