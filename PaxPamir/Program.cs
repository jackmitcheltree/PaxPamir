﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PaxPamir
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string jsonFilePath = @"C:\Users\jackm\Desktop\Random\testdeckpax.json";
            string jsonString = File.ReadAllText(jsonFilePath);

            //var options = new JsonSerializerOptions
            //{
            //    Converters = { new JsonStringEnumConverter() },
            //    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            //};

            //var deserializedObject = JsonSerializer.Deserialize<List<Card>>(jsonString, options);

            //// Use the deserialized object as needed
            //Console.WriteLine(deserializedObject?.Count);

            var settings = new JsonSerializerSettings
            {
                Converters = { new StringEnumConverter() }
            };
            var cards = JsonConvert.DeserializeObject<List<Card>>(jsonString, settings);
            var k = cards?.Count;

        }
    }
}

//card templates
//{
//"CardType" : "EventCard",
//    "Purchase" : "",
//    "Discard" : ""
//},
//{
//"CardType" : "PlayerCard",
//    "Rank" : 0,
//    "Suit" : "",
//    "Onplays" : [], 
//    "Region" : "",
//    "Actions" : [],
//    "Passives" : [],
//    "Patriot" : "",
//    "Bonus" : ""
//},