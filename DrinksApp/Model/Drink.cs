using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksApp.Model {
    public class Drink {
        [JsonPropertyName("idDrink")]
        public string ID { get; set; }
        [JsonPropertyName("strDrink")]
        public string Name { get; set; }
        [JsonPropertyName("strCategory")]
        public string Category { get; set; }
        [JsonPropertyName("strIBA")]
        public string IBA { get; set; }
        [JsonPropertyName("strAlcoholic")]
        public string Alcoholic { get; set; }
        [JsonPropertyName("strGlass")]
        public string Glass { get; set; }
        [JsonPropertyName("strInstructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("strDrinkThumb")]
        public string Thumbnail { get; set; }
    }
}