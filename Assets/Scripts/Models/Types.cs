using System;

namespace PokeApiCSharp
{
    public enum TypeId
    {
        normal,
        fire,
        water,
        electric,
        grass,
        ice,
        fighting,
        poison,
        ground,
        flying,
        psychic,
        bug,
        rock,
        ghost,
        dragon,
        dark,
        steel,
        fairy,
        none
    }

    /// <summary>
    /// Color for every pokemon type.
    /// </summary>
    public static class TypeColor
    {
        public static readonly string[] Colors =
        {
            "#929fa1", "#f79d5c", "#5794d2",
            "#efd34d", "#6bbe60", "#7bd1bf",
            "#c6406a", "#a66ec4", "#d2784a",
            "#90adda", "#f1717a", "#93c33f",
            "#c2b98d", "#546ca9", "#2271be",
            "#595664", "#5e91a0", "#e592e2"
        };
    }

    /// <summary>
    /// Definition of Pokemon Types for PokeAPI
    /// </summary>
    [Serializable]
    public class Types
    {
        public int slot;
        public Type type;
    }
    
    /// <summary>
    /// Definition of Pokemon Type for PokeAPI
    /// </summary>
    [Serializable]
    public class Type
    {
        public string name;
        public string url;

        public TypeId GetTypeId()
        {
            if (name == null)
            {
                return TypeId.none;
            }

            return (TypeId)System.Enum.Parse(typeof(TypeId), name);
        }
    }
}