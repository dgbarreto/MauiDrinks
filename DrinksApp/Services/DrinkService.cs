using DrinksApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DrinksApp.Services {
    public class DrinkService {
        HttpClient httpClient;
        List<Drink> drinksList;
        //const string REQUEST_URL = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita";
        const string REQUEST_URL = "https://gist.githubusercontent.com/dgbarreto/b04b167bc3eb58925c14ee55c69a7746/raw/9769d0a77014bd82c8eb060984e5dbed824712da/drinks.json";

        public DrinkService() { 
            httpClient = new HttpClient();
        }

        public async Task<List<Drink>> GetDrinksAsync(){
            if(drinksList?.Count > 0) {
                return drinksList;
            }

            var response = await httpClient.GetAsync(REQUEST_URL);

            if(response.IsSuccessStatusCode) {
                drinksList = await response.Content.ReadFromJsonAsync<List<Drink>>();
            }

            return drinksList;
        }
    }
}
