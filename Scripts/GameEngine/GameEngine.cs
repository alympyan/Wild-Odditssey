using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class GameEngine : MonoBehaviour
    {
        [Header("Vars To Save And Feed")]
        [Tooltip("GameEninge Health")]
        [SerializeField] public float attaCurrentHealthGE;
        [Tooltip("GameEninge Health")]
        [SerializeField] public float attaMaxHealthGE;
        [SerializeField] public float moneyGE;
        [Header("Objects DONT DESTROY")] ///THESE ARE NOT GAMEOBJECTS TO NOT DESTORY ---THAT IS DONE IN AWAKE WITH NEW GAMEO?BJECTS
        [SerializeField] GameObject attPlayer;///SAVE
        [SerializeField] PlayerMove playerMove;///SAVE 
        [SerializeField] GameObject gameEngine; ///SAVE
        [SerializeField] GameObject guiCanvas; ///KEEP GUI - SAVE AND LOAD GUI
        [SerializeField] Canvas guiCanvasObj;
        [SerializeField] bool playerLoaded;

        [Header("Main Lvel Complete Bool")]
        [SerializeField] public bool orchardUnlocked;
        [SerializeField] public bool carnevileUnlocked;

        [Header("Scripts")]
        [SerializeField] AttaHealth attaHealth; ///SCRIPT TO SEND HEALTH TO -- OPTIONJ 2 ATTAHEALTH PULLS AND SENDS TO SAVEMASTER
        [SerializeField] GUIUpdater guiUpdater;///SAVE

        private void Awake()///DETECT AND DESTROY EXTRA GE ATTA OBJ
        {
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("GameEngine");
            GameObject[] attObj = GameObject.FindGameObjectsWithTag("Player");
            GameObject[] guiBottom = GameObject.FindGameObjectsWithTag("GUIBottom");
            //Instantiate(guiCanvasObj, transform.position, transform.rotation);

            if(gameObject.Length > 1)
            {
                Destroy(gameObject[1]);
                playerLoaded = true;
            }
            if (attObj.Length > 1)
            {
                Destroy(attObj[1]);
            }
            if (guiBottom.Length > 1)
            {
                Destroy(guiBottom[1]);
            }

            if (playerLoaded == false)
            {
                Instantiate(attPlayer, transform.position, transform.localRotation);
                playerLoaded = true;
            }
            playerMove = FindObjectOfType<PlayerMove>();///MUST GO LAST TO LOAD ALL DATA FROM PREVIOUS DATA
            guiUpdater = FindObjectOfType<GUIUpdater>();
        }


        // Start is called before the first frame update
        void Start()///DDOL
        {
            DontDestroyOnLoad(playerMove.gameObject);
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(guiCanvasObj);///GUICANVAS IS OBJECT TO SAVE ///GUIUPDATER IS SCRIPT ON GAMEENGINE
           
        }

        // Update is called once per frame
        void Update()
        {
            guiCanvasObj = FindObjectOfType<Canvas>();
            guiCanvasObj.enabled = true;
            guiUpdater = FindObjectOfType<GUIUpdater>();
        }
    }
}
