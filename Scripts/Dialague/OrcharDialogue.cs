using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class OrcharDialogue : MonoBehaviour
    {
        [SerializeField] Image backImage;
        [SerializeField] TMP_Text myText;
        [SerializeField] TMP_Text fieldPro;
        [SerializeField] Canvas myCanvas;
        [SerializeField] bool buttonPressed;
        [SerializeField] public bool grabbedApple;
        [SerializeField] bool playerHere;
        [SerializeField] bool playerTalkedFirst;
        [SerializeField] bool part1;
        [SerializeField] bool part2;
        [SerializeField] bool part3;
        [SerializeField] bool part4;
        [SerializeField] bool part5;
        [SerializeField] string part1String;
        [SerializeField] string part2String;
        [SerializeField] string part3String;
        [SerializeField] string part4String;
        [SerializeField] string part5String;
        [SerializeField] PuzzleMan wallPuzzle;
        [SerializeField] PlayerPickup playerPickup;
        [SerializeField] RexBase rexBase;

        // Start is called before the first frame update
        void Start()
        {
            rexBase = FindObjectOfType<RexBase>();

        }

        // Update is called once per frame
        void Update()
        {
            if (playerTalkedFirst == true)
            {
                wallPuzzle.wallDownMode = true;
            }


            if (playerHere == true)
            {
                if (Input.GetButtonDown("Throw") && part1 && buttonPressed == false)
                {
                    part1 = false;
                    part2 = true;
                    buttonPressed = true;
                    myText.text = part2String;
                }
                if (Input.GetButtonDown("Throw") && part2 && buttonPressed == false)
                {
                    print("dial part3 should be set");
                    part2 = false;
                    part3 = true;
                    buttonPressed = true;
                    
                    myText.text = part3String;
                }
                if(part4 == true)
                {
                    part3 = false;
                    //buttonPressed = true;
                    part4 = true;
                    myText.text = part4String;
                }
             
                if (Input.GetButtonDown("Throw") && part4 && grabbedApple == true && buttonPressed == false)
                {
                    buttonPressed = true;
                    part4 = false;
                    part5 = true;
                    rexBase.rexStart = true;
                    rexBase.SetPosition();
                    myText.text = part5String;
                }

                if (Input.GetButtonUp("Throw"))
                {
                    buttonPressed = false;
                }

               
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                playerHere = true;
                playerTalkedFirst = true;
                myCanvas.enabled = true;
                playerPickup = collision.GetComponent<PlayerPickup>();
                if(playerPickup.appleFirstPiecked == true)
                {
                    grabbedApple = true;
                }
                if(grabbedApple == false)
                {
                    myText.text = part1String;
                    part1 = true;
                }
                if(grabbedApple == true)
                {
                    part4 = true;
                    myText.text = part4String;
                }

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                playerHere = false;
                myCanvas.enabled = false;
                myText.text = part1String;
                part1 = false;
                part2 = false;
                part3 = false;
                part4 = false;
                part5 = false;
                part1 = false;
            }
        }
    }
}
