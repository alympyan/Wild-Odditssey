using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// CLASS CONTROLS APPY 1 LEVEL CONTEXT
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
        [SerializeField] public bool throwingState;

        [Header("Scripts")]
        [SerializeField] AttaItemDsp itemDsp;
        [SerializeField] PlayerPickup playerPickup;
        ///FUTURE LEVELMAP SCRIPT - FEEEDS BOOL STATES
        ///SEPERATE CONTEXTBUTTONS SCRIPTS 
        // Start is called before the first frame update
        void Start()
        {
            attaAnim = GetComponent<Animator>();
            playerPickup = FindObjectOfType<PlayerPickup>();
            itemDsp = FindObjectOfType<AttaItemDsp>();
        }

        // Update is called once per frame
        void Update()
        {
            if (appy == true)///APPY LEVEL CONTEXT
            {

                if (Input.GetButtonDown("Throw") == true && playerPickup.appleNumbers > 0 && throwingState == false && Input.GetAxis("Vertical") >= 0) ///ensure Not Sliding
                {
                    throwingState = true;

                }
            }
     

        }


        private void FixedUpdate()
        {
            if (throwingState == true)
            {
                Throw(appleThrow, appleSpeed);
                playerPickup.appleNumbers -= 1f;
            }
        }
        /// <summary>
        /// REMOVE APPLES AT END OF LEVEL
        /// </summary>

        void Throw(GameObject throwObj, float speed)
        {
            throwingState = false;
            attaAnim.SetBool("Tail", true);
            itemDsp.itemDspSR.sprite = null;
            spawnedObj = Instantiate(throwObj, transform.position + transform.right, transform.rotation);
            Rigidbody2D spawnRig = spawnedObj.GetComponent<Rigidbody2D>();
            spawnedObj.tag = ("Player");
            spawnRig.isKinematic = false;
            spawnRig.constraints = RigidbodyConstraints2D.FreezeRotation;
            BoxCollider2D spawnBox = spawnedObj.GetComponent<BoxCollider2D>();
            spawnBox.isTrigger = false;
            spawnedObj.tag = ("Player");
            spawnRig.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);
        }

        void ResetThrowAnim()
        {
            attaAnim.SetBool("Throw", false);
        }
    }

}