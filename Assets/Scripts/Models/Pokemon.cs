using System;

using UnityEngine;

namespace PokeApiCSharp
{
    [Serializable]
    public class PokemonSprites
    {
        public string front_default;
    }

    [Serializable]
    public class Abilities
    {
        [Serializable]
        public class Ability
        {
            public string name;
            public string url;
        }

        public Ability ability;
    }

    /// <summary>
    /// Definition of Pokemon for PokeAPI
    /// </summary>
    [Serializable]
    public class Pokemon
    {
        public int id;
        public string name;
        public PokemonSprites sprites;
        public Texture2D sprite;
        public Types[] types;
        public Abilities[] abilities;

        public static Pokemon CreateFromJson(string jsonString)
        {
            return JsonUtility.FromJson<Pokemon>(jsonString);
        }
    }
}