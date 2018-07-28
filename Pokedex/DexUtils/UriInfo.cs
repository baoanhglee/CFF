// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using DexUtils;
//
//    var uriInfo = UriInfo.FromJson(jsonString);

namespace Cyberdex.DexUtils
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class UriInfo
    {
        [JsonProperty("evolution-chain")]
        public string EvolutionChain { get; set; }

        [JsonProperty("move-battle-style")]
        public string MoveBattleStyle { get; set; }

        [JsonProperty("generation")]
        public string Generation { get; set; }

        [JsonProperty("evolution-trigger")]
        public string EvolutionTrigger { get; set; }

        [JsonProperty("move")]
        public string Move { get; set; }

        [JsonProperty("encounter-condition-value")]
        public string EncounterConditionValue { get; set; }

        [JsonProperty("pokemon")]
        public string Pokemon { get; set; }

        [JsonProperty("move-damage-class")]
        public string MoveDamageClass { get; set; }

        [JsonProperty("ability")]
        public string Ability { get; set; }

        [JsonProperty("pal-park-area")]
        public string PalParkArea { get; set; }

        [JsonProperty("contest-effect")]
        public string ContestEffect { get; set; }

        [JsonProperty("machine")]
        public string Machine { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("pokemon-color")]
        public string PokemonColor { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("item-attribute")]
        public string ItemAttribute { get; set; }

        [JsonProperty("pokeathlon-stat")]
        public string PokeathlonStat { get; set; }

        [JsonProperty("pokemon-habitat")]
        public string PokemonHabitat { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("pokemon-shape")]
        public string PokemonShape { get; set; }

        [JsonProperty("item-pocket")]
        public string ItemPocket { get; set; }

        [JsonProperty("pokemon-species")]
        public string PokemonSpecies { get; set; }

        [JsonProperty("stat")]
        public string Stat { get; set; }

        [JsonProperty("encounter-method")]
        public string EncounterMethod { get; set; }

        [JsonProperty("berry-flavor")]
        public string BerryFlavor { get; set; }

        [JsonProperty("nature")]
        public string Nature { get; set; }

        [JsonProperty("pokemon-form")]
        public string PokemonForm { get; set; }

        [JsonProperty("item-fling-effect")]
        public string ItemFlingEffect { get; set; }

        [JsonProperty("super-contest-effect")]
        public string SuperContestEffect { get; set; }

        [JsonProperty("move-ailment")]
        public string MoveAilment { get; set; }

        [JsonProperty("item-category")]
        public string ItemCategory { get; set; }

        [JsonProperty("move-learn-method")]
        public string MoveLearnMethod { get; set; }

        [JsonProperty("move-target")]
        public string MoveTarget { get; set; }

        [JsonProperty("location-area")]
        public string LocationArea { get; set; }

        [JsonProperty("move-category")]
        public string MoveCategory { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("growth-rate")]
        public string GrowthRate { get; set; }

        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("version-group")]
        public string VersionGroup { get; set; }

        [JsonProperty("berry")]
        public string Berry { get; set; }

        [JsonProperty("characteristic")]
        public string Characteristic { get; set; }

        [JsonProperty("egg-group")]
        public string EggGroup { get; set; }

        [JsonProperty("contest-type")]
        public string ContestType { get; set; }

        [JsonProperty("berry-firmness")]
        public string BerryFirmness { get; set; }

        [JsonProperty("encounter-condition")]
        public string EncounterCondition { get; set; }

        [JsonProperty("pokedex")]
        public string Pokedex { get; set; }

        [JsonProperty("revision")]
        public DateTimeOffset Revision { get; set; }
    }

    public partial class UriInfo
    {
        public static UriInfo FromJson(string json) => JsonConvert.DeserializeObject<UriInfo>(json, DexUtils.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this UriInfo self) => JsonConvert.SerializeObject(self, DexUtils.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
