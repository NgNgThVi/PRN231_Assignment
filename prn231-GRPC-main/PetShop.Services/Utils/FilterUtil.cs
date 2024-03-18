using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Utils
{
    public static class FilterUtil
    {
        public static List<TEntity>? AutoFilter<TEntity, TFilter>(this List<TEntity> query, TFilter filterObject)
        {
            Func<TEntity, TFilter, bool> isContain = (TEntity e, TFilter filterObject) =>
            {
                bool result = true;
                if (filterObject != null)
                {
                    foreach (PropertyInfo property in filterObject.GetType().GetProperties())
                    {
                        if (!property.Name.Contains("Expression"))
                        {
                            var filterValue = property.GetValue(filterObject);
                            if (e != null)
                            {
                                var objectType = e.GetType();
                                if (objectType != null)
                                {
                                    var objectProp = e.GetType().GetProperty(property.Name);
                                    if (objectProp != null)
                                    {
                                        var value = objectProp.GetValue(e);
                                        if ((value != null) && (filterValue != null))
                                        {
                                            var valueString = value.ToString();
                                            var filterValueString = filterValue.ToString();
                                            if ((filterValueString != null) && (valueString != null))
                                            {
                                                var expression = filterObject.GetType().GetMethod(property.Name + "Expression");
                                                if (expression != null)
                                                {
                                                    var expressionResult = expression.Invoke(filterObject, new[] { valueString, filterValueString });
                                                    if (expressionResult != null)
                                                    {
                                                        result &= (bool)expressionResult;
                                                    }
                                                }
                                                else
                                                {
                                                    if (property.PropertyType == typeof(int))
                                                    {
                                                        result &= valueString.Equals(filterValueString);
                                                    }
                                                    else
                                                        result &= valueString.Contains(filterValueString);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return result;
            };

            return query.Where(e => isContain(e, filterObject)).ToList();
        }
    }
}
