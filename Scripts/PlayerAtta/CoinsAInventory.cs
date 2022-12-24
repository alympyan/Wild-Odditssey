using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// Class Controls Coins and Inventories in Inventory
    /// Sepoerate Class for GUI Updates?
    /// Feed to SaveMAster 
    /// Load From SaveMaster
    /// </summary>
    public class CoinsAInventory : MonoBehaviour
    {
        [Header("Coin Counting")]
        [SerializeField] public float coinsCurrent;///SAVEMASTER - Send TO GUIUPDATER


        [Header("Scripts")]
        [SerializeField] GUIUpdater guiUpdater;
        [SerializeField] GameEngine gameEngine;
        ///FUTURE FOR COLLISIONS SCRIPT 


        // Start is called before the first frame update
        void Start()
        {
            guiUpdater = FindObjectOfType<GUIUpdater>();
            gameEngine = FindObjectOfType<GameEngine>();
        }

        // Update is called once per frame
        void Update()
        {
            guiUpdater = FindObjectOfType<GUIUpdater>();
        }
    }

}