using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// Class Controls Atta's Collisions 
    /// </summary>
    public class AttaCollisions : MonoBehaviour
    {
        [Header("COmp")]
        [SerializeField] Rigidbody2D attaRig;
        [SerializeField] SpriteRenderer attaSR;
        [SerializeField] AudioSource attaAudio;
        [SerializeField] BoxCollider2D attaBox;
        [SerializeField] CapsuleCollider2D attaCap;

        [Header("Options")]
        [SerializeField] float flickerTime;
        [SerializeField] public bool invulState;
        [SerializeField] public bool hitState;


        // Start is called before the first frame update
        void Start()
        {
            attaRig = GetComponent<Rigidbody2D>();
            attaSR = GetComponent<SpriteRenderer>();
            attaAudio = GetComponent<AudioSource>();
            attaBox = GetComponent<BoxCollider2D>();
            attaCap = GetComponent<CapsuleCollider2D>();
            if(flickerTime == 0)///CATCH ALL FOR SETTINGS
            {
                flickerTime = .5f;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if(hitState == true && invulState == false)///ALWYAS SEND HIT STATE FROM ENEMY LET ATTA CONTROL ITS COROUTINE
            {
                StartCoroutine(FlickerAtta());
            }
        }


        public IEnumerator FlickerAtta()
        {
           
            ///ENSURE ENEMY CHECKS FOR INVUL STATE AND DISABLES STAY TRIGGERS AFTER STARTED
                attaSR.color = Color.red;
                invulState = true;
                print("atta flicker hasn't hit return");
                yield return new WaitForSeconds(flickerTime);
                print("atta flicker is past return");
                attaSR.color = Color.white;
                invulState = false;
            hitState = false;
            

        }
    }
}
