using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using ColorUtility = UnityEngine.ColorUtility;

using PokeApiCSharp;
public class Card : MonoBehaviour
{
    // Binds
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idText;
    public RawImage sprite;
    
    public GameObject abilitiesVerticalLayout;
    public TextMeshProUGUI textBase;

    private PokeApiClient _pokeApiClient;
    public async Task Initialize(PokeApiClient pokeApiClient, int id)
    {
        _pokeApiClient = pokeApiClient;
        gameObject.SetActive(false);
        await LoadPokemonData(id);
    }

    /// <summary>
    /// Card information load.
    /// </summary>
    private async Task LoadPokemonData(int id)
    {
        var pokemon = await _pokeApiClient.FetchPokemonDataAsync(id);

        // Set Pokemon Card info
        nameText.text = pokemon.name.FirstCharacterToUpper();
        idText.text = "#" + pokemon.id;
        sprite.texture = pokemon.sprite;

        foreach (var abilityHolder in pokemon.abilities)
        {
            var abilityText = Instantiate(textBase, abilitiesVerticalLayout.transform);
            abilityText.text = abilityHolder.ability.name.FirstCharacterToUpper().Replace("-", " ");
        }
        
        var colorCode = TypeColor.Colors[(int)pokemon.types[0].type.GetTypeId()];
        ColorUtility.TryParseHtmlString(colorCode, out Color color);
        GetComponent<Image>().color = color;
       
        gameObject.SetActive(true);
    }
}