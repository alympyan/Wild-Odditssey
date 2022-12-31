using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class WandFireball : MonoBehaviour
    {
        [SerializeField] float lifeTimer;
        [SerializeField] bool destroyState;
        [SerializeField] bool lightState;
        [SerializeField] Animator myAnim;
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

        }
    }
}
