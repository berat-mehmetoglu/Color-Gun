using UnityEngine;

namespace _Main.Scripts.GamePlay
{ 
    public class Gun : Singleton<Gun>
    {
        public MortyColor MortyColor { get; set; }
    }

    public enum ColorType
    {
        Red,
        Yellow,
        Blue,
        Orange,
        Purple,
    }
}