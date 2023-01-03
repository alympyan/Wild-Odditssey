using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class DestructObj : MonoBehaviour
    {
        /// <summary>
        /// Class Controls Destructible Objects
        /// </summary>
        /// 

        [Header("Options")]
        [SerializeField] bool breakMode;
        [SerializeField] bool animationMode;
        [SerializeField] bool particleMode;
        [SerializeField] bool capsuleOn;
        [SerializeField] bool boxOn;
        [Header("Comp")]
        [SerializeField] SpawnItems spawnItem;
        [SerializeField] Rigidbody2D destRig;
        [SerializeField] BoxCollider2D destBox;
        [SerializeField] CapsuleCollider2D destCap;
        [SerializeField] Animator destAnim;
        [SerializeField] AudioSource destAudio;

        

        // Start is called before the first frame update
        void Start()
        {
            spawnItem = GetComponent<SpawnItems>();
            destRig = GetComponent<Rigidbody2D>();
            if (boxOn == true)
            {
                destBox = GetComponent<BoxCollider2D>();
            }
            destAnim = GetComponent<Animator>();
            destAudio = GetComponent<AudioSource>();
            if (capsuleOn == true)
            {
                destCap = GetComponent<CapsuleCollider2D>();
            }

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "PowerSeeds" && breakMode == false)
            {
                print("dest PowerSeeds hit");
                breakMode = true;
                if(animationMode == true)
                {
                    destAnim.SetBool("Death", true);
                }
                if(particleMode == true)
                {

                }
                
                spawnItem.spawningMode = true;
            }

            if(collision.tag == "TailKiss" && breakMode == false)
            {
                print("dest TailKiss hit");
                breakMode = true;
                if (animationMode == true)
                {
                    destAnim.SetBool("Death", true);
                }
                if (particleMode == true)
                {

                }

                spawnItem.spawningMode = true;
            }
            if (collision.name.Contains("FireBall") && breakMode == false)
            {
                print("dest TailKiss hit");
                breakMode = true;
                if (animationMode == true)
                {
                    destAnim.SetBool("Death", true);
                }
                if (particleMode == true)
                {

                }

                spawnItem.spawningMode = true;
            }


        }

        void DestroyObj()
        {
            Destroy(gameObject);
        }
    }
}
