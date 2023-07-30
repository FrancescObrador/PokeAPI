using System;
using UnityEngine;

namespace PokeApiCSharp
{
    /// <summary>
    /// Definition of Pokemon Generation for PokeAPI
    /// </summary>
    [Serializable]
    public class Generation
    {
        public string name;
        public Uri url;
    }
    
    /// <summary>
    /// Definition of Pokemon Species list for PokeAPI
    /// </summary>
    [Serializable]
    public class PokemonSpecies
    {
        public int count;
        public Generation[] results;
            
        public static PokemonSpecies CreateFromJson(string jsonString)
        {
            return JsonUtility.FromJson<PokemonSpecies>(jsonString);
        }
    }
}