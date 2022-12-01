using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class AppitEnemy : MonoBehaviour
    {
        /// <summary>
        /// Class Controls APPIts
        /// </summary>
        /// 

        [Header("Comp")]
        [SerializeField] Animator appitanim;
        [SerializeField] AudioSource appitAudio;
        [SerializeField] CapsuleCollider2D appitCap;
        [SerializeField] BoxCollider2D appitBox;
        [SerializeField] Rigidbody2D appitRig;
        [SerializeField] SpriteRenderer appitSR;
        [SerializeField] SpawnItems spawnItem;
        [SerializeField] PlayerMove playerMove;

        [Header("Options")]
        [SerializeField] float fallTimer;
        [SerializeField] float rollTimer;
        [SerializeField] bool idleState;
        [SerializeField] bool fallPrep;
        [SerializeField] bool fallingState;
        [SerializeField] bool rollingState;
        [SerializeField] bool deadState;
        [SerializeField] bool canBeHit;
        [SerializeField] float dmgToPlayer;
        [SerializeField] float moveSpeed;
        [SerializeField] float lifeTimer;
        [SerializeField] Vector2 playerPosXVector;
        [SerializeField] Vector3 playerCurrentPos;
        [SerializeField] bool playerCalculated;
        [Header("Velc Control")]
        [SerializeField] float velocXMax;
        [SerializeField] float velcxCounter;

        // Start is called before the first frame update
        void Start()
        {
            appitanim = GetComponent<Animator>();
            appitAudio = GetComponent<AudioSource>();
            appitCap = GetComponent<CapsuleCollider2D>();
            appitRig = GetComponent<Rigidbody2D>();
            appitSR = GetComponent<SpriteRenderer>();
            spawnItem = GetComponent<SpawnItems>();

        }

        // Update is called once per frame
        void Update()
        {
            ///Veclocity Control
            velcxCounter = appitRig.velocity.x;
            if(appitRig.velocity.x > velocXMax)
            {
                appitRig.velocity = new Vector2(velocXMax, appitRig.velocity.y);
            }
            ///STATE COBTROLS
            if(idleState == true)
            {
                appitanim.SetBool("Idle", true);
            }

            if(fallPrep == true)///FALL PREP
            {
                appitanim.SetBool("Rumble", true);
                fallTimer -= Time.deltaTime;
                if(fallTimer <= 0)
                {
                    fallingState = true;
                }
                if(fallingState == true)
                {
                    appitanim.SetBool("Roll", true);
                    appitCap.enabled = true;
                    fallPrep = false;
                    idleState = false;
                    appitCap.isTrigger = false;
                    appitRig.constraints = RigidbodyConstraints2D.None;
                }
            }

            ///ROLLING STATE TIMER
            if(rollingState == true)
            {
                lifeTimer -= Time.deltaTime;
                if(lifeTimer <= 0 && deadState == false)
                {
                    appitanim.SetBool("Death", true);
                    appitSR.sortingLayerName = "Player";
                    appitSR.sortingOrder = 5;
                    appitRig.isKinematic = true;
                    appitRig.constraints = RigidbodyConstraints2D.FreezeAll;
                    appitCap.enabled = false;
                }
            }
        }

        private void FixedUpdate()
        {
            if(rollingState == true)///MOVE FROM HIT -- USE playerCurrentPos
            {
              
                print("appit playeX = " + playerPosXVector);
                appitRig.AddForce(playerCurrentPos * moveSpeed * Time.deltaTime,ForceMode2D.Impulse);///MUST SET NUMBER FOR FORCE
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "TailKiss" && canBeHit == true)///HIT COLLISIONS
            {
                AttaHealth playerHealth = collision.GetComponent<AttaHealth>();
                //playerHealth.currentPlayerHealth -= dmgToPlayer;
                ///FUTURE SOUND
                ///STOPP ALL RIGS
                appitRig.isKinematic = true;
                appitRig.constraints = RigidbodyConstraints2D.FreezeAll;
                appitCap.enabled = false;
                appitSR.sortingLayerName = "Player";
                appitSR.sortingOrder = 5;
                spawnItem.spawningMode = true;///SPAWN ITEM
                appitanim.SetBool("Death", true);
                
            }

            if (collision.tag == "PowerSeeds" && canBeHit == true)///HIT COLLISIONS
            {
                AttaHealth playerHealth = collision.GetComponent<AttaHealth>();
                //playerHealth.currentPlayerHealth -= dmgToPlayer;
                ///FUTURE SOUND
                ///
                PowerSeed powerSeed = collision.GetComponent<PowerSeed>();
                powerSeed.deathState = true;
                ///STOPP ALL RIGS
                appitRig.isKinematic = true;
                appitRig.constraints = RigidbodyConstraints2D.FreezeAll;
                appitCap.enabled = false;
                appitSR.sortingLayerName = "Player";
                appitSR.sortingOrder = 5;
                spawnItem.spawningMode = true;///SPAWN ITEM
                print("appit stopped all RIGS");

                appitanim.SetBool("Death", true);

            }


            if (collision.tag == "Player" && idleState == true) ///SETS FALLSTATE PREP NO DMG
            {
                fallPrep = true;
            }



            if (collision.tag == "Player" && canBeHit == true) ///ENSURE PLAYER IS NOT INVUL - DAMAGES PLAYER
            {
                AttaCollisions invulState = collision.GetComponent<AttaCollisions>();
                if(invulState.invulState == true)
                {
                   
                }
                if (invulState.invulState == false)///CHECK IF PLAYER IS INVUL
                {
                    AttaHealth playerHealth = collision.GetComponent<AttaHealth>();
                    invulState.hitState = true;
                    playerHealth.currentPlayerHealth -= dmgToPlayer;
                    ///STOP ALL RIGS FOR APPIT
                    appitRig.isKinematic = true;
                    appitRig.constraints = RigidbodyConstraints2D.FreezeAll;
                    appitCap.enabled = false;
                    appitSR.sortingLayerName = "Player";
                    appitSR.sortingOrder = 5;
                    //StartCoroutine(invulState.FlickerAtta());///START FLICKER ON ATTA
                    ///Future FLicker ON PLAYER
                    ///FUTURE SOUND
                    ///FUTURE PTS DISPLAY
                    appitanim.SetBool("Death", true);
                }
            }

        }

        private void OnCollisionEnter2D(Collision2D collision) ///SETS ROLLING STATE AND CLALCULATES PLAYHER POS 
        {
            if(collision.gameObject.tag == "Platforms" && playerCalculated == false)///SETS ROLLS STATE ON PLATFORM calculated stops continuous calulations
            {
                canBeHit = true;
                rollingState = true;
                playerMove = FindObjectOfType<PlayerMove>();
                float playerPosX = playerMove.transform.position.x;
                float playerPosY = playerMove.transform.position.y;
                Vector2 playerPos = new Vector2(playerPosX, playerPosY);
                playerPosXVector = new Vector2(playerPosX, 0);
                if(playerPosX > this.transform.position.x)
                {
                    playerCurrentPos = new Vector3(1, 0);
                    playerCalculated = true;
                }
                if (playerPosX < this.transform.position.x)
                {
                    playerCurrentPos = new Vector3(-1, 0);
                    playerCalculated = true;
                }


                //playerCurrentPos = playerMove.transform.position - this.transform.position;///FIND PLAYER POS
            }
        }

        void Death()
        {
            Destroy(gameObject);
        }
    }

}