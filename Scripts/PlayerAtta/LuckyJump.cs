using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
    {


    /// <summary>
    /// CLASS COntrols LuckyJymp Ability
    /// </summary>
    public class LuckyJump : MonoBehaviour
    {
        [Header("Luck Mode")]
        [SerializeField] public bool luckyJumpMode;///SAVE
        [SerializeField] bool luckyJumpstate;
        [SerializeField] bool luckyJumpingDontExec;
        [SerializeField] float luckyJumpPower;
        [SerializeField] public float luckJCount;///SAVE + LOAD 
        [SerializeField] public float luckJMAX; ///Save + LOAD
        [Header("Color Bools")]
        [SerializeField] public bool yellowJump;///SAVE + LOAD 
        [SerializeField] public bool blueJump;///SAVE + LOAD 
        [SerializeField] public bool greenJump;///SAVE + LOAD 
        [SerializeField] public bool redJump;///SAVE + LOAD 
        [SerializeField] public bool bowJump;///SAVE + LOAD 
        [Header("Particle Colors")]
        [SerializeField] GameObject fxJumpBlue;
        [SerializeField] GameObject fxJumpRed;
        [SerializeField] GameObject fxJumpGreen;
        [SerializeField] GameObject fxJumpBow;
        [SerializeField] GameObject fxJumpYellow;
        [SerializeField] GameObject fxJump;///THIS IS THE SPAWN
        

        [Header("Scripts")]
        [SerializeField] PlayerMove playerMove;
        [SerializeField] GroundCheck groundCheck;


        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            groundCheck = FindObjectOfType<GroundCheck>();
        }

        // Update is called once per frame
        void Update()
        {

            ColorSwitch();
            if (Input.GetButtonDown("Jump") && playerMove.jumpButtonPressed == false && luckyJumpMode == true && playerMove.grounded == false) ///ENSURE JUMP MODE IS ACTIVE AND IN MIDAIR
            {
                luckyJumpstate = true;
            }

            if(Input.GetButtonUp("Jump") && luckyJumpMode == true) ///RESET ON RELEASE
            {
                luckyJumpingDontExec = false;
                luckyJumpstate = false;
            }

            if(luckJCount >= luckJMAX)
            {
                luckJCount = luckJMAX;
            }

            if(luckJCount <= 0)
            {
                luckyJumpMode = false;
                luckyJumpstate = false;
            }

            
        }

        private void FixedUpdate()
        {
            if(luckyJumpstate == true && luckJCount > 0 && luckyJumpingDontExec == false)///ENSURE NOT EXECTUING TO PREVENT HELD BUTTON 
            {
                LuckyJumper();
            }
        }

        void LuckyJumper()
        {
            ColorSwitch();
            luckyJumpingDontExec = true;///SET TO TRUE TO STOP FROM CONT EXEC
            playerMove.jumpButtonPressed = true;///STOPS HOLDING
            playerMove.attaAnim.SetBool("Jump", true);
            //attaAnim.SetBool("Idle", false);
            print("Jump Anim is = = " + playerMove.attaAnim.GetBool("Jump"));
            playerMove.attaRig.gravityScale = 1.5f;
            playerMove.attaRig.AddForce(luckyJumpPower * Vector2.up * Time.deltaTime, ForceMode2D.Impulse);///35 1.5 USE HIGHE JUMP POWER TO OVERCOME -VELOCITY AND GRAVITY
            ///PARTICLE SYSTEM FUTURE
            luckJCount -= 1f; ///SUBTRACT COUNT
            GameObject spawnFX = Instantiate(fxJump, transform.position - new Vector3(0,.5f), transform.rotation);
            ParticleSystem spawnPart = spawnFX.GetComponent<ParticleSystem>();
            spawnPart.Play();

            // if (playerMove.attaRig.velocity.y >= velYMAX)
            // {
            // playerMove.jumpingState = false;
            //}
        }

        void ColorSwitch()
        {
            if(blueJump == true)
            {
                fxJump = fxJumpBlue;
            }

            if (yellowJump == true)
            {
                fxJump = fxJumpYellow;
            }

            if (redJump == true)
            {
                fxJump = fxJumpRed;
            }

            if (greenJump == true)
            {
                fxJump = fxJumpGreen;
            }

            if (bowJump == true)
            {
                fxJump = fxJumpBow;
            }

          

        }
    }
}