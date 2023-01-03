using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class WandFireball : MonoBehaviour
    {
        [SerializeField] float lifeTimer;
        [SerializeField] bool destroyState;
        [SerializeField] public bool lightState;
        [SerializeField] public Animator myAnim;
        [SerializeField] Rigidbody2D myRig;
        [SerializeField] AudioSource myAud;
        [SerializeField] int dmgTo;

        // Start is called before the first frame update
        void Start()
        {
            myAnim = GetComponent<Animator>();
            myRig = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            lifeTimer -= Time.deltaTime;
            Physics2D.SyncTransforms();
            if (lifeTimer <= 0 )
            {
                myAnim.SetBool("Death", true);
            }
            if(lightState == true)
            {
                myRig.constraints = RigidbodyConstraints2D.FreezeAll;
                myRig.velocity = Vector2.zero;
                lifeTimer = 1;
                myAnim.SetBool("Death", true);
            }
        }

        void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}
