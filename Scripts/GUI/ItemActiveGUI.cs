using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UIElements;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class ItemActiveGUI : MonoBehaviour
    {
        /// <summary>
        /// Class controls Active Item in GUI
        /// </summary>
        /// 

        [Header("Images")]
        [SerializeField] Image activeImage;
        [SerializeField] Sprite emptyBottle;

        [Header("YellowSand")]
        [SerializeField] Sprite yellowFull;
        [Header("BlueSand")]
        [SerializeField] Sprite blueFull;
        [SerializeField] Sprite blueHalf;
        [Header("RedSand")]
        [SerializeField] Sprite redFull;
        [SerializeField] Sprite redOne;
        [SerializeField] Sprite redTwo;
        [Header("GreenSand")]
        [SerializeField] Sprite greenFull;
        [SerializeField] Sprite greenOne;
        [SerializeField] Sprite greenTwo;
        [SerializeField] Sprite greenThree;
        [Header("BowSand")]
        [SerializeField] Sprite bowFull;
        [SerializeField] Sprite bowOne;
        [SerializeField] Sprite bowTwo;
        [SerializeField] Sprite bowThree;
        [SerializeField] Sprite bowFour;

        [Header("VARS")]
        [SerializeField] public float luckyJumpCountGUI;

        [Header("Scripts")]
        [SerializeField] LuckyJump attaJumpGUI;


        // Start is called before the first frame update
        void Start()
        {
            attaJumpGUI = FindObjectOfType<LuckyJump>();///FIND LUCKYJUMP
        }

        // Update is called once per frame
        void Update()
        {
            luckyJumpCountGUI = attaJumpGUI.luckJCount;
            if(luckyJumpCountGUI == 0)
            {
                activeImage.sprite = emptyBottle;
            }
            if(attaJumpGUI.yellowJump == true && luckyJumpCountGUI == 1)
            {
                activeImage.sprite = yellowFull;
            }
            ///Blue Sand
            if (attaJumpGUI.blueJump == true && luckyJumpCountGUI == 2)
            {
                activeImage.sprite = blueFull;
            }
            if (attaJumpGUI.blueJump == true && luckyJumpCountGUI == 1)
            {
                activeImage.sprite = blueHalf;
            }
            ///Red Sand
            if (attaJumpGUI.redJump == true && luckyJumpCountGUI == 3)
            {
                activeImage.sprite = redFull;
            }
            if (attaJumpGUI.redJump == true && luckyJumpCountGUI == 2)
            {
                activeImage.sprite = redOne;
            }
            if (attaJumpGUI.redJump == true && luckyJumpCountGUI == 1)
            {
                activeImage.sprite = redTwo;
            }
            ///Green SAND
            if (attaJumpGUI.greenJump == true && luckyJumpCountGUI == 4)
            {
                activeImage.sprite = greenFull;
            }
            if (attaJumpGUI.greenJump == true && luckyJumpCountGUI == 3)
            {
                activeImage.sprite = greenOne;
            }
            if (attaJumpGUI.greenJump == true && luckyJumpCountGUI == 2)
            {
                activeImage.sprite = greenTwo;
            }
            if (attaJumpGUI.greenJump == true && luckyJumpCountGUI == 1)
            {
                activeImage.sprite = greenThree;
            }
            ///BOW SAND
            if (attaJumpGUI.bowJump == true && luckyJumpCountGUI == 5)
            {
                activeImage.sprite = bowFull ;
            }
            if (attaJumpGUI.bowJump == true && luckyJumpCountGUI == 4)
            {
                activeImage.sprite = bowOne;
            }
            if (attaJumpGUI.bowJump == true && luckyJumpCountGUI == 3)
            {
                activeImage.sprite = bowTwo;
            }
            if (attaJumpGUI.bowJump == true && luckyJumpCountGUI == 2)
            {
                activeImage.sprite = bowThree;
            }
            if (attaJumpGUI.bowJump == true && luckyJumpCountGUI == 1)
            {
                activeImage.sprite = bowFour;
            }
        }
    }

}