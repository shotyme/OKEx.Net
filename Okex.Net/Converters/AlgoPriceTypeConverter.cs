﻿using CryptoExchange.Net.Converters.JsonNet;

namespace Okex.Net.Converters;

internal class AlgoPriceTypeConverter : BaseConverter<OkexAlgoPriceType>
{
    public AlgoPriceTypeConverter() : this(true) { }
    public AlgoPriceTypeConverter(bool quotes) : base(quotes) { }

    protected override List<KeyValuePair<OkexAlgoPriceType, string>> Mapping => new List<KeyValuePair<OkexAlgoPriceType, string>>
    {
        new KeyValuePair<OkexAlgoPriceType, string>(OkexAlgoPriceType.Last, "last"),
        new KeyValuePair<OkexAlgoPriceType, string>(OkexAlgoPriceType.Index, "index"),
        new KeyValuePair<OkexAlgoPriceType, string>(OkexAlgoPriceType.Mark, "mark"),
    };
}