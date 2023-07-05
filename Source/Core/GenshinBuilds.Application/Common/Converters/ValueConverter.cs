using GenshinBuilds.Application.Common.Converters.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Resolvers;

public class ValueConverterOptions
{
    internal readonly Dictionary<(Type, Type), object> Converters = new();

    public void RegisterConverter<TFrom, TTo>(IConverter<TFrom, TTo> converter)
    {
        Converters[(typeof(TFrom), typeof(TTo))] = converter;
    }
}

public class ValueConverter : IValueConverter
{
    private readonly ValueConverterOptions _options;

    protected ValueConverter() { }

    public ValueConverter(Action<ValueConverterOptions> options)
    {
        var converterOptions = new ValueConverterOptions();
        options(converterOptions);
        _options = converterOptions;
    }

    public TTo Convert<TFrom, TTo>(TFrom value)
    {
        Type fromType = typeof(TFrom);
        Type toType = typeof(TTo);

        if (_options.Converters.TryGetValue((fromType, toType), out object converterObj))
        {
            if (converterObj is IConverter<TFrom, TTo> converter)
            {
                return converter.Convert(value);
            }
            else
            {
                throw new InvalidOperationException($"Converter registered for type {fromType} is not of type IValueConverter<{fromType}, {toType}>.");
            }
        }

        throw new ConverterNotFoundException($"Converter not found for type {fromType}.");
    }

   
    protected bool Contains(string source, string value)
        => source.Contains(value, StringComparison.InvariantCultureIgnoreCase);
}
