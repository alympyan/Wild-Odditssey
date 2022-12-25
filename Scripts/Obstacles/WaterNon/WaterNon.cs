using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class WaterNon : MonoBehaviour
    {
        [SerializeField] float delayTimer;
        [SerializeField] float ogTimer;
        [SerializeField] bool splashed;
        [SerializeField] bool toggleTimer;
        [SerializeField] bool dmgPlayerMode;
        [SerializeField] Vector2 playerPos;
        [SerializeField] AttaHealth attHealth;
        [SerializeField] GameObject splashObj;
        [SerializeField] GameObject splashPart;
        [SerializeField] Animator splashAnim;
        [SerializeField] Animation splashPlay;
        [SerializeField] Rigidbody2D playerRig;

        // Start is called before the first frame update
        void Start()
        {
            ogTimer = delayTimer;
           
        }

        // Update is called once per frame
        void Update()
        {
            if(splashed == true)
            {
                delayTimer -= Time.deltaTime;
            }
            if(delayTimer <= 0 )
            {
                delayTimer = ogTimer;
                dmgPlayerMode = true;
                splashed = false;

            }
            if(dmgPlayerMode == true)
            {
                attHealth.currentPlayerHealth = 0;
                
                dmgPlayerMode = false;
                //playerRig.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                print("splash");
                splashed = true;
                playerPos = collision.transform.position;
                attHealth = collision.GetComponent<AttaHealth>();
                splashPart =  Instantiate(splashObj, playerPos, transform.rotation);
                splashAnim = splashPart.GetComponent<Animator>();
                splashPlay = splashPart.GetComponent<Animation>();
                splashPlay.wrapMode = WrapMode.Once;
                splashAnim.SetBool("Splash",true);
                playerRig = collision.GetComponent<Rigidbody2D>();
                playerRig.constraints = RigidbodyConstraints2D.FreezePosition;
                splashPlay.Play();

            }
        }
    }
}
