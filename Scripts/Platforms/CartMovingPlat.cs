using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class CartMovingPlat : MonoBehaviour
    {
        [SerializeField] int dirMove;
        [SerializeField] GameObject wayPosA;
        [SerializeField] GameObject wayPosB;
        [SerializeField] GameObject wayPosStart;
        [SerializeField] SwitchLevel switchLevel;
        [SerializeField] float speedMove;
        [SerializeField] public bool aSwitch;
        [SerializeField] public bool bSwitch;
        [SerializeField] public bool movingState;
        [SerializeField] bool homeMoving;
        [SerializeField] public bool homeSwitch;
        [SerializeField] float timerDelay;
        [SerializeField] float timerOG;
        [SerializeField] bool timerStart;
        [SerializeField] PlayerMove playerM;

        // Start is called before the first frame update
        void Start()
        {
            playerM = FindObjectOfType<PlayerMove>();
            timerOG = timerDelay;
        }

        // Update is called once per frame
        void Update()
        {
            Physics.SyncTransforms();
            if(timerStart == true)
            {
                timerDelay -= Time.deltaTime;
            }
            if(timerDelay <= 0) ///Switch to Pos A From Home
            {
                timerStart = false;
                timerDelay = timerOG;
                movingState = true;
       
            }

            if(movingState == true)
            {
                if (aSwitch == true && homeSwitch == true)///Move To A
                {
                    print("MoveA");
                  transform.position =  Vector3.MoveTowards(this.transform.position, wayPosA.transform.position, speedMove * Time.deltaTime);
                    //movingState = true;
                    
                }
                if (aSwitch == true && homeSwitch == false)///Move Home
                {
                    transform.position = Vector3.MoveTowards(this.transform.position, wayPosStart.transform.position, speedMove * Time.deltaTime);
                   //movingState = true;
                }
                if (bSwitch == true && homeSwitch == true)/// Move To B
                {
                    transform.position = Vector3.MoveTowards(this.transform.position, wayPosB.transform.position, speedMove * Time.deltaTime);
                    //movingState = true;
                }
                if (bSwitch == true && homeSwitch == false)///Move Home
                {
                    transform.position = Vector3.MoveTowards(this.transform.position, wayPosStart.transform.position, speedMove * Time.deltaTime);
                    //movingState = true;
                }
            }

        }


        private void LateUpdate()
        {
            Physics.SyncTransforms();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                Physics.SyncTransforms();
                playerM.transform.SetParent(this.gameObject.transform);
            }
       
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name.Contains("WayA"))
            {

                timerStart = true;
                homeSwitch = false;
                movingState = false;

            }
            if (collision.name.Contains("WayB"))
            {
                print("wayB hit, timer start");
                timerStart = true;
                homeSwitch = false;
                movingState = false;

            }
            if (collision.name.Contains("Home"))
            {
                homeSwitch = true;
                timerStart = true;
                movingState = false;


            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {

                playerM.transform.SetParent(null);
                DontDestroyOnLoad(playerM);
            }
        }
    }
}
