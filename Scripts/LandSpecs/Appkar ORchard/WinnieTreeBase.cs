using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class WinnieTreeBase : MonoBehaviour
    {
        /// <summary>
        /// Class Controls Winnie Trees in Orchards
        /// </summary>
        /// 
        [Header("GameObjecs")]
        [SerializeField] Rigidbody2D[] appleChildRig;
        [SerializeField] GameObject[] appleObj;
        [SerializeField] Transform[] appleTrans;
        
        // Start is called before the first frame update
        void Start()
        {
            appleChildRig = GetComponentsInChildren<Rigidbody2D>();
            appleTrans = GetComponentsInChildren<Transform>();
            appleTrans[1].transform.tag = ("Untagged");
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print("Winnie Colliding + = " + collision.tag);
            //PlayerMove tailMove = collision.GetComponent<PlayerMove>();
            if (collision.tag == ("TailKiss") || collision.tag == ("PowerSeeds"))
            {
               

                
                
                    print("Winnie TailKiss");
                    appleTrans[1].tag = ("Apple");
                    appleChildRig[1].isKinematic = false;
                    appleChildRig[1].constraints = RigidbodyConstraints2D.FreezeRotation;
                    appleTrans[1].transform.SetParent(null);
                

            }
        }
    }

}