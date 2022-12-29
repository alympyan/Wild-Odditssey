using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace AwesomsseyEngine
{
    [Serializable]
    public class SaveData : MonoBehaviour
    {
        [SerializeField] Scene startScene;
        [SerializeField] string startSceneString;

        [Header("Lvl Complete Bool GameEngie")]
        public  bool orchardCompleteS;
        public  bool heatlhUpS;
        bool carnevileUnlockedS;

        [Header("Atta Health")]
        [SerializeField] float attaCurrentHealthS;
        [SerializeField] float attaMAXHealthS;
        [SerializeField] float jumpCount;
        [SerializeField] public bool healthUP0S; ///SAVE VAR
        [SerializeField] public bool healthUP1S; ///SAVE VAR
        [SerializeField] public bool healthUP2S; ///SAVE VAR
        [SerializeField] public bool healthUP3S; ///SAVE VAR
        [SerializeField] public bool healthUP4S; ///SAVE VAR
        [SerializeField] public bool healthUP5S; ///SAVE VAR
        [SerializeField] public bool healthUP6S; ///SAVE VAR
        [SerializeField] public bool healthUP7S; ///SAVE VAR
        [SerializeField] public bool healthUP8S; ///SAVE VAR

        [Header("Items")]
       
        [SerializeField] float coinsCurrent;
        [SerializeField] public GameObject hotBarItemAS;///SAVE + LOAD
        [SerializeField] public GameObject item0AS; ///SAVE + LOAD
        [SerializeField] public GameObject item1AS; ///SAVE + LOAD
        [SerializeField] public GameObject item2AS; ///SAVE + LOAD
        [SerializeField] public GameObject item3AS; ///SAVE + LOAD
        [SerializeField] public GameObject item4AS; ///SAVE + LOAD
        [SerializeField] public GameObject item5AS; ///SAVE + LOAD
        [SerializeField] public string hotBarItemAString;///SAVE + LOAD
        [SerializeField] public string item0AString; ///SAVE + LOAD
        [SerializeField] public string item1AString; ///SAVE + LOAD
        [SerializeField] public string item2AString; ///SAVE + LOAD
        [SerializeField] public string item3AString; ///SAVE + LOAD
        [SerializeField] public string item4AString; ///SAVE + LOAD
        [SerializeField] public string item5AString; ///SAVE + LOAD
        [Header("Item Ups")]
        [SerializeField] public bool noUpgradeAS; ///SAVE + LOAD
        [SerializeField] public bool deepPocketsAS; ///SAVE + LOAD
        [SerializeField] public bool baggyPocketsAS; ///SAVE + LOAD
        [Header("Seeds")]
        [SerializeField] public float seedAmmoCurrentS; ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public float seedAmmoMaxS; ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp0S;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp1S;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp2S;  ///SAVE VAR - FEED TO GAMEENGNE

        [Header("LuckyJumps")]
        [SerializeField]  bool luckyJumpModeS;
        [SerializeField]  bool yellowJumpS;///SAVE + LOAD 
        [SerializeField]  bool blueJumpS;///SAVE + LOAD 
        [SerializeField]  bool greenJumpS;///SAVE + LOAD 
        [SerializeField]  bool redJumpS;///SAVE + LOAD 
        [SerializeField]  bool bowJumpS;///SAVE + LOAD 
        [SerializeField]  float luckJCountS;///SAVE + LOAD 
        [SerializeField]  float luckJMAXS; ///Save + LOAD

        [SerializeField] InvAtta inventory;
        [SerializeField] JumpBasic jumpBasic;
        [SerializeField] LuckyJump luckyJump;
        [SerializeField] GameEngine gameEngine;
        [SerializeField] AttaHealth attaHealth;
        [SerializeField] CoinsAInventory attaCoins;
        [SerializeField] SeedShot seeds;
        [SerializeField] public bool loadedRef;
        // Start is called before the first frame update
        void Start()
        {
            jumpBasic = FindObjectOfType<JumpBasic>();
            luckyJump = FindObjectOfType<LuckyJump>();
            gameEngine = FindObjectOfType<GameEngine>();
            attaHealth = FindObjectOfType<AttaHealth>();
            inventory = FindObjectOfType<InvAtta>();
            attaCoins = FindObjectOfType<CoinsAInventory>();
            seeds= FindObjectOfType<SeedShot>();
            loadedRef = true;
            LoadGame();///Switch To GameObject To Call Script
        }

        // Update is called once per frame
         void Update()
        {
            ///Lcuky Jumps
            luckJMAXS = luckyJump.luckJMAX;
            luckJCountS = luckyJump.luckJCount;
            yellowJumpS = luckyJump.yellowJump;
            blueJumpS = luckyJump.blueJump;
            greenJumpS = luckyJump.greenJump;
            redJumpS = luckyJump.redJump;
            bowJumpS = luckyJump.bowJump;

            ///End Luck
            ///
            ///Level Complete Bools 
            orchardCompleteS = gameEngine.orchardUnlocked;
            carnevileUnlockedS = gameEngine.carnevileUnlocked;

            ///EndLevel

            ///Health
            attaCurrentHealthS = attaHealth.currentPlayerHealth;
            attaMAXHealthS = attaHealth.CurrentPlayerMaxHealth;
            healthUP0S = attaHealth.healthUP0;
            healthUP1S = attaHealth.healthUP1;
            healthUP2S = attaHealth.healthUP2;
            healthUP3S = attaHealth.healthUP3;
            healthUP4S = attaHealth.healthUP4;
            healthUP5S = attaHealth.healthUP5;
            healthUP6S = attaHealth.healthUP6;
            healthUP7S = attaHealth.healthUP7;
            healthUP8S = attaHealth.healthUP8;

            ///Inventory - Coins Too
            coinsCurrent = attaCoins.coinsCurrent;
            //item0AS = inventory.item0A;
            //item1AS = inventory.item1A;
            //item2AS = inventory.item2A;
            //item3AS = inventory.item3A;
            //item4AS = inventory.item4A;
            // item5AS = inventory.item5A;
            //Strings
            item0AString = inventory.item0AString;
            item1AString = inventory.item1AString;
            item2AString = inventory.item2AString;
            item3AString = inventory.item3AString;
            item4AString = inventory.item4AString;
            item5AString = inventory.item5AString;
            ///SAVE STRINGS FROM OBJ
            ///LOAD DAta to Strings then load inv.object by item string using Find
            //inventory.item0A = GameObject.Find(item0AString);

            noUpgradeAS = inventory.noUpgradeA;
            deepPocketsAS = inventory.deepPocketsA;
            baggyPocketsAS = inventory.baggyPocketsA;

            ///Seeds
            seedAmmoCurrentS = seeds.seedAmmoCurrent;
            seedAmmoMaxS = seeds.seedAmmoMax;
            ammoUp0S = seeds.ammoUp0;
            ammoUp1S = seeds.ammoUp1;
            ammoUp2S = seeds.ammoUp2;


        }


       public void SaveGame()
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
                         + "/OdditsseyData.oddt");
            SaveStorage storage = new SaveStorage();
            ///SAVE STARTS
            ///Lcuky Jumps
            ///
            storage.luckyJumpModeS = luckyJump.luckyJumpMode;
            storage.luckJMAXS = luckyJump.luckJMAX;
            storage.luckJCountS = luckyJump.luckJCount;
            storage.yellowJumpS = luckyJump.yellowJump;
            storage.blueJumpS = luckyJump.blueJump;
            storage.greenJumpS = luckyJump.greenJump;
            storage.redJumpS = luckyJump.redJump;
            storage.bowJumpS = luckyJump.bowJump;

            ///End Luck
            ///
            ///Level Complete Bools 
            storage.orchardCompleteS = gameEngine.orchardUnlocked;
            storage.carnevileUnlockedS = gameEngine.carnevileUnlocked;

            ///EndLevel

            ///Health
            storage.lifeCurrentS = attaHealth.lifeCurrent;
            storage.attaCurrentHealthS = attaHealth.currentPlayerHealth;
            storage.attaMAXHealthS = attaHealth.CurrentPlayerMaxHealth;
            storage.healthUP0S = attaHealth.healthUP0;
            storage.healthUP1S = attaHealth.healthUP1;
            storage.healthUP2S = attaHealth.healthUP2;
            storage.healthUP3S = attaHealth.healthUP3;
            storage.healthUP4S = attaHealth.healthUP4;
            storage.healthUP5S = attaHealth.healthUP5;
            storage.healthUP6S = attaHealth.healthUP6;
            storage.healthUP7S = attaHealth.healthUP7;
            storage.healthUP8S = attaHealth.healthUP8;

            ///Inventory - Coins Too
            storage.coinsCurrent = attaCoins.coinsCurrent;
            storage.item0AString = inventory.item0AString;
            storage.item1AString = inventory.item1AString;
            storage.item2AString = inventory.item2AString;
            storage.item3AString = inventory.item3AString;
            storage.item4AString = inventory.item4AString;
            storage.item5AString = inventory.item5AString;
            storage.noUpgradeAS = inventory.noUpgradeA;
            storage.deepPocketsAS = inventory.deepPocketsA;
            storage.baggyPocketsAS = inventory.baggyPocketsA;

            ///Seeds
            storage.seedAmmoCurrentS = seeds.seedAmmoCurrent;
            storage.seedAmmoMaxS = seeds.seedAmmoMax;
            storage.ammoUp0S = seeds.ammoUp0;
            storage.ammoUp1S = seeds.ammoUp1;
            storage.ammoUp2S = seeds.ammoUp2;

            ///END SAVE LOOP
            bf.Serialize(file, storage);
            file.Close();
            Debug.Log("Game data saved!");
        }



       public void LoadGame()
        {
            if (File.Exists(Application.persistentDataPath
                           + "/OdditsseyData.oddt"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                           File.Open(Application.persistentDataPath
                           + "/OdditsseyData.oddt", FileMode.Open);
                SaveStorage storage = (SaveStorage)bf.Deserialize(file);
                file.Close();
                ///LOAD STARTS !!!!!!!!!!

                ///SceneManager.LoadSceneAsync("SampleScene"); ///LOAD SCENE FIRST In Game Menu From Continue!
                ///Lcuky Jumps
            luckyJump.luckyJumpMode = storage.luckyJumpModeS;
            luckyJump.luckJMAX = storage.luckJMAXS; 
            luckyJump.luckJCount = storage.luckJCountS;
            luckyJump.yellowJump = storage.yellowJumpS;
            luckyJump.blueJump = storage.blueJumpS;
            luckyJump.greenJump = storage.greenJumpS;
            luckyJump.redJump = storage.redJumpS;
            luckyJump.bowJump = storage.bowJumpS;
                ///Level Complete Bools 
            gameEngine.orchardUnlocked = storage.orchardCompleteS;
            gameEngine.carnevileUnlocked = storage.carnevileUnlockedS;
                //MORE TO COME
                ///Health
                attaHealth.lifeCurrent = storage.lifeCurrentS;
                attaHealth.currentPlayerHealth = storage.attaCurrentHealthS;
                attaHealth.CurrentPlayerMaxHealth = storage.attaMAXHealthS;
                attaHealth.healthUP0 = storage.healthUP0S;
                attaHealth.healthUP1 = storage.healthUP1S;
                attaHealth.healthUP2 = storage.healthUP2S;
                attaHealth.healthUP3 = storage.healthUP3S;
                attaHealth.healthUP4 = storage.healthUP4S;
                attaHealth.healthUP5 = storage.healthUP5S;
                attaHealth.healthUP6 = storage.healthUP6S;
                attaHealth.healthUP7 = storage.healthUP7S;
                attaHealth.healthUP8 = storage.healthUP8S;
                ///
                ///Inventory - Coins Too
                attaCoins.coinsCurrent = storage.coinsCurrent;
                inventory.item0AString = storage.item0AString;
                inventory.item1AString = storage.item1AString;
                inventory.item2AString = storage.item2AString;
                inventory.item3AString = storage.item3AString;
                inventory.item4AString = storage.item4AString;
                inventory.item5AString = storage.item5AString;
                inventory.noUpgradeA = storage.noUpgradeAS;
                inventory.deepPocketsA = storage.deepPocketsAS;
                inventory.baggyPocketsA = storage.baggyPocketsAS;
                ///END Inven
                ///Seeds
                seeds.seedAmmoCurrent = storage.seedAmmoCurrentS;
                seeds.seedAmmoMax = storage.seedAmmoMaxS;
                seeds.ammoUp0 = storage.ammoUp0S;
                seeds.ammoUp1 = storage.ammoUp1S;
                seeds.ammoUp2 = storage.ammoUp2S;



                Debug.Log("Game data loaded!");
            }
            else
                Debug.LogError("There is no save data!");
        }




    }

   

    [Serializable]
    class SaveStorage
    {
        /// <summary>
        /// NO GAMEOBJECTS
        /// </summary>
        [Header("Lvl Complete Bool GameEngie")]
        public bool orchardCompleteS;
        public bool heatlhUpS;
        public bool carnevileUnlockedS;

        [Header("Atta Health")]
        [SerializeField] public float attaCurrentHealthS;
        [SerializeField] public float attaMAXHealthS;
        [SerializeField] public float jumpCount;
        [SerializeField] public float  lifeCurrentS;
        [SerializeField] public bool healthUP0S; ///SAVE VAR
        [SerializeField] public bool healthUP1S; ///SAVE VAR
        [SerializeField] public bool healthUP2S; ///SAVE VAR
        [SerializeField] public bool healthUP3S; ///SAVE VAR
        [SerializeField] public bool healthUP4S; ///SAVE VAR
        [SerializeField] public bool healthUP5S; ///SAVE VAR
        [SerializeField] public bool healthUP6S; ///SAVE VAR
        [SerializeField] public bool healthUP7S; ///SAVE VAR
        [SerializeField] public bool healthUP8S; ///SAVE VAR

        [Header("Items")]

        [SerializeField] public float coinsCurrent;
      
        [SerializeField] public string hotBarItemAString;///SAVE + LOAD
        [SerializeField] public string item0AString; ///SAVE + LOAD
        [SerializeField] public string item1AString; ///SAVE + LOAD
        [SerializeField] public string item2AString; ///SAVE + LOAD
        [SerializeField] public string item3AString; ///SAVE + LOAD
        [SerializeField] public string item4AString; ///SAVE + LOAD
        [SerializeField] public string item5AString; ///SAVE + LOAD
        [Header("Item Ups")]
        [SerializeField] public bool noUpgradeAS; ///SAVE + LOAD
        [SerializeField] public bool deepPocketsAS; ///SAVE + LOAD
        [SerializeField] public bool baggyPocketsAS; ///SAVE + LOAD
        [Header("Seeds")]
        [SerializeField] public float seedAmmoCurrentS; ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public float seedAmmoMaxS; ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp0S;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp1S;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp2S;  ///SAVE VAR - FEED TO GAMEENGNE

        [Header("LuckyJumps")]
        [SerializeField] public bool luckyJumpModeS;
        [SerializeField] public bool yellowJumpS;///SAVE + LOAD 
        [SerializeField] public bool blueJumpS;///SAVE + LOAD 
        [SerializeField] public bool greenJumpS;///SAVE + LOAD 
        [SerializeField] public bool redJumpS;///SAVE + LOAD 
        [SerializeField] public bool bowJumpS;///SAVE + LOAD 
        [SerializeField] public float luckJCountS;///SAVE + LOAD 
        [SerializeField] public float luckJMAXS; ///Save + LOAD

       
    }
}
