using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class RexBase : MonoBehaviour
    {
        /// <summary>
        /// CLass Controls REX 1-1 Appy Orchard 
        /// </summary>
        /// 
        [Header("Comp")]
        [SerializeField] Rigidbody2D rexRig;
        [SerializeField] Animator rexAnim;
        [SerializeField] SpriteRenderer rexSR;
        [SerializeField] AudioSource rexAudio;
        [SerializeField] AudioClip roarClip;
        [SerializeField] AudioClip cryClip;
        [SerializeField] AudioClip roarTwoClip;
        [SerializeField] SpriteRenderer[] moutSR;
        [Header("Opptions")]
        [SerializeField] float walkSpeed;
        [SerializeField] float rexHealth; ///Feed Apples to Reduce to Zero
        [SerializeField] bool audioStompPlaying;
        [SerializeField] public bool rexStart;
        [SerializeField] public bool rexDead;
        
        // Start is called before the first frame update
        void Start()
        {
            rexRig = GetComponent<Rigidbody2D>();
            rexAnim = GetComponent<Animator>();
            rexAudio = GetComponent<AudioSource>();
            rexSR = GetComponent<SpriteRenderer>();
            moutSR = GetComponentsInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            //transform.position = Vector3.MoveTowards(transform.position, Vector3.right, Time.deltaTime * walkSpeed);
            if(rexDead == false)
            {
                transform.Translate(transform.right * Time.deltaTime * walkSpeed);
                StartCoroutine(RexStompAudio());
            }
            

            ///HEALTH
            if(rexHealth <= 0)
            {
                rexDead = true;
                print("Rex has died");
                ///AUDIO AND VFX
                
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.name.Contains("Apple"))///NAME CONTAINS BECause Tags are set to player
            {
                print("Rex has been hit");
                rexHealth -= 1f;
                Rigidbody2D appleRig = collision.GetComponent<Rigidbody2D>();
                appleRig.velocity = Vector2.zero;
                appleRig.constraints = RigidbodyConstraints2D.FreezeAll;
                GameObject appleObj = collision.gameObject;
                StartCoroutine(MouthEat());
                ///FUTURE ANIMATION Code
                ///FOR NOW KILL APPLE 
                Destroy(appleObj);
            }
        }

        IEnumerator RexStompAudio()
        {
            if (rexDead == false && audioStompPlaying == false)
            {
                print("Rex AudioIE");
                rexAudio.Play();
                audioStompPlaying = true;
                yield return new WaitForSeconds(3f);
                audioStompPlaying = false;
              
            }

        }

        IEnumerator MouthEat() ///1 = Roar 2 = Eat
        {
            moutSR[2].enabled = true;
            yield return new WaitForSeconds(.5f);
            moutSR[2].enabled = false; ;

        }
    }

}