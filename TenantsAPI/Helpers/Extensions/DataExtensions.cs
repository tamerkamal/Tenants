using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TenantsAPI.Helper.Extensions
{
    public static class DataExtensions
    {
        public static DataTable ConvertToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            return table;
        }

        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            return table;
        }

        public static DataRow ConvertToDataRow<T>(this T item, DataTable table)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            return row;
        }

        public static T ConvertToEntity<T>(this DataRow tableRow)
        {
            // Create a new type of the entity I want
            var t = typeof(T);

            var returnObject = Activator.CreateInstance<T>();

            foreach (DataColumn col in tableRow.Table.Columns)
            {
                var colName = col.ColumnName;

                // Look for the object's property with the columns name, ignore case
                var pInfo = t.GetProperty(colName.ToLower(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // did we find the property ?
                if (pInfo != null)
                {
                    var val = tableRow[colName];

                    // is this a Nullable<> type
                    var isNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
                    if (isNullable)
                    {
                        // Convert the db type into the T we have in our Nullable<T> type
                        val = val is DBNull ? null : Convert.ChangeType(val, Nullable.GetUnderlyingType(pInfo.PropertyType));
                    }
                    else
                    {
                        // Convert the db type into the type of the property in our entity
                        SetDefaultValue(ref val, pInfo.PropertyType);
                        if (pInfo.PropertyType.IsEnum && !pInfo.PropertyType.IsGenericType)
                        {
                            val = Enum.ToObject(pInfo.PropertyType, val);
                        }
                        else
                            val = Convert.ChangeType(val, pInfo.PropertyType);
                    }

                    // Set the value of the property with the value from the db
                    if (pInfo.CanWrite)
                        pInfo.SetValue(returnObject, val, null);
                }
            }

            // return the entity object with values
            return returnObject;
        }

        private static void SetDefaultValue(ref object val, Type propertyType)
        {
            if (val is DBNull)
            {
                val = GetDefault(propertyType);
            }
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        public static List<T> ConvertToList<T>(this DataTable table)
        {
            // Create a list of the entities we want to return
            var returnObject = new List<T>();

            // Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                // Convert each row into an entity object and add to the list
                var newRow = dr.ConvertToEntity<T>();
                returnObject.Add(newRow);
            }

            // Return the finished list
            return returnObject;
        }

        public static List<Dictionary<string, object>> ConvertToList(this DataTable table)
        {
            // Create a list of the entities we want to return
            var returnObject = new List<Dictionary<string, object>>();

            // Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                var row = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                returnObject.Add(row);
            }

            // Return the finished list
            return returnObject;
        }

        public static Expression<Func<TTo, bool>> ConvertToExpression<TFrom, TTo>(this Expression<Func<TFrom, bool>> from)
        {
            return ConvertImpl<Func<TFrom, bool>, Func<TTo, bool>>(from);
        }

        public static Expression<Func<TTo, decimal>> ConvertToExpression<TFrom, TTo>(this Expression<Func<TFrom, decimal>> from)
        {
            return ConvertImpl<Func<TFrom, decimal>, Func<TTo, decimal>>(from);
        }

        private static Expression<TTo> ConvertImpl<TFrom, TTo>(Expression<TFrom> from)
            where TFrom : class
            where TTo : class
        {
            // figure out which types are different in the function-signature
            var fromTypes = from.Type.GetGenericArguments();
            var toTypes = typeof(TTo).GetGenericArguments();

            if (fromTypes.Length != toTypes.Length)
                throw new NotSupportedException("Incompatible lambda function-type signatures");

            var typeMap = new Dictionary<Type, Type>();
            for (var i = 0; i < fromTypes.Length; i++)
            {
                if (fromTypes[i] != toTypes[i])
                    typeMap[fromTypes[i]] = toTypes[i];
            }

            // re-map all parameters that involve different types
            var parameterMap = new Dictionary<Expression, Expression>();
            var newParams = new ParameterExpression[from.Parameters.Count];
            for (var i = 0; i < newParams.Length; i++)
            {
                if (typeMap.TryGetValue(from.Parameters[i].Type, out var newType))
                {
                    parameterMap[from.Parameters[i]] = newParams[i] = Expression.Parameter(newType, from.Parameters[i].Name);
                }
                else
                {
                    newParams[i] = from.Parameters[i];
                }
            }

            // rebuild the lambda
            var body = new TypeConversionVisitor(parameterMap).Visit(from.Body);
            return Expression.Lambda<TTo>(body ?? throw new InvalidOperationException(), newParams);
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
            GeneralPropertyComparer<T, TKey> comparer = new GeneralPropertyComparer<T, TKey>(property);
            return items.Distinct(comparer);
        }
    }

    internal class TypeConversionVisitor : ExpressionVisitor
    {
        private readonly Dictionary<Expression, Expression> _parameterMap;

        public TypeConversionVisitor(Dictionary<Expression, Expression> parameterMap)
        {
            _parameterMap = parameterMap;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            // re-map the parameter
            if (!_parameterMap.TryGetValue(node, out var found))
                found = base.VisitParameter(node);
            return found;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            // re-perform any member-binding
            var expr = Visit(node.Expression);
            if (expr != null && expr.Type != node.Type)
            {
                var newMember = expr.Type.GetMember(node.Member.Name).Single();
                return Expression.MakeMemberAccess(expr, newMember);
            }
            return base.VisitMember(node);
        }
    }

    public class GeneralPropertyComparer<T, TKey> : IEqualityComparer<T>
    {
        private Func<T, TKey> ExpressionFunc { get; }
        public GeneralPropertyComparer(Func<T, TKey> expr)
        {
            ExpressionFunc = expr;
        }
        public bool Equals(T left, T right)
        {
            var leftProp = ExpressionFunc.Invoke(left);
            var rightProp = ExpressionFunc.Invoke(right);
            if (leftProp == null && rightProp == null)
                return true;
            if (leftProp == null ^ rightProp == null)
                return false;
            return leftProp.Equals(rightProp);
        }
        public int GetHashCode(T obj)
        {
            var prop = ExpressionFunc.Invoke(obj);
            return (prop == null) ? 0 : prop.GetHashCode();
        }
    }
}