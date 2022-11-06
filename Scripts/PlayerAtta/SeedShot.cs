using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class SeedShot : MonoBehaviour
    {
        /// <summary>
        /// Class Controls SeedShot Ability
        /// </summary>
        /// 


        [Header("Options")]
        [SerializeField] bool seedButtonPressed;
        [SerializeField] float seedPower;
        [SerializeField] float seedDMG;
        [SerializeField] public bool powerSeeds;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool deviSeeds; ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool slappingSeeds;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] float rightDir;
        [SerializeField] Vector3 shootOff;
        [SerializeField] float shootDelayTime;

        [Header("AMMO")]
        [SerializeField] public float seedAmmoCurrent; ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public float seedAmmoMax; ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp0;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp1;  ///SAVE VAR - FEED TO GAMEENGNE
        [SerializeField] public bool ammoUp2;  ///SAVE VAR - FEED TO GAMEENGNE

        [Header("Spawn")]
        [SerializeField] GameObject seedObj;
        [SerializeField] Sprite yellowPower;
        [SerializeField] Sprite deviOrange;
        [SerializeField] Sprite slappinBlue;
        [SerializeField] GameObject spawnObj;
        [SerializeField] bool shootState;
        [SerializeField] bool shootingDontSpawn;

        [Header("Scripts")]
        [SerializeField] PlayerMove playerMove;
        [SerializeField] GameEngine gameEngine;
        ///FUTURE FOR LEVELMAP

        [Header("Comp")]
        [SerializeField] Rigidbody2D attaRig;
        [SerializeField] Animator shootAnim;
        [SerializeField] Animation shootAnimation;
        [SerializeField] AnimationClip yellowShotAnim;
        [SerializeField] AnimationClip orangeShotAnim;
        [SerializeField] AnimationClip blueShotAnim;



        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            gameEngine = FindObjectOfType<GameEngine>();
            shootAnimation = GetComponent<Animation>();
            shootAnim = GetComponent<Animator>();
           
        }

        // Update is called once per frame
        void Update()
        {///Check for Shoot Input, shootstate, the toggleDontSpawn, and > 0 ammo
            if(Input.GetButtonDown("Shoot") && shootState == false && shootingDontSpawn == false && seedAmmoCurrent > 0) ///FUTURE BOOL FOR CONTEXT
            {
                shootState = true;
               
            }


            AmmoHandler();///CALL AMMOHANDLER FOR UPGRADES

        }

        private void FixedUpdate() ///SET SHOOTINGDOWNTSPAWN TRUE TO STOP SPAMMING!!!
        {
            if (shootState == true && deviSeeds == false && slappingSeeds == false && shootingDontSpawn == false) ///CHECK FOR TYPE OF SEED AND PASS TO FUNC
            {///POWERSEEDS
                shootingDontSpawn = true;
                shootAnimation.clip = yellowShotAnim;

               StartCoroutine(PowerSeed(powerSeeds));

            }
            if (shootState == true && deviSeeds == true && slappingSeeds == false && shootingDontSpawn == false) ///DEVI
            {
                shootingDontSpawn = true;
                shootAnimation.clip = orangeShotAnim;
                StartCoroutine(PowerSeed(deviSeeds));
            }
            if (shootState == true && deviSeeds == false && slappingSeeds == true && shootingDontSpawn == false) ///SLAPPIN
            {
                shootingDontSpawn = true;
                shootAnimation.clip = blueShotAnim;
                StartCoroutine(PowerSeed(slappingSeeds));
            }
        }

        IEnumerator PowerSeed(bool seed)///PROJECTILES ARE ALL IENUMERATORS FOR DELYA SHOT PURPOSES
        {
            shootingDontSpawn = true; ///SET THIS BOOL TO STOP SPAMMING
            //shootAnimation.Play();
            shootAnim.SetBool("Shoot", true);///CURRENT ANIMATION IMPLEMENTAITO - MIGHT SWITCH TO ANIMATION CLIPS
            if (transform.right == Vector3.right) { rightDir = 1f; }///GATHER TRANSFORM RIGHT
          
            if (transform.right == Vector3.left)
            {
                rightDir = -1f;
            }

            spawnObj = Instantiate(seedObj, transform.position + shootOff * rightDir, transform.rotation);///SPANW SEEDOBJ!!!!
            PowerSeed spawnSeed = spawnObj.GetComponent<PowerSeed>();
            SpriteRenderer spawnSR = spawnObj.GetComponent<SpriteRenderer>();
            if(seed == powerSeeds) ///SET SEED SCRIPT VARS 
            {
                spawnSeed.powerSeed = true;
                spawnSR.sprite = yellowPower;
                spawnSeed.seedDMG = 1f;
            }
            if (seed == deviSeeds)
            {
                spawnSeed.deviSeeds = true;
                spawnSR.sprite = deviOrange;
                spawnSeed.seedDMG = 2f;
            }
            if (seed == slappingSeeds)
            {
                spawnSeed.slappinSeeds = true;
                spawnSR.sprite = slappinBlue;
                spawnSeed.seedDMG = 3f;
            }
            Rigidbody2D spawnRig = spawnObj.GetComponent<Rigidbody2D>();
            spawnRig.AddForce(new Vector2(rightDir, 0) * seedPower * Time.deltaTime, ForceMode2D.Impulse);///MOVE SAPWNED SEED

            ///AMMO Code
            seedAmmoCurrent -= 1f;///Subtract Ammo
            yield return new WaitForSeconds(shootDelayTime);///ENSURE SEED DELAY TIME SETUP
            shootState = false;
            shootingDontSpawn = false; ///RESET BOOL


        }


        void AmmoHandler() ///ENSURE AMMO BOOL SET!!
        {
           if(ammoUp0 == true)
            {
                seedAmmoMax = 4;
            }
           if(ammoUp1 == true)
            {
                seedAmmoMax = 6;
            }

           if(ammoUp2 == true)
            {
                seedAmmoMax = 8;
            }


           ///Prevent MAX Ammo being exceeded
           if(seedAmmoCurrent >= seedAmmoMax)
            {
                seedAmmoCurrent = seedAmmoMax;
            }
        }

        void ShootAnimreset()
        {
            shootAnim.SetBool("Shoot", false);
            shootAnimation.Stop();
        }
    }

}