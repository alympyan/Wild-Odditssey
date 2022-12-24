using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class MovingPlatsBasic : MonoBehaviour
    {
        /// <summary>
        /// Class controls Basic Moving Paltforms
        /// </summary>
        // Start is called before the first frame update

        [Header("Options")]
        [SerializeField] float moveSpeed;
        [SerializeField] bool directionPatternY;
        [SerializeField] bool directionPatternX;
        [SerializeField] float timerOfMoving;
        [SerializeField] bool hitBoxYo;
        [SerializeField] bool switchedOn;
        [SerializeField] Vector3 directionMoverX; ///Var To Move in Translate
        [SerializeField] Vector3 directionMoverY;
        [SerializeField] Vector2 rigForce;
        [SerializeField] bool movingState;
        [SerializeField] bool playerAttached;
        [SerializeField] float dirFloat;
        [SerializeField] Transform[] playerTrans;
        [SerializeField] Rigidbody2D[] playerRig;
        [SerializeField] float downForce;
        [SerializeField] PlayerMove[] playerMove;
       [Header("Comps")]
        [SerializeField] Rigidbody2D platRig;
       


        void Start()
        {
            platRig = GetComponent<Rigidbody2D>();
            dirFloat = 1;
            
            
        }

        // Update is called once per frame
        void Update()
        {
            
            Physics2D.SyncTransforms();

            if (directionPatternX == true)
            {
                print("Plat Move DirX is True");
                directionMoverX = new Vector3(1, 0);
                directionPatternY = false;
                rigForce = new Vector2(dirFloat, 0);
                //transform.Translate(directionMoverX * Time.deltaTime * moveSpeed * dirFloat);
                //PlatPhysMove(rigForce);
            }

            if (directionPatternY == true)
            {
                directionMoverY = new Vector3(0, 1);
                directionPatternX = false;
                rigForce = new Vector2(0, dirFloat);
                // transform.Translate(directionMoverY * Time.deltaTime * moveSpeed * dirFloat);
                print("Platform Y is Executing");
                //PlatPhysMove(rigForce);
            }

            if(movingState == false)
            { StartCoroutine(PlatMover()); }

            if(Input.GetButtonDown("Jump") && playerAttached == true)
            {
                playerAttached = false;
                playerTrans[1].SetParent(null);
                

                
            }

            if (playerAttached == true)
            {

                Physics2D.SyncTransforms();
                playerTrans[1].localPosition = playerTrans[1].localPosition;
                
                platRig.position = transform.position;
            }



        }

        private void FixedUpdate()
        {
          

            if (playerAttached == true)
            {
                //playerRig[1].velocity = new Vector2(playerRig[1].velocity.x, platRig.velocity.y);
                //playerRig[1].AddForce(Vector2.down * downForce  * Time.deltaTime, ForceMode2D.Impulse);
                //Physics2D.SyncTransforms();
            }

            if (playerAttached == true)
            {
                //playerRig[1].MovePosition(new Vector2(playerRig[1].position.x, platRig.position.y + .5f));
                //playerRig[1].AddForce(Vector2.down * downForce  * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        private void LateUpdate()
        {
            PlatPhysMove(rigForce);///MOVE

            if (playerAttached == true)
            {
                //playerRig[1].velocity = new Vector2(playerRig[1].velocity.x, 0);
                playerTrans[1].localPosition = playerTrans[1].localPosition;
                this.transform.position = transform.position;
                //Physics2D.SyncTransforms();
                
                //platRig.position = transform.position;
            }
        }




        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "GroundCheck")
            {
                playerTrans = collision.gameObject.GetComponentsInParent<Transform>();
                playerRig = collision.gameObject.GetComponentsInParent<Rigidbody2D>();
                playerAttached = true;
                playerRig[1].velocity = new Vector2(playerRig[1].velocity.x, 0);
                print("Plat player attached");
                playerMove = collision.GetComponentsInParent<PlayerMove>();
                //playerMove[0].velYMAX = -0f;
                //playerRig[1].gravityScale = 10f;
                playerTrans[1].SetParent(this.transform);
                playerRig[1].interpolation = RigidbodyInterpolation2D.None;

            }
        }




     
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "GroundCheck")
            {
                //playerTrans[1] = collision.gameObject.GetComponentsInParent<Transform>();
                playerAttached = false;
                //playerRig[1].gravityScale = 1f;
                playerTrans[1].SetParent(null);
                playerRig[1].interpolation = RigidbodyInterpolation2D.Interpolate;

            }
        }



        IEnumerator PlatMover()
        {
            movingState = true;
            print("Plat Move PlatMover is True");

            //transform.Translate(moveDir * Time.deltaTime * moveSpeed);
            
            yield return new WaitForSeconds(timerOfMoving);
            platRig.velocity = Vector2.zero;
             dirFloat = -1;

            //transform.Translate(-moveDir * moveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(timerOfMoving);
             dirFloat = 1;
            platRig.velocity = Vector2.zero;
            movingState = false;


        }

        void PlatPhysMove(Vector2 dirForceFunc)
        {
            //Vector2 rigForce = new Vector2(Time.deltaTime * moveSpeed * dirFloat);
            print("Plat Phys Func is Exec");
            //platRig.AddForce(dirForceFunc * Time.deltaTime * moveSpeed, ForceMode2D.Force);

            transform.Translate(dirForceFunc * Time.deltaTime * moveSpeed);
            //platRig.MovePosition( platRig.position +   dirForceFunc   * Time.deltaTime);
        }


        
    }
}
