using UnityEngine;

namespace _Main.Scripts.GamePlay
{ 
    public class Gun : MonoBehaviour
    {
        public ColorType ColorType { get; set; }
        
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