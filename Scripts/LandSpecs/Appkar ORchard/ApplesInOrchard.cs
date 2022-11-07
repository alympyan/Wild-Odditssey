using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class ApplesInOrchard : MonoBehaviour
    {
        [SerializeField] Rigidbody2D appleRig;
        // Start is called before the first frame update
        void Start()
        {
            appleRig = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == ("Platforms"))
            {
                appleRig.velocity = new Vector2(appleRig.velocity.x, 0);
                appleRig.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }
}
