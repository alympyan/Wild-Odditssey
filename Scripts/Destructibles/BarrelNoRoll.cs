using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class BarrelNoRoll : MonoBehaviour
    {
        [SerializeField] GameObject triggerField;
        [SerializeField] bool dropped;
        [SerializeField] float speedForce;
        [SerializeField] bool breakMode;
        [SerializeField] bool hitFloor;
        [SerializeField] Rigidbody2D myRig;
        [SerializeField] float velcXMax;
        [SerializeField] int dmgToPlayer;
        [SerializeField] Animator myAnim;
        [SerializeField] CapsuleCollider2D myCap;
        [SerializeField] float lifeTimer;


        // Start is called before the first frame update
        void Start()
        {
            myRig = GetComponent<Rigidbody2D>();
            myAnim = GetComponent<Animator>();
            myCap = GetComponent<CapsuleCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if(dropped == true && hitFloor == false)
            {
                myRig.constraints = RigidbodyConstraints2D.None;
                
            }
            if(hitFloor == true)
            {
                lifeTimer -= Time.deltaTime;
            }
            if(lifeTimer <=0 )
            {
                breakMode = true;
            }
            if(myRig.velocity.x >= velcXMax)
            {
                myRig.velocity = new Vector2(velcXMax, myRig.velocity.y);
            }
        }

        private void FixedUpdate()
        {
            if(hitFloor == true)
            {
                myRig.AddForce(speedForce * Vector2.left * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                dropped = true;
            }
            if(breakMode == true)
            {
                myAnim.SetBool("Break", true);
            }
         
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                dropped = true;
            }
            if (breakMode == true)
            {
                myAnim.SetBool("Break", true);
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Platforms")
            {
                hitFloor = true;
                myRig.velocity = new Vector2(myRig.velocity.x, 0);
            }
            if(collision.gameObject.tag == "Player")
            {
                myRig.constraints = RigidbodyConstraints2D.FreezeAll;
                myRig.velocity = Vector2.zero;
                AttaHealth health = collision.gameObject.GetComponent<AttaHealth>();
                AttaCollisions col = collision.gameObject.GetComponent<AttaCollisions>();
                col.hitState = true;
                health.currentPlayerHealth -= dmgToPlayer;
                myCap.enabled = false;
                breakMode = true;
            }
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
