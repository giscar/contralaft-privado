using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SBS.UIF.BUZ.DataAccess.Mapper
{
   public class CastType<T>
    {
       public static T CastValue(object Objeto)
       {          
           return (T)Objeto;
       }

       public static List<T> CastList(IList ilst)
       {
           return new List<T>(ilst.Cast<T>());
       }
    }
}
