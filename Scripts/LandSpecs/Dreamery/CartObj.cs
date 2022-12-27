using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class CartObj : MonoBehaviour
    {
        /// <summary>
        /// CArt to Dreamery To PlayerPickup to AttaDsp to Oddit Warp
        /// </summary>

        [SerializeField] public bool orcahrd;
        [SerializeField] public bool carnevil;
        [SerializeField] public string sceneCart;
        [SerializeField] public bool playerHasMe;
        [SerializeField] public bool insertedInM;
        [SerializeField] TMP_Text[] myTextField;
        [SerializeField] bool inputUp;
        [SerializeField] bool playerOnMe;
        [SerializeField] PlayerPickup playerPick;
        [SerializeField] public bool touchingDream;
        [SerializeField] DreameryM dream;



        // Start is called before the first frame update
        void Start()
        {
            playerPick = FindObjectOfType<PlayerPickup>();
            myTextField = GetComponentsInChildren<TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);

            if(playerOnMe == false)
            {
                myTextField[0].enabled = false;
                myTextField[0].rectTransform.rotation = new Quaternion(0, 0, 0, 0);
            }


            if(playerOnMe == true)///Ensure The Playe IS OKver Cart
            {
                myTextField[0].enabled = true;
                myTextField[0].rectTransform.rotation = new Quaternion(0, 0, 0, 0);
                if (Input.GetButtonDown("Throw") && playerHasMe == false && playerPick.hasCart == false && inputUp == true)///Pick Up Cart
                {
                    print("cart pick");
                    this.gameObject.transform.SetParent(playerPick.transform);
                    this.transform.localPosition = new Vector2(0, 1);
                    playerHasMe = true;///Bool only Accessed by Dreammery
                    playerPick.hasCart = true;
                    playerOnMe = false;
                    inputUp = false;
                    if (touchingDream == true)
                    {
                        dream.cartInserted = false;
                    }
                }

             


            }



            if (playerHasMe == true)
            {
                if (Input.GetButtonDown("Throw") && playerHasMe == true && playerPick.hasCart == true && touchingDream == false && inputUp == true)///Drop Cart
                {
                    print("cart drop");
                    this.gameObject.transform.SetParent(null);
                    playerHasMe = false;///Bool only Accessed by Dreammery
                    playerPick.hasCart = false;

                }
                if (Input.GetButtonDown("Throw") && playerHasMe == true && playerPick.hasCart == true && touchingDream == true && inputUp == true && dream.cartInserted == false)///Insert Cart
                {
                    print("cart insert");
                    this.gameObject.transform.SetParent(dream.transform);
                    this.transform.localPosition = dream.cartPos;
                    dream.cartInserted = true;
                    playerHasMe = false;///Bool only Accessed by Dreammery
                    playerPick.hasCart = false;
                }
            }


            if(Input.GetButtonUp("Throw") )///Ensure Toggle
            {
                inputUp = true;
            }





       
                
              
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Player" && playerHasMe == false)///Ensure Player Isnt Tocuhing While Holding
            {
                playerOnMe = true;
            }
            if (collision.tag == "DreamMachine")
            {
                print("cart dream");
                touchingDream = true;
                dream = collision.GetComponent<DreameryM>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                playerOnMe = false;
            }
            if (collision.tag == "DreamMachine")
            {
                touchingDream = false;
            }
        }
    }
}
