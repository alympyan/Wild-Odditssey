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
        [SerializeField] ParticleSystem[] rexPart;
        [SerializeField] OrcharDialogue orchar;
        [Header("Opptions")]
        [SerializeField] float walkSpeed;
        [SerializeField] float rexHealth; ///Feed Apples to Reduce to Zero
        [SerializeField] bool rexCameraShaked;
        [SerializeField] bool audioStompPlaying;
        [SerializeField] public bool rexStart;
        [SerializeField] bool rexHasStarted;
        [SerializeField] public bool rexDead;
        [SerializeField] RaycastHit2D groundRay;
        [SerializeField] bool groundedRex;
        [Header("WayPoints")]
        [SerializeField] GameObject wayA;
        [SerializeField] GameObject wayB;
        [SerializeField] GameObject wayC;
        [SerializeField] GameObject wayD;
        [SerializeField] GameObject wayE;
        [SerializeField] GameObject wayF;
        [SerializeField] public bool wayAbool;
        [SerializeField] public bool wayBbool;
        [SerializeField] public bool wayCbool;
        [SerializeField] public bool wayDbool;
        [SerializeField] public bool wayEbool;
        [SerializeField] public bool wayFbool;


        // Start is called before the first frame update
        void Start()
        {
            rexRig = GetComponent<Rigidbody2D>();
            rexAnim = GetComponent<Animator>();
            rexAudio = GetComponent<AudioSource>();
            rexSR = GetComponent<SpriteRenderer>();
            orchar = FindObjectOfType<OrcharDialogue>();
            moutSR = GetComponentsInChildren<SpriteRenderer>();
            rexPart = GetComponentsInChildren<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
         if(rexCameraShaked == false)///Shake Camera On Spawn
            {

            }

            //transform.position = Vector3.MoveTowards(transform.position, Vector3.right, Time.deltaTime * walkSpeed);
            if (rexDead == false && rexStart == true)///MOVE CODE
            {
                StartCoroutine(RexStompAudio());
                if (wayAbool == true)
                {
                    //transform.Translate(transform.right * Time.deltaTime * walkSpeed);
                   transform.position= Vector2.MoveTowards(transform.position, wayA.transform.position, walkSpeed * Time.deltaTime);
                }
                if (wayBbool == true)
                {
                    wayAbool = false;
                    //transform.Translate(transform.right * Time.deltaTime * walkSpeed);
                   transform.position = Vector2.MoveTowards(transform.position, wayB.transform.position, walkSpeed * Time.deltaTime);
                }
                if (wayCbool == true)
                {
                    wayBbool = false;
                    //transform.Translate(transform.right * Time.deltaTime * walkSpeed);
                    transform.position = Vector2.MoveTowards(transform.position, wayC.transform.position, walkSpeed * Time.deltaTime);
                }
                if (wayDbool == true)
                {
                    wayCbool = false;
                    //transform.Translate(transform.right * Time.deltaTime * walkSpeed);
                    transform.position = Vector2.MoveTowards(transform.position, wayD.transform.position, walkSpeed * Time.deltaTime);
                }
                if (wayEbool == true)
                {
                    wayDbool = false;
                    //transform.Translate(transform.right * Time.deltaTime * walkSpeed);
                    transform.position = Vector2.MoveTowards(transform.position, wayE.transform.position, walkSpeed * Time.deltaTime);
                }
                if (wayFbool == true)
                {
                    wayEbool = false;
                    //transform.Translate(transform.right * Time.deltaTime * walkSpeed);
                    transform.position = Vector2.MoveTowards(transform.position, wayF.transform.position, walkSpeed * Time.deltaTime);
                }

            }


            ///HEALTH
            if (rexHealth <= 0)
            {
                rexDead = true;
                print("Rex has died");
                ///AUDIO AND VFX

            }
           
            //groundRay = Physics2D.Raycast(transform.position + new Vector3(0, -1.9f), Vector2.down, 2f);
            Debug.DrawRay(transform.position + new Vector3(0, -1.9f), Vector2.down * 2f, Color.blue, .01f);
            //if (groundRay.collider == null)
           // {
               // print("Rex ground is colliding NULL += ");
                //groundedRex = false;
           // }
           if (groundRay.collider != null)
            {
                print("Rex ground is firing");
                print("Rex ground is colliding += " + groundRay.collider.gameObject.layer);
                if (groundRay.collider.tag == ("Platforms") || groundRay.collider.gameObject.layer == 10)///10 = Platform
                {
                    print("Rex is PLATFROMS = " + groundRay.collider.gameObject.layer);
                    groundedRex = true;
                }
                if (groundRay.collider.gameObject.layer != 10 )
                {
                    groundedRex = false;
                }

               
            }

            if (groundedRex == false)
            {
                rexPart[0].enableEmission = true;
            }
            if (groundedRex == true)
            {
                rexPart[0].enableEmission = false;
            }

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.name.Contains("Apple"))///NAME CONTAINS BECause Tags are set to player
            {
                ApplesInOrchard applesOrchard = collision.GetComponent<ApplesInOrchard>();
                if (applesOrchard.pieckedUp == true)///ENSURE APPLE ISNT ON GROUND
                {
                    print("Rex has been hit");
                    if(applesOrchard.goldenApple == true)
                    {
                        rexHealth -= 7;
                    }
                    if (applesOrchard.goldenApple == false)
                    {
                        rexHealth -= 1f;
                    }
                 
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

        }

        public void SetPosition()
        {
            if (rexHasStarted == false)
            {
                rexHasStarted = true;
               
                transform.position = new Vector3(-0.01f, 1.76f);
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