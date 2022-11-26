using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class EnemyCollisions : MonoBehaviour
    {
        /// <summary>
        /// Class controls Popper Collisions
        /// ENEMYHITS Controls EnemyBase
        /// </summary>

        [SerializeField] Rigidbody2D enmyRig;
        [SerializeField] BoxCollider2D enmyBox;
        [SerializeField] PopperBase popperBase;



        // Start is called before the first frame update
        void Start()
        {
            enmyBox = GetComponent<BoxCollider2D>();
            enmyRig = GetComponent<Rigidbody2D>();
            popperBase = GetComponentInParent<PopperBase>();
        }

        // Update is called once per frame
        void Update()
        {
            if(popperBase.detectPlayerState == false)
            {
                enmyBox.enabled = false;
            }

            if (popperBase.detectPlayerState == true)
            {
                enmyBox.enabled = true;
            }
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            print("Popper collision Eneter" + collision.gameObject.tag);
            if (collision.gameObject.tag == "TailKiss" && popperBase.canBeHit == true)
            {
                print("Popper collided with Tail");
                popperBase.popHealth -= 1f;
                popperBase.canBeHit = false;
                StartCoroutine(popperBase.FlickerMe());
            }

            if (collision.gameObject.tag == "PowerSeeds" && popperBase.canBeHit == true)
            {
                print("Popper collided with Tail");
                PowerSeed powerSeed = collision.gameObject.GetComponent<PowerSeed>();///SET DEATH STATE ON POWERSEED
                powerSeed.deathState = true;
                popperBase.popHealth -= 1f;
                popperBase.canBeHit = false;
                StartCoroutine(popperBase.FlickerMe());
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) ///HANDLE COLLISION AND HITS IN TRIGGER ONLY
        {
            print("Popper collision Eneter" + collision.gameObject.tag);
            if (collision.gameObject.tag == "TailKiss" && popperBase.canBeHit == true)
            {
                print("Popper collided with Tail");
                popperBase.popHealth -= 1f;
                popperBase.canBeHit = false;
                StartCoroutine(popperBase.FlickerMe());
            }

            if (collision.gameObject.tag == "PowerSeeds" && popperBase.canBeHit == true)///THIS IS WHERE COLLISIONS TAKE PLACE
            {
                print("Popper collided with Tail");
                PowerSeed powerSeed = collision.gameObject.GetComponent<PowerSeed>();///SET DEATH STATE ON POWERSEED
                powerSeed.deathState = true;
                popperBase.popHealth -= 1f;
                popperBase.canBeHit = false;
                StartCoroutine(popperBase.FlickerMe());
            }
        }
    }

}