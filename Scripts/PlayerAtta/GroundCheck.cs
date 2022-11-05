using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OdditsseyEngine
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] public bool grounded;
        [SerializeField] PlayerMove playerMove;
        [SerializeField] Rigidbody2D attaRig;
        

        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == ("Platforms"))
            {
                grounded = true;
                playerMove.attaRig.velocity = new Vector2(playerMove.attaRig.velocity.x, 0);
                playerMove.attaAnim.SetBool("Jump", false);
                

            }
        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == ("Platforms"))
            {
                grounded = true;
                
                
            }
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == ("Platforms") )
            {
                grounded = false;
            }
        }
    }
}
