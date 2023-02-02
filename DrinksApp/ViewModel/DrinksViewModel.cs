using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrinksApp.Model;
using DrinksApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksApp.ViewModel {
    public partial class DrinksViewModel : BaseViewModel {
        public ObservableCollection<Drink> Drinks { get; } = new();
        DrinkService drinkService;

        public DrinksViewModel(DrinkService drinkService) {
            this.Title = "Drinks";
            this.drinkService = drinkService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetDrinksAsync() {
            if (IsBusy) return;

            try {
                IsBusy = true;

                var drinks = await drinkService.GetDrinksAsync();

                if (drinks.Count > 0) {
                    Drinks.Clear();
                }

                drinks.ForEach(d => Drinks.Add(d));
            }
            catch (Exception ex) {
                Debug.WriteLine($"Unable to return drinks {ex.Message}");
                await Shell.Current.DisplayAlert("Message", "Unable to fetch drinks!", "OK");
            }
            finally {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
