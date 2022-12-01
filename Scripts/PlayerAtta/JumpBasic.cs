using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class JumpBasic : MonoBehaviour
    {
        /// <summary>
        /// Class Controls Basic Jump Atta
        /// </summary>
        /// 

        [Header("Options")]
        [SerializeField] float jumpPower;
        [SerializeField] bool jumpingState;
        [SerializeField] bool buttonPressed;
        [SerializeField] float jumpdownForce;
        [SerializeField] bool grounded;
        [SerializeField] float buttonTimer;
        [SerializeField] float buttonTimerOG;
        [Header("Velocity")]
        [SerializeField] float velcYCounter;
        [SerializeField] float velcYMAX;
        [SerializeField] float velcYFallMAX;///USE FOR FALLING MAX

        [Header("Comp")]
        [SerializeField] Rigidbody2D attaRig;
        [SerializeField] Animator attaAnim;
        [Header("Script")]
        [SerializeField] GroundCheck groundScript;
        [SerializeField] AttaCollisions attaCollisions;
        [SerializeField] PlayerMove playerMove;
        // Start is called before the first frame update
        void Start()
        {
            attaAnim = GetComponent<Animator>();
            attaRig = GetComponent<Rigidbody2D>();
            groundScript = FindObjectOfType<GroundCheck>();
            playerMove = FindObjectOfType<PlayerMove>();
            buttonTimerOG = buttonTimer;

        }

        // Update is called once per frame
        void Update()
        {
            velcYCounter = attaRig.velocity.y;
            grounded = groundScript.grounded;
            if(Input.GetButton("Jump") == true && groundScript.grounded == true && buttonPressed == false && playerMove.kladderOn == false)
            {
                print("jumpbasic button down");
                jumpingState = true;
                playerMove.jumpingState = true; ///LEGACY SUPPORT For MOVEMENT
            }

            if(Input.GetButtonUp("Jump") == true)
            {
                print("jumpbasic button up");
                jumpingState = false;
                playerMove.jumpingState = false;
                buttonPressed = false;
            }

            if(groundScript.grounded == true && jumpingState == false)
            {
                //attaAnim.SetBool("Jump", false);
                Physics2D.SyncTransforms(); 
                attaRig.gravityScale = 1f;
                print("jumpbasic grounded true");
                //playerMove.jumpingState = false;
                buttonTimer = buttonTimerOG; 
            }

            if(groundScript.grounded == true)
            {
                attaAnim.SetBool("Jump", false);
            }

            if(jumpingState == true)
            {
                buttonTimer -= Time.deltaTime;
            }

            if(buttonTimer <= 0)
            {
                jumpingState = false;

            }

            if(velcYCounter <= velcYMAX && jumpingState == false && groundScript.grounded == false && playerMove.kladderOn == false)///Increase Fall - Ensure Kladder is Off
            {
                attaRig.gravityScale = 2f;
            }
            if (velcYCounter <= velcYFallMAX && playerMove.kladderOn == false)///CAP Velocity
            {
                attaRig.velocity = new Vector2(attaRig.velocity.x, velcYFallMAX);
            }
        }

        private void FixedUpdate()
        {
            if(jumpingState == true)
            {
                print("jumpbasic jump state true");
                Jump();
            }
        }

        void Jump()
        {
            attaRig.gravityScale = 1.5f;
            attaAnim.SetBool("Jump", true);
            buttonPressed = true;///sTOPS CONTNUOS JUMP ON GROUND
            attaRig.AddForce(jumpPower * Time.deltaTime * Vector2.up, ForceMode2D.Impulse);
            attaRig.gravityScale = 1.5f;
            if(attaRig.velocity.y > 3)
            {
                attaRig.AddForce(jumpdownForce * Time.deltaTime * Vector2.down, ForceMode2D.Impulse);
            }
            if (attaRig.velocity.y > 5)
            {
                attaRig.AddForce(jumpdownForce * 10 * Time.deltaTime * Vector2.down, ForceMode2D.Impulse);
            }
            if (velcYCounter > velcYMAX )
            {
                jumpingState = false;
                playerMove.jumpingState = false;

            }
            if(buttonTimer <0 && jumpingState == true)
            {
                jumpingState = false;
                playerMove.jumpingState = false;
            }
        }
    }
}
