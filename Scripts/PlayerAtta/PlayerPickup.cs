using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine

{
    public class PlayerPickup : MonoBehaviour
    {
        [Header("Stored Objs")]

        [SerializeField] Rigidbody2D attaRig;
        [SerializeField] public  float appleNumbers;
        [SerializeField] bool objPicked;
        [SerializeField] public bool appleFirstPiecked; ///For ORCHARD LEVEL SETS UP APPLE 
        [SerializeField] public bool hasCart;

        [Header("SCripts")]
        [SerializeField] AttaItemDsp itemDsp;
        [SerializeField] ContexButtons contexButtons;


        // Start is called before the first frame update
        void Start()
        {
            attaRig = GetComponent<Rigidbody2D>();
            itemDsp = FindObjectOfType<AttaItemDsp>();
            contexButtons = FindObjectOfType<ContexButtons>();///CHANGE TO LEVELMAP AND PICK BOOLS STATE FROM THERE - SAVE LOAD BOOLS
        }

        // Update is called once per frame
        void Update()
        {
            ///CODE FOR CHECKING LAND YOU ARE IN AND SETTING CONTEXT BUTTON FIND
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == ("Apple") && objPicked == false && contexButtons.throwingState == false && contexButtons.appleQuant == 0)///MAYBE CHANGE LATER FOR NEW SYSTEM
            {
                objPicked = true;///TRY TO STOP APPLE BEING PICKED TWICE
                appleFirstPiecked = true;
                ApplesInOrchard appleScript = collision.GetComponent<ApplesInOrchard>(); ///GET APPLE SCRIPT
                appleScript.pieckedUp = true;
                if(appleScript.goldenApple == false)
                {
                    itemDsp.itemDspSR.sprite = itemDsp.appleSprite;///ITEMDISPLAY IN PLAYER
                }
                if (appleScript.goldenApple == true)
                {
                    itemDsp.itemDspSR.sprite = itemDsp.appleGoldSprite;///ITEMDISPLAY IN PLAYER
                    contexButtons.goldAppleEnabled = true;
                }


                GameObject appleObj = collision.gameObject;
                SpriteRenderer appleSR = collision.GetComponent<SpriteRenderer>();
                //appleSR.enabled = false;
                //appleObj.transform.SetParent(this.transform);
                // appleObj.transform.localPosition = new Vector3(0, 1);
                // appleObj.gameObject.tag = ("Player");
                //Rigidbody2D appleRig = collision.gameObject.GetComponent<Rigidbody2D>();
                //appleRig.isKinematic = true;
                contexButtons.appleQuant += 1f;
                
                appleNumbers += 1f;
                ///FUTURE AUDIO AND VFX
                ///
                print("apple in Player Pickup ");
                Destroy(appleObj);

            }
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            objPicked = false;
        }
    }

}