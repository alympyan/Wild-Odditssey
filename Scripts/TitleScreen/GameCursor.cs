using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class GameCursor : MonoBehaviour
    {
        /// <summary>
        /// Class Control Game Cursor For UI
        /// </summary>
        /// 
        [SerializeField] float moveSpeed;
        [SerializeField] bool clicked;
        [SerializeField] RectTransform myRect;
        [SerializeField] Rigidbody2D myRig;
        [SerializeField] SpriteRenderer mySR;
        [SerializeField] Sprite idleSprite;
        [SerializeField] Sprite clickSprite;
        [SerializeField] float velcXCounter;
        [SerializeField] float velcYCounter;

        // Start is called before the first frame update
        void Start()
        {
            //myRect = GetComponent<RectTransform>();
            myRig = GetComponent<Rigidbody2D>();
            mySR = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            velcXCounter = myRig.velocity.x;
            velcYCounter = myRig.velocity.y;
            if (Input.GetAxis("Horizontal") > .1f)
            {
                //myRig.AddForce(moveSpeed * Vector2.right * Time.deltaTime, ForceMode2D.Impulse);
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            if (Input.GetAxis("Horizontal") < -.1f)
            {
                //myRig.AddForce(moveSpeed * Vector2.left * Time.deltaTime, ForceMode2D.Impulse);
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                myRig.velocity = Vector2.zero;
                
            }



            if (Input.GetAxis("Vertical") > .1f)
            {
                //myRig.AddForce(moveSpeed * Vector2.up * Time.deltaTime, ForceMode2D.Impulse);
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            if (Input.GetAxis("Vertical") < -.1f)
            {
               // myRig.AddForce(moveSpeed * Vector2.down * Time.deltaTime, ForceMode2D.Impulse);
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
            if (Input.GetAxis("Vertical") == 0)
            {
                myRig.velocity = Vector2.zero;
            }

            if(Input.GetButton("Submit"))
            {
                mySR.sprite = clickSprite;
            }


            if (Input.GetButtonUp("Submit"))
            {
                mySR.sprite = idleSprite;
            }


        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            GameButton gameButton = collision.GetComponent<GameButton>();
            if(gameButton.startButton == true)
            {

            }
        }

        private void OnGUI()
        {
            
        }
    }

}
