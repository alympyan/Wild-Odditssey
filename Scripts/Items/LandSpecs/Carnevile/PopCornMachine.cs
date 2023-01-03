using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class PopCornMachine : MonoBehaviour
    {
        [SerializeField] BoxCollider2D myBox;
        [SerializeField] GameObject ticketObj; ///Change colors
        [SerializeField] GameObject ticketSpawn;
        [SerializeField] Animator myAim;
        [SerializeField] AudioSource myAud;
        [SerializeField] bool litPop;
        [SerializeField] bool spawningTicket;
        [SerializeField] bool ticketSpawned;
        [SerializeField] WandFireball fireBall;


        // Start is called before the first frame update
        void Start()
        {
            myBox = GetComponent<BoxCollider2D>();
            myAud = GetComponent<AudioSource>();
            myAim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(litPop == true && spawningTicket == false)
            {
                SpawnTicket();
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.name.Contains("FireBall") && litPop == false)
            {
                myBox.enabled = false;
                litPop = true;
                myAim.SetBool("Pop", true);
                fireBall = collision.GetComponent<WandFireball>();
                fireBall.lightState = true;
                fireBall.myAnim.SetBool("Death", true);
                Rigidbody2D fireRig = collision.GetComponent<Rigidbody2D>();
                fireRig.constraints = RigidbodyConstraints2D.FreezeAll;
                BoxCollider2D fireBox = collision.GetComponent<BoxCollider2D>();
                fireBox.enabled = false;
            }
        }

        void SpawnTicket()
        {
            spawningTicket = true;
            ticketSpawn = Instantiate(ticketObj, transform.position + Vector3.up, transform.rotation);
            ticketSpawned = true;
        }
    }
}
