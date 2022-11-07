using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace AwesomsseyEngine
{
    public class PlayerMove : MonoBehaviour
    {
        [Header("Player Vars")]
        [SerializeField] float horzInput;
        [SerializeField] float vertInput;
        [SerializeField] bool kladderOn;
        [SerializeField] float walkSpeed;
        [SerializeField] float normHorz;
        [SerializeField] float normVert;
        [SerializeField] bool isFacingRight;
        [SerializeField] bool flipped;
        [SerializeField] bool cool;
        [Header("Move Vars")]
        [SerializeField] float slideSpeed;
        [SerializeField] Vector2 transVectRight;
        [Header("RaysForDays")]
        [SerializeField] RaycastHit2D slideRay;
        [Header("States")]
        [Tooltip("Used for Special Moves")]
        [SerializeField] public bool contextState;
        [SerializeField] public bool slideState;
        [SerializeField] public bool walkState;
        [SerializeField] public bool jumpingState;
        [SerializeField] public bool tailKissState;
        [Header("Velocity Adacity")]
        [SerializeField] float velXCounter;
        [SerializeField] float velcXMAX;
        [SerializeField] float velYCounter;
        [SerializeField] float velYMAX;
        [SerializeField] float velYKladderMAX;
        [SerializeField] float velXKladderMAX;
        [SerializeField] float ogVelXMAX;
        [Header("Jump Menu")]
        [SerializeField] public bool grounded;
        [SerializeField] public float jumpPower;
        [SerializeField] float jumpCount;
        [SerializeField] float jumpCountMAX;
        [SerializeField] public bool jumpButtonPressed;

        [Header("Comp")]
        [SerializeField] public Rigidbody2D attaRig;
        [SerializeField] public Animator attaAnim;

        [Header("Script Ref")]
        [SerializeField] GroundCheck groundCheck;


        // Start is called before the first frame update
        void Start()
        {
            attaRig = GetComponent<Rigidbody2D>();
            attaAnim = GetComponent<Animator>();
            // groundCheck = GetComponent<GroundCheck>();
            isFacingRight = true;
            ogVelXMAX = velcXMAX; ///GRAB CURRENT VELCX FOR SLIDE
        }

        // Update is called once per frame
        void Update()
        {
            grounded = groundCheck.grounded;
            if (transform.right == Vector3.right)
            {
                transVectRight = new Vector2(1, 0);
            }
            if (transform.right == Vector3.left)
            {
                transVectRight = new Vector2(-1, 0);
            }



            horzInput = Input.GetAxis("Horizontal");
            vertInput = Input.GetAxis("Vertical");
            velXCounter = attaRig.velocity.x;
            velYCounter = attaRig.velocity.y;

            ///FLIPPING CODE FIRST
            if (Input.GetAxis("Horizontal") > .1f && isFacingRight == false && flipped == true) ///FLIP RIGHT
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                isFacingRight = true;
                //flippingState = true;
                flipped = false;
            }

            else if (Input.GetAxis("Horizontal") < -.1f && isFacingRight == true && flipped == false) ///FLIP LEFT
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                isFacingRight = false;
                flipped = true;
            }

            ///MOVE CODE -- Set Walk State and Reset State

            if (slideState == false) ///ENSURE NOT SLIDING
            {
                if (Input.GetAxis("Horizontal") > .1f && slideState == false && contextState == false)
                {
                    print("Walking No Slide = " + slideState);
                    walkState = true;
                    attaRig.AddForce(Vector2.right * walkSpeed * Time.deltaTime, ForceMode2D.Impulse);
                    attaAnim.SetBool("Walk", true);

                    //attaAnim.SetBool("Idle", false);

                }
                if (Input.GetAxis("Horizontal") < -.1f && slideState == false)
                {
                    walkState = true;
                    attaRig.AddForce(Vector2.left * walkSpeed * Time.deltaTime, ForceMode2D.Impulse);
                    attaAnim.SetBool("Walk", true);
                    // attaAnim.SetBool("Idle", false);

                }
                if (Input.GetAxis("Horizontal") == 0)

                {
                    walkState = false;
                    attaRig.velocity = new Vector2(0, attaRig.velocity.y);
                    attaAnim.SetBool("Walk", false);
                    attaAnim.SetBool("Idle", true);

                }
            }
            ///HORZ INPUT LOOP END



            ///KLADDER SETUP
            if (kladderOn == true)
            {
                VelocityKladderControl();
                slideState = false; ///SET STATES TO FALSE
                //attaRig.gravityScale = 0f;

                if (Input.GetAxis("Vertical") > .1f)
                {
                    attaRig.AddForce(Vector2.up * walkSpeed * Time.deltaTime, ForceMode2D.Impulse);
                    attaAnim.SetBool("Walk", false);
                    attaAnim.SetBool("Idle", false);
                    attaAnim.SetBool("Climb", true);
                    attaAnim.SetBool("ClimbIdle", false);

                }
                if (Input.GetAxis("Vertical") < -.1f)
                {
                    attaRig.AddForce(Vector2.down * walkSpeed * Time.deltaTime, ForceMode2D.Impulse);
                    attaAnim.SetBool("Walk", false);
                    attaAnim.SetBool("Idle", false);
                    attaAnim.SetBool("Climb", true);
                    attaAnim.SetBool("ClimbIdle", false);

                }
                if (Input.GetAxis("Vertical") == 0)
                {
                    attaRig.velocity = new Vector2(attaRig.velocity.x, 0);
                    attaAnim.SetBool("Walk", false);
                    attaAnim.SetBool("Idle", false);
                    attaAnim.SetBool("Climb", false);
                    attaAnim.SetBool("ClimbIdle", true);
                }
            }

            if (kladderOn == false)
            {
                //attaRig.gravityScale = 1f;
                //attaAnim.SetBool("Climb", false);
                //attaAnim.SetBool("ClimbIdle", false);


            }



            ///JUMP CODE !!!!!!!!!
            if (Input.GetButton("Jump") == true && groundCheck.grounded == true && jumpingState == false && jumpButtonPressed == false)
            {
                attaAnim.SetBool("Jump", true);
                jumpingState = true;
                print("Jump Pressed");


            }

            else if (Input.GetButtonUp("Jump") == true)
            {
                jumpingState = false;
                jumpButtonPressed = false;
            }


            else if (groundCheck.grounded == true)///GROUND CHECK
            {
                jumpingState = false;
                //attaAnim.SetBool("Jump", false);
                //attaAnim.SetBool("Idle", true);
                print("GravityScale is Grouneded");
                attaRig.gravityScale = 1f;


            }


            if (kladderOn == false)///DO VELCOITY CHECK WHEN NOT ON LADDER
            {
                VelocityControl();
            }


            ///TAILKISS
            if (Input.GetButton("Fire1") == true)
            {
                attaAnim.SetBool("Tail", true);

            }

            ///TailSlide
            if (Input.GetButtonDown("Throw") && vertInput < -.1f && walkState == false) ///ENSURE NO STATES INTERFERE
            {
                print("Slide Button");
                slideState = true;
            }

        }

        private void FixedUpdate()
        {
            if (jumpingState == true)
            {
                Jump();
            }

            if (slideState == true && jumpingState == false)
            {
                print("Slide Started");
                StartCoroutine(TailSlide());
            }
            if (slideState == false)///RESET VELCXMAX
            {
                velcXMAX = ogVelXMAX;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == ("Ladder") && Input.GetAxis("Vertical") > .1f)
            {
                kladderOn = true;
                //attaRig.gravityScale = 0;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == ("Ladder"))
            {
                kladderOn = false;
                attaRig.gravityScale = 1;
                print("Idle True");
                attaAnim.SetBool("Idle", true);
                attaAnim.SetBool("Climb", false);
                attaAnim.SetBool("ClimbIdle", false);
            }
        }


        void VelocityControl()
        {

            ///VELOCITY MAX LOOP
            if (attaRig.velocity.x >= velcXMAX)///POS X
            {
                attaRig.velocity = new Vector2(velcXMAX, attaRig.velocity.y);
            }
            if (attaRig.velocity.y >= velYMAX) ///POS Y
            {
                attaRig.velocity = new Vector2(attaRig.velocity.x, velYMAX);
            }
            if (attaRig.velocity.x <= -velcXMAX)///POS X
            {
                attaRig.velocity = new Vector2(-velcXMAX, attaRig.velocity.y);
            }
            if (attaRig.velocity.y <= -velYMAX) ///POS Y
            {
                attaRig.velocity = new Vector2(attaRig.velocity.x, -velYMAX);
            }

            if (attaRig.velocity.y < 0)///JUMP FALL
            {
                print("Velocity Fall");
                attaRig.gravityScale = 2f;
            }

        }


        void VelocityKladderControl()
        {
            if (kladderOn == true)

            {
                attaRig.gravityScale = 0f;
                print("GravityScale is = " + attaRig.gravityScale);
                if (attaRig.velocity.y >= velYKladderMAX) ///POS Y
                {
                    attaRig.velocity = new Vector2(attaRig.velocity.x, velYKladderMAX);
                }
                if (attaRig.velocity.y <= -velYKladderMAX) ///POS Y
                {
                    attaRig.velocity = new Vector2(attaRig.velocity.x, -velYKladderMAX);
                }

                ///XXXXX
                if (attaRig.velocity.x >= velXKladderMAX)///POS X
                {
                    attaRig.velocity = new Vector2(velXKladderMAX, attaRig.velocity.y);
                }
                if (attaRig.velocity.x <= -velXKladderMAX)///POS X
                {
                    attaRig.velocity = new Vector2(-velXKladderMAX, attaRig.velocity.y);
                }
            }
        }

        void Jump()
        {
            jumpButtonPressed = true;///STOPS HOLDING
            attaAnim.SetBool("Jump", true);
            //attaAnim.SetBool("Idle", false);
            print("Jump Anim is = = " + attaAnim.GetBool("Jump"));
            attaRig.gravityScale = 1.5f;
            attaRig.AddForce(jumpPower * Vector2.up * Time.deltaTime, ForceMode2D.Impulse);///35 1.5
            if (attaRig.velocity.y >= velYMAX)
            {
                jumpingState = false;
            }
        }

        IEnumerator TailSlide()
        {
            print("Slide Func");
            attaAnim.SetBool("Slide", true);
            float ogVelXMAX = velcXMAX;
            print("Slide vel = " + ogVelXMAX);
            velcXMAX = 5f;
            attaRig.AddForce(transform.right * slideSpeed * Time.deltaTime, ForceMode2D.Impulse);

            slideRay = Physics2D.Raycast(transform.position * transVectRight, transVectRight, 1f);
            if (slideRay != null)
            {
                // if (slideRay.collider.tag == ("Enemies"))
                {
                    print("Slide hit Enemy");
                }
            }
            yield return new WaitForSeconds(.5f);
            attaAnim.SetBool("Slide", false);
            //velcXMAX = ogVelXMAX;
            print("Slide vel AFTER = " + velcXMAX);
            slideState = false;


        }


        void TailReset()
        {
            attaAnim.SetBool("Tail", false);
        }
    }

}