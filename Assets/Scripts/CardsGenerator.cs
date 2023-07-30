using System.Collections;
using System.Threading.Tasks;
using PokeApiCSharp;
using UnityEngine;

public class CardsGenerator : MonoBehaviour
{
    public int generation = 1;
    public int size = 1;
    public GameObject cardPrefab;

    private PokeApiClient _pokeApiClient;

    void Start()
    {
        _pokeApiClient = new PokeApiClient();
        CreateCardsFromPokemonId();
    }
    
    /// <summary>
    /// Get the total number of Pokemon
    /// </summary>
    public async Task<int> GetPokemonCount()
    {
        return await _pokeApiClient.FetchPokemonCount();
    }

    /// <summary>
    /// Create a card for every pokemon
    /// </summary>
    private async void CreateCardsFromPokemonId()
    {
        size = await GetPokemonCount();
        
        for (int id = 1; id <= size; id++)
        {
            var card = Instantiate(cardPrefab, this.transform);
            await card.GetComponent<Card>().Initialize(_pokeApiClient, id);
        }
    }
}
