using System;
using System.Threading.Tasks;

using UnityEngine.Networking;

namespace PokeApiCSharp
{
    public class PokeApiClient
    {
        private UnityWebRequest _webRequest;
        private readonly Uri _basePokemonUrl = new Uri("https://pokeapi.co/api/v2/");

        /// <summary>
        /// Generic web request function
        /// </summary>
        public async Task<string> MakePokeApiWebRequest(Uri endpoint)
        {
            _webRequest = UnityWebRequest.Get(endpoint);
            _webRequest.SendWebRequest();

            while (!_webRequest.isDone)
            {
                await Task.Delay(5);
            }

            if (_webRequest.result != UnityWebRequest.Result.Success)
            {
                return null;
            }

            return _webRequest.downloadHandler.text;
        }
        
        /// <summary>
        /// Get the pokemon count.
        /// </summary>
        public async Task<int> FetchPokemonCount()
        {
            Uri endpoint = new Uri(_basePokemonUrl,"pokemon-species");
            
            var rawData = await MakePokeApiWebRequest(endpoint);

            PokemonSpecies data = PokemonSpecies.CreateFromJson(rawData);

            return data.count;
        }
        
        /// <summary>
        /// Get the data of a Pokemon by it's id
        /// </summary>
        public async Task<Pokemon> FetchPokemonDataAsync(int id)
        { 
            Uri endpoint = new Uri(_basePokemonUrl,"pokemon/" + id);
           
            var rawData = await MakePokeApiWebRequest(endpoint);

            Pokemon pokemon = Pokemon.CreateFromJson(rawData);

            ImageLoader imageLoader = new ImageLoader();

            pokemon.sprite = await imageLoader.FetchTexture(pokemon.sprites.front_default);

            return pokemon;
        }
    }
}