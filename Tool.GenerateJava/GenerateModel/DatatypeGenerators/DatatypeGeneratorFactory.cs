using System;
using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    static class DatatypeGeneratorFactory
    {
        public static IDatatypeGenerator Get(GenProperty prop, string sourceNamespace)
        {
            if (prop.PropType == typeof (string))
            {
                return new StringPGen(prop);
            }
            if (prop.PropType == typeof (int))
            {
                if (prop.Name.EndsWith("DateKey"))
                {
                    return new DateKeyPGen(prop);
                }
                return new Int32PGen(prop);
            }
            if (prop.PropType == typeof (short))
            {
                return new Int16PGen(prop);
            }
            if (prop.PropType == typeof (decimal)
                || prop.PropType == typeof (double))
            {
                return new NumberPGen(prop);
            }
            if (prop.PropType == typeof (long)) // javascript really can't deal with longs
            {
                return new LongPGen(prop);
            }
            if (prop.PropType == typeof (bool))
            {
                return new BooleanPGen(prop);
            }
            if (prop.PropType == typeof (byte))
            {
                return new BytePGen(prop);
            }
            if (prop.PropType == typeof (DateTime))
            {
                return new DateTimePGen(prop);
            }
            if (prop.PropType == typeof (DateTime?))
            {
                return new NullDateTimePGen(prop);
            }
            if (prop.PropType == typeof (DateTimeOffset))
            {
                return new DateTimeOffsetPGen(prop);
            }
            if (prop.PropType == typeof (DateTimeOffset?))
            {
                return new NullDateTimeOffsetPGen(prop);
            }
            if (prop.PropType == typeof (int[])
                || prop.PropType == typeof (List<int>)
                || prop.PropType == typeof (byte[]))
            {
                return new Int32ArrayPGen(prop);
            }
            if (prop.PropType == typeof (string[])
                || prop.PropType == typeof (List<string>))
            {
                return new StringArrayPGen(prop);
            }
            if (prop.PropType == typeof (double[])
                || prop.PropType == typeof (decimal[]))
            {
                return new NumberArrayPGen(prop);
            }
            if (prop.PropType.IsClass
                && (prop.PropType.Namespace ?? "").StartsWith(sourceNamespace))
            {
                return new LocalClassPGen(prop);
            }
            if (prop.PropType.Name == "List`1"
                && prop.PropType.Namespace == "System.Collections.Generic"
                && prop.PropType.IsGenericType
                && prop.PropType.GenericTypeArguments.Length == 1
                && (prop.PropType.GenericTypeArguments[0].Namespace ?? "").StartsWith(sourceNamespace))
            {
                if (prop.PropType.GenericTypeArguments[0].IsEnum)
                {
                    return new EnumArrayPGen(prop);
                }
                return new LocalClassArrayPGen(prop);
            }
            if (prop.PropType == typeof (long?))
            {
                return new NullLongPGen(prop);
            }
            if (prop.PropType == typeof (decimal?)
                || prop.PropType == typeof (float?)
                || prop.PropType == typeof (double?))
                //|| prop.PropType == typeof(long?)) // javascript really can't handle longs
            {
                return new NullNumberPGen(prop);
            }
            if (prop.PropType == typeof (bool?))
                //|| prop.PropType == typeof(long?)) // javascript really can't handle longs
            {
                return new NullBooleanPGen(prop);
            }
            if (prop.PropType == typeof (int?))
            {
                if (prop.Name.EndsWith("DateKey"))
                {
                    return new NullDateKeyPGen(prop);
                }
                return new NullInt32PGen(prop);
            }
            if (prop.PropType.IsEnum
                && (prop.PropType.Namespace ?? "").StartsWith(sourceNamespace))
            {
                return new EnumPGen(prop);
            }
            if (prop.PropType.Name == "Nullable`1"
                && prop.PropType.IsGenericType
                && prop.PropType.GenericTypeArguments.Length == 1
                && (prop.PropType.GenericTypeArguments[0].Namespace ?? "").StartsWith(sourceNamespace)
                && prop.PropType.GenericTypeArguments[0].IsEnum)
            {
                return new NullEnumPGen(prop);

            }
            if (prop.PropType.Name == "IEnumerable`1"
                && prop.PropType.IsGenericType
                && prop.PropType.GenericTypeArguments.Length == 1
                && (prop.PropType.GenericTypeArguments[0].Namespace ?? "").StartsWith(sourceNamespace)
                && prop.PropType.GenericTypeArguments[0].IsClass)
            {
                return new EnumerableLocalClassPGen(prop);
            }
            if (prop.PropType == typeof (object))
            {
                return new ObjectPGen(prop);
            }
            return new UnsupportedPGen(prop);
        }
    }
}
