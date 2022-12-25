using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// CLASS CONTROLS APPY 1 LEVEL CONTEXT 
    /// CLASS FOR THROWING OBJECTS
    /// AT END OF LEVEL REMOVE SRIPT
    /// ENSURE SAVE LOAD SYSTEM WORKS
    /// </summary>
    public class ContexButtons : MonoBehaviour
    {
        [Header("LEVEL Context")]
        [SerializeField] bool appy;
        
        [Header("Options")]
        [SerializeField] GameObject appleThrow;
        [SerializeField] float appleSpeed;
        [SerializeField] Animator attaAnim;
        [SerializeField] GameObject spawnedObj;
        [SerializeField] GameObject throwGold;
        [SerializeField] public bool throwingState;
        [SerializeField] public float appleQuant;

        [SerializeField] public bool grabbedFirstApple;
        [SerializeField] public bool goldAppleEnabled;

        [Header("Scripts")]
        [SerializeField] AttaItemDsp itemDsp;
        [SerializeField] PlayerPickup playerPickup;
        [SerializeField] LevelGuide levelGuide;
        [SerializeField] PlayerMove playerMove;
        ///FUTURE LEVELMAP SCRIPT - FEEEDS BOOL STATES
        ///SEPERATE CONTEXTBUTTONS SCRIPTS 
        // Start is called before the first frame update
        void Start()
        {
            attaAnim = GetComponent<Animator>();
            playerPickup = FindObjectOfType<PlayerPickup>();
            itemDsp = FindObjectOfType<AttaItemDsp>();
            playerMove = FindObjectOfType<PlayerMove>();
            levelGuide = FindObjectOfType<LevelGuide>();


            if (levelGuide.orchardLand == true)
            {
                this.enabled = true;
            }

            if (levelGuide.orchardLand == false)
            {
                this.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {


            if (appy == true)///APPY LEVEL CONTEXT -CHANGE FOR DIFFERENT LANDS
            {

                if (Input.GetButtonDown("Throw") == true && playerPickup.appleNumbers > 0 && throwingState == false && playerMove.slideState == false && Input.GetAxis("Vertical") > -.1) ///ensure Not Sliding && Input.GetAxis("Vertical") >= 0
                {
                    throwingState = true;

                }
            }
            
            

        }


        private void FixedUpdate()
        {
            if (throwingState == true)///APPY
            {
                Throw(appleThrow, appleSpeed);///APPLEOBJECT AND SPEED
                playerPickup.appleNumbers -= 1f;
            }
        }
        /// <summary>
        /// REMOVE APPLES AT END OF LEVEL
        /// </summary>

        void Throw(GameObject throwObj, float speed)///THROW APPLE
        {
            throwingState = false;
            attaAnim.SetBool("Tail", true);
            itemDsp.itemDspSR.sprite = null;///Disable ItemDisplay  
         
            if(goldAppleEnabled == false)
            {
                print("appal");
                spawnedObj = Instantiate(throwObj, transform.position + transform.right, transform.rotation);
            }
            if (goldAppleEnabled == true)///SEcond otherwise turns off
            {
                print("gold");
                spawnedObj = Instantiate(throwObj, transform.position + transform.right, transform.rotation);
                ApplesInOrchard appleScriptGold = spawnedObj.GetComponent<ApplesInOrchard>();///GET APPLE SCRIPT
                appleScriptGold.goldenApple = true;
                goldAppleEnabled = false;
            }

            //spawnedObj = Instantiate(throwObj, transform.position + transform.right, transform.rotation);
            ApplesInOrchard appleScript = spawnedObj.GetComponent<ApplesInOrchard>();///GET APPLE SCRIPT
            appleScript.pieckedUp = true;///SET PICKED UP TO TRUE SO ROTTEN ON PLATFORM HIT
            
            Rigidbody2D spawnRig = spawnedObj.GetComponent<Rigidbody2D>();
            spawnedObj.tag = ("Player");///SET TAG AS PLAYER - LETS REX EAT
            spawnRig.isKinematic = false;
            spawnRig.constraints = RigidbodyConstraints2D.FreezeRotation;
            BoxCollider2D spawnBox = spawnedObj.GetComponent<BoxCollider2D>();
            spawnBox.isTrigger = false;
            spawnedObj.tag = ("Player");
          
            appleQuant -= 1f;///REMOVE APPLE Count
            spawnRig.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);
        }

        void ResetThrowAnim()
        {
            attaAnim.SetBool("Throw", false);
        }
    }

}