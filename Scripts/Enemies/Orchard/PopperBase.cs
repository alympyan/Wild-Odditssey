using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AwesomsseyEngine
{
    public class PopperBase : MonoBehaviour
    {
        [Header("Comp")]
        [SerializeField] BoxCollider2D popBox;
        [SerializeField] AudioSource popAudio;
        [SerializeField] Rigidbody2D popRig;
        [SerializeField] SpriteRenderer popSR;
        [SerializeField] Animator popAnim;
        [SerializeField] ParticleSystem popPart;
        [SerializeField] SpawnItems spawnItem;

        [Header("FLIPPING")]
        [SerializeField] bool flipRight;

        [Header("Bools")]
        [SerializeField] bool detectRayHitSomething;
        [SerializeField] public bool canBeHit;
        [SerializeField] public bool flickerOn;
        [SerializeField] bool shootMode;
        [SerializeField] bool deathState;
       
        [SerializeField] public bool detectPlayerState;
        [SerializeField] bool isShooting;
        [SerializeField] bool partIsPlaying;
        [SerializeField] bool partPlayed;

        [Header("Floats and Vectors")]
        [SerializeField] float seedSpeed;
        [SerializeField] float seedShotTimer;
        [SerializeField] RaycastHit2D detectRay;
        [SerializeField] Vector3 rayOffsetX;
        [SerializeField] Vector2 rayDir;
     
        [SerializeField] public float popHealth;
     
        [SerializeField] float timerForShooting;
        [SerializeField] float ogShootTimer;
        [Header("GameObj")]
        [SerializeField] GameObject spawnObj;
        [SerializeField] GameObject spawnedGrass;
        



        // Start is called before the first frame update
        void Start()
        {
            popAudio = GetComponent<AudioSource>();
            popSR = GetComponent<SpriteRenderer>();
            popAnim = GetComponent<Animator>();
            popPart = GetComponent<ParticleSystem>();
            popBox = GetComponent<BoxCollider2D>();
            popRig = GetComponent<Rigidbody2D>();
            spawnItem = GetComponent<SpawnItems>();
            ogShootTimer = timerForShooting;

        }

        // Update is called once per frame
        void Update()
        {
            if (flipRight == false) ///FACE LEFT
            {
                transform.right = -transform.right;
                rayOffsetX = new Vector2(-.5f, 0);
                rayDir = new Vector2(-1, 0);
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            if (flipRight == true) ///Face Right
            {
                transform.right = transform.right;
                rayOffsetX = new Vector2(.5f, 0);
                rayDir = new Vector2(1, 0);
                transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            
            if(detectPlayerState == false)///FORCES DETECTION OFF
            {
                partPlayed = false;
                partIsPlaying = false;
                
            }

            //detectRay = Physics2D.Raycast(this.transform.position  , rayDir, 3f); ///LAYER MASK 6 = Player
            //Debug.DrawRay(this.transform.position , rayDir * 3f, Color.yellow);
            //print("Popper is Update RAY = " + detectRay[0].collider.tag + ","+ detectRay[1].collider.tag);
            print("Popper is Update RAY ");
            print("Popper Ray is For LOOPING = " + detectRay.collider);


         

            if(detectPlayerState == false)///RESET ALL SETTINGS ONE PLAYER NOT DETECTED
            {
                popBox.enabled = false;
                timerForShooting = ogShootTimer; ///RESET SHOOTER TIMER
            }

            if(detectPlayerState == true)
            {
                popBox.enabled = true;
            }

            if(detectPlayerState == true && shootMode == false)
            {
                timerForShooting -= Time.deltaTime;
            }
        
            if(timerForShooting <0  && shootMode == false && isShooting == false)
            {
                shootMode = true;
                timerForShooting = ogShootTimer;
            }

            if(shootMode == false && timerForShooting <0)
            {
                timerForShooting = ogShootTimer;
            }


            ///DEATH CHECK
            if (popHealth <= 0)///DISABLE AND PLAY DEATH ANIM
            {
                shootMode = false;
                deathState = true;
                spawnItem.spawningMode = true;///SPAWN ITEM
                popBox.enabled = false;
                popRig.isKinematic = true;
                popAnim.SetBool("Death", true);

            }
        }

        private void FixedUpdate()
        {
            if(shootMode == true && isShooting == false) ///START SHOOTING
            {
                StartCoroutine(ShootPelletMode());
                
            }
        }


    

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if(collision.tag == "Player")
            {

                detectPlayerState = true;

            }

          
        }


        private void OnTriggerStay2D(Collider2D collision)
        {


            if (deathState == false)///ENSURE DEATH STATE IS FALSE
            {
                if (collision.tag == "Player") ///DETECTION FOR PLAYER NOT COLLISION
                {
                    //detectPlayerState = false;///RESET DETECTION
                    print("Popper Ray is PLAYER!!!");
                    popAnim.SetBool("Popup", true);
                    detectPlayerState = true;
                    if (partIsPlaying == false && partPlayed == false)
                    {
                        print("Popper col playing Grass");
                        StartCoroutine(PlayGrass());
                        detectRayHitSomething = true;
                        ///Continues Execution 
                        ///Reurn stops execution of CODE
                    }

                    if (flickerOn == true)
                    {
                        canBeHit = false;
                    }


                    if (flickerOn == false)
                    {
                        canBeHit = true;
                    }


                }
            }///END OF LOOP

        }

        private void OnTriggerExit2D(Collider2D collision)///RESET DETECTION
        {
            if (collision.tag == "Player")
            {
                partPlayed = false;
                print("Popper col exit Player");
                    detectRayHitSomething = false;
                    partPlayed = false;
                partIsPlaying = false;
                shootMode = false;
                    popAnim.SetBool("Popup", false);
                    canBeHit = false;
                detectPlayerState = false;///FORCES OFF DETECT
                
            }
        }


        public IEnumerator FlickerMe()
        {
            Color ogColor = popSR.color;
            popSR.color = Color.green;
            canBeHit = false;
            flickerOn = true;
            print("Popper flicker stuck");
            yield return new WaitForSeconds(.5f);
            popSR.color = Color.white;
            canBeHit = true;
            flickerOn = false;///STOPS LOOP FROM SETTING HIT TO TRUE
        }


        IEnumerator PlayGrass()
        {
            partIsPlaying = true;
            popPart.enableEmission = true;
            popPart.Play();
            yield return new WaitForSeconds(.5f);
            popPart.Stop();
            partIsPlaying = true;
            partPlayed = true;
        }

        IEnumerator ShootPelletMode()///PROJECTILE SPAWN
        {
            isShooting = true;
            popAnim.SetBool("Shoot", true);
            spawnedGrass = Instantiate(spawnObj, this.transform.position + new Vector3(rayDir.x,0), transform.rotation);
            Rigidbody2D grassRig = spawnedGrass.GetComponent<Rigidbody2D>();
            grassRig.AddForce(rayDir * seedSpeed * Time.deltaTime,ForceMode2D.Impulse);
            yield return new WaitForSeconds(.5f);
            isShooting = false;
            shootMode = false;
            popAnim.SetBool("Shoot", false);

        }    

        void Death()
        {
            Destroy(gameObject);
        }
    }

}