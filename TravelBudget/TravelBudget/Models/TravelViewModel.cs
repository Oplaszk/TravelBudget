using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class TravelViewModel
    {
        // IEnumerable<> jest interfejsem tylko do odczytu, co oznacza, że nie można modyfikować kolekcji, do której jest odwoływany.
        // List<> jest kolekcją, którą można modyfikować. Możesz dodawać, usuwać, aktualizować elementy w liście, co czyni ją bardziej elastyczną w kontekście zmiany danych.
        public IEnumerable<Travel> Travels { get; set; }
        public Travel travel { get; set; }
    }
}
