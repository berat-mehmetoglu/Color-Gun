using UnityEngine;

namespace _Main.Scripts.GamePlay
{
    public class AmmoCreator : Singleton<AmmoCreator>
    {
        [SerializeField] private GameObject[] ammoPrefabs;
        [SerializeField] private Transform shootTransform;
         
        public GameObject CreateRed()
        {
            return Instantiate(ammoPrefabs[0], shootTransform.position, Quaternion.identity);
        } 

        public GameObject CreateYellow()
        {
            return Instantiate(ammoPrefabs[1], shootTransform.position, Quaternion.identity);
        } 
        
        public GameObject CreateBlue()
        {
            return Instantiate(ammoPrefabs[2], shootTransform.position, Quaternion.identity);
        } 
        
        public GameObject CreateOrange()
        {
            return Instantiate(ammoPrefabs[3], shootTransform.position, Quaternion.identity);
        } 
        
        public GameObject CreatePurple()
        {
            return Instantiate(ammoPrefabs[4], shootTransform.position, Quaternion.identity);
        } 
    }
}