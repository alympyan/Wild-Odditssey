using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// Class Controls LevelSettings for Lands
    /// Manually Set Pixel Camera!!
    /// </summary>

    public class LevelGuide : MonoBehaviour
    {
        [SerializeField] GameObject attaPlayer;
        [SerializeField] PlayerMove playerMove;
        [SerializeField] Vector3 playerStartPos;
        [SerializeField] Vector3 cameraOffSetLevel;
        [SerializeField] Camera pixelCamera;///MANUALLY SET EACH LAND
        [SerializeField] CameraFollow cameraFollow;
        [SerializeField] TMP_Text levelNameField;
        [SerializeField] string levelString;
        [SerializeField] LevelName leveName;
        [SerializeField] bool levelComplete;
        [SerializeField] bool levelCompleteFirstTime;///USe to Check if Level is Completed Once
        [SerializeField] string contextButtonName;
        [SerializeField] CinemachineVirtualCamera myCM;

        [Header("Land Scripts")]
        
        [SerializeField] ContexButtons contexButtons;

        [Header("Level Bools")] ///FEED TO RESPECTIVE SCRIPTS
        [SerializeField] public bool orchardLand;
     
        


        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            playerMove.transform.position = playerStartPos;
            //myCM = FindObjectOfType<CinemachineVirtualCamera>();
            //cameraFollow = myCM.GetComponent<CameraFollow>();
            cameraFollow = pixelCamera.GetComponent<CameraFollow>();
            cameraFollow.levelOffSet = cameraOffSetLevel;///SET LEVEL CAMERA OFFSET
            leveName = GetComponent<LevelName>();
            levelString = leveName.levelName;
            attaPlayer = playerMove.gameObject;
            
            ///FIND ALL LAND SCRIPTS
            contexButtons = FindObjectOfType<ContexButtons>();


            ///SETUP LANDSCRIPTS ON PLAYER TO TRUE AND FALSE WHEN LOADING NEW LAND
            if (orchardLand == true)
            {
                
                contexButtons.enabled = true;
            }
            if (orchardLand == false)
            {
               
                contexButtons.enabled = false;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (levelComplete == true)
            {
                //Component levelComp = attaPlayer.GetComponent(Type.GetType(contextButtonName));
                //Destroy(attaPlayer.GetComponent(contextButtonName));
                if(orchardLand == true)///DISABLE LAND SCRIPTS
                {
                    contexButtons.enabled = false;
                }
            
            }
        }
    }
}
