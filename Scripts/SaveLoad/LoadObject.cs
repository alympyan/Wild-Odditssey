using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class LoadObject : MonoBehaviour
    {
        /// <summary>
        /// Class Loads Game On Start of LandRide Station 
        /// </summary>
        [SerializeField] SaveData saveData;

        // Start is called before the first frame update
        void Start()
        {
            if(saveData.loadedRef == true)
            { saveData.LoadGame(); }    
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
