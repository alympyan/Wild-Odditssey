using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// CLass controls ItemBoxDrop Collision and spawning
    /// </summary>
    /// 
   

    public class AttaItemBoxColl : MonoBehaviour
    {
        [SerializeField] public bool colliding;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print("item trigger tag is =  " + collision.tag);
            if(collision.tag == "Platforms")
            {
                colliding = true;
            }

            if(collision.tag != "Platforms")
            {
                colliding = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Platforms")
            {
                print("item trigger has lef");
                colliding = false;
            }
        }
    }

}