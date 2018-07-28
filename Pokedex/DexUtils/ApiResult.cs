// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using CyberDex.DexUtils;
//
//    var apiResult = ApiResult.FromJson(jsonString);

namespace Cyberdex.DexUtils
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ApiResult
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<CommonResult> Results { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }

    public partial class CommonResult
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ApiResult
    {
        public static ApiResult FromJson(string json) => JsonConvert.DeserializeObject<ApiResult>(json, Cyberdex.DexUtils.Converter.Settings);
    }
}
