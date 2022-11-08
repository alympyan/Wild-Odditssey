using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UIElements;
using UnityEngine;


namespace AwesomsseyEngine
{

    public class GUIUpdater : MonoBehaviour
    {
        /// <summary>
        /// CLASS UPDATES GUI
        /// FEEDS FROM GAMEENGINE & PLAYER SCRIPTS
        /// PLAYER SCRIPTS SAVE OWN DATA AND SEND TO HERE FOR GUI UPDATES
        /// </summary>
        /// 

        [Header("Script")]
        [SerializeField] GameEngine gameEngine; ///LINKS ALL VARS
        [SerializeField] SeedShot seedShot; /// CALLS FOR SEED AMMO AND UPgrades
        [SerializeField] AttaHealth attaHealth;
        [SerializeField] CoinsAInventory coinsAInventory;
        /// <summary>
        /// FUTURE COIN 
        /// </summary>

        [Header("Health GUI Images")]
        [SerializeField] Image[] healthImageArray;
        [SerializeField] Image healthImage;
        [SerializeField] Sprite healthFull;
        [SerializeField] Sprite healthEmpty;
        [Tooltip("GUI VAR FEEDS FROM ATTHEALTH")]
        [SerializeField] float healthCurrentGUI; ///FEEDS FROM GAMEENGINE - From PlayerHealthscript
        [Tooltip("GUI VAR FEEDS FROM ATTHEALTH")]
        [SerializeField] float healthMaxGUI; ///FEEDS FROM GAMEENGINE


        [Header("AmmoGUI Images")]
        [SerializeField] Image[] ammoImageArray;
        //[SerializeField] Image ammoImage;
        [SerializeField] Sprite ammoFull;
        [SerializeField] Sprite ammoEmpty;
        [SerializeField] float ammoCurrentGUI; ///FEEDS FROM GAMEENGINE - From PlayerHealthscript
        [SerializeField] float ammoMaxGUI; ///FEEDS FROM GAMEENGINE
        [SerializeField] bool powerEquipped;///SAVE - LOAD TO SEEDSHOT
        [SerializeField] bool deviEquipped;///SAVE - LOAD TO SEEDSHOT
        [SerializeField] bool slappinEquipped;///SAVE - LOAD TO SEEDSHOT
        [SerializeField] bool ammoUp0GUI;///SAVE - LOAD TO SEEDSHOT
        [SerializeField] bool ammoUp1GUI;///SAVE - LOAD TO SEEDSHOT
        [SerializeField] bool ammoUp2GUI;///SAVE - LOAD TO SEEDSHOT
        [SerializeField] Sprite powerSpriteFull;
        [SerializeField] Sprite deviSpriteFull;
        [SerializeField] Sprite slappingSpriteFull;

        [Header("Life GUI")]
        [SerializeField] float lifeCountGUI;
        [SerializeField] string lifeStringForGui;
        [SerializeField] TMP_Text lifeTexField;

        [Header("Coins")]
        [SerializeField] float coinCount;
        [SerializeField] string coinStringForGui;
        [SerializeField] TMP_Text coinTextField;

        [Header("LevelName")]
        [SerializeField] LevelName levelNameScript;
        [SerializeField] string levelString;
        [SerializeField] TMP_Text levelTextField;



        // Start is called before the first frame update
        void Start()
        {
            gameEngine = FindObjectOfType<GameEngine>();
            seedShot = FindObjectOfType<SeedShot>();
            attaHealth = FindObjectOfType<AttaHealth>();
            coinsAInventory = FindObjectOfType<CoinsAInventory>();
        }

        // Update is called once per frame
        void Update() ///GATRHER VARS FROM SCRIPTS
                      ///RUN GUI UPDATE PROGRAMS
        {
            ///HEALTH ++ UPGRADES /LIFE
            healthCurrentGUI = attaHealth.currentPlayerHealth;
            healthMaxGUI = attaHealth.CurrentPlayerMaxHealth;
            lifeCountGUI = attaHealth.lifeCurrent;
            ///AMMO ++ UPGRADES 
            ammoUp0GUI = seedShot.ammoUp0;
            ammoUp1GUI = seedShot.ammoUp1;
            ammoUp2GUI = seedShot.ammoUp2;
            powerEquipped = seedShot.powerSeeds;
            deviEquipped = seedShot.deviSeeds;
            slappinEquipped = seedShot.slappingSeeds;
            ammoCurrentGUI = seedShot.seedAmmoCurrent;
            ammoMaxGUI = seedShot.seedAmmoMax;
            ///Coins
            coinCount = coinsAInventory.coinsCurrent;
            ///LvelName GRAB REF EVERY LAND
            levelNameScript = FindObjectOfType<LevelName>();
            levelString = levelNameScript.levelName;
            ///RUN PROGRAMS
            LifeProgramGUI();
            HealthProgramGUI();
            CoinProgramGUI();
            AmmoProgramGUI();
            LevelNameGUI();
        }

        void LifeProgramGUI()
        {///Convert LifeCount to String, send to GUI TEXT FIELD
            lifeStringForGui = lifeCountGUI.ToString();
            lifeTexField.text = "X" + lifeStringForGui;
        }

        void CoinProgramGUI()
        {
            coinStringForGui = coinCount.ToString();
            coinTextField.text = "x " + coinStringForGui;
        }

        void AmmoProgramGUI()
        {
            for (int i = 0; i < ammoImageArray.Length; i++)
            {
                if (i < ammoCurrentGUI)
                {
                    ammoImageArray[i].sprite = ammoFull;
                }
                else
                {
                    ammoImageArray[i].sprite = ammoEmpty;

                }
                if (i < ammoMaxGUI)
                {
                    
                    ammoImageArray[i].enabled = true;
                }
                else
                {
                    ammoImageArray[i].enabled = false;
                }
            }
        }

            void HealthProgramGUI() ///For Loop 
            {
                for (int i = 0; i < healthImageArray.Length; i++)
                {
                    if (i < healthCurrentGUI)
                    {
                        healthImageArray[i].sprite = healthFull;
                    }
                    else
                    {
                        healthImageArray[i].sprite = healthEmpty;
                    }
                    if (i < healthMaxGUI)
                    {
                        healthImageArray[i].enabled = true;
                    }
                    else
                    {
                        healthImageArray[i].enabled = false;
                    }
                }
            }

            void HotBArProgramGUI()
            {

            }

        void LevelNameGUI()
        {
            levelTextField.text = levelString;//Set levelString as level name
        }

        }

    
}
