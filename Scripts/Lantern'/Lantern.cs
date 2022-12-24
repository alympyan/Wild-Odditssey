using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class Lantern : MonoBehaviour
    {
        /// <summary>
        /// Class controls the Lantern Checkpoint
        /// </summary>

        [SerializeField] Vector3 checkPOS;
        [SerializeField] bool collidedPlayer;
        [SerializeField] Animator myAnim;

        // Start is called before the first frame update
        void Start()
        {
            myAnim = GetComponent<Animator>();
            checkPOS = transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Player" && collidedPlayer == false)
            {
                collidedPlayer = true;
                AttaHealth attaHealth = collision.GetComponent<AttaHealth>();
                attaHealth.myCheckPointPos = checkPOS;
                print("lantern new CheckPos");
                myAnim.SetBool("Lit", true);
            }
        }
    }
}