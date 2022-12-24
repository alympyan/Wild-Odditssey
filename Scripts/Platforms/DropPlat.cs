using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class DropPlat : MonoBehaviour
    {
        [SerializeField] bool dropped;
        [SerializeField] float timer;
        [SerializeField] float ogTimer;
        [SerializeField] bool playerAttached;
        [SerializeField] BoxCollider2D myBox;


        // Start is called before the first frame update
        void Start()
        {
            myBox = GetComponent<BoxCollider2D>();
            ogTimer = timer;
        }

        // Update is called once per frame
        void Update()
        {
            if(dropped == true)
            {
                myBox.enabled = false;
                timer -= Time.deltaTime;
            }
            if(timer <= 0 && dropped == true)
            {
                timer = ogTimer;
                dropped = false;
            }

            if(dropped == false)
            {
                myBox.enabled = true;
            }

            if(playerAttached == true && dropped == false && Input.GetAxis("Vertical") < -.5)
            {
                dropped = true;
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                playerAttached = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            {
                if (collision.gameObject.tag == "Player")
                {
                    playerAttached = false;
                }
            }
        }

    }
}
