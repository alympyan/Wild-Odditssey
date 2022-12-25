using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class ApplesInOrchard : MonoBehaviour
    {
        [SerializeField] Rigidbody2D appleRig;
        [SerializeField] public bool pieckedUp;
        [SerializeField] BoxCollider2D appleBox;
        [SerializeField] SpriteRenderer appleSR;
        [SerializeField] Sprite goldApple;
        [SerializeField] Sprite rottenSprite;
        [SerializeField] public bool goldenApple;
        [SerializeField] bool hitPlat;
        // Start is called before the first frame update
        void Start()
        {
            appleRig = GetComponent<Rigidbody2D>();
            appleSR = GetComponent<SpriteRenderer>();
            appleBox = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if(goldenApple == true && hitPlat == false)
            {
                appleSR.sprite = goldApple;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)///BEFORE THROWN TRIGGER
        {



            if (collision.tag == ("Platforms") && pieckedUp == false)
            {
                print("apple  Mode and Picked up false");
                appleRig.velocity = new Vector2(appleRig.velocity.x, 0);
                appleRig.constraints = RigidbodyConstraints2D.FreezePositionY;
            }

           
        }

        private void OnCollisionStay2D(Collision2D collision) ///COllision for After Thrown
        {
            if (collision.gameObject.tag == ("Platforms") && pieckedUp == true) ///CHANGE TO ROTTEN WHEN SPAWNED FROM CONTEXTBUTTONS
            {
                hitPlat = true;
                print("apple Rotted Mode and Picked up True");
                appleRig.velocity = new Vector2(appleRig.velocity.x, 0);
                appleRig.constraints = RigidbodyConstraints2D.FreezeAll;
                appleBox.enabled = false;
                appleSR.sprite = rottenSprite;
                this.gameObject.tag = "Untagged";///CHANGE TAG SO REX CANT EAT

            }
        }
    }
}
