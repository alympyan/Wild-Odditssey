using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class MagicFirePot : MonoBehaviour
    {
        [SerializeField] int magicToAdd;
        [SerializeField] Rigidbody2D myRig;
        [SerializeField] Animator myAnim;
        [SerializeField] BoxCollider2D myBox;
        [SerializeField] AudioSource myAud;
        [SerializeField] SpriteRenderer mySR;
        [SerializeField] Sprite flasSprite;
        [SerializeField] Sprite normalSprite;
        [SerializeField] float startFlashTime;
        [SerializeField] bool canGrab;
        [SerializeField] bool grabbed;
        [SerializeField] CarnevileContext carnScript;


        // Start is called before the first frame update
        void Start()
        {
            myBox = GetComponent<BoxCollider2D>();
            myAnim = GetComponent<Animator>();
            myAud = GetComponent<AudioSource>();
            mySR = GetComponent<SpriteRenderer>();
            StartCoroutine(StartFlash());

        }

        // Update is called once per frame
        void Update()
        {
            if(canGrab == false)
            {
                myBox.enabled = false;
            }
            if (canGrab == true)
            {
                myBox.enabled = true;
            }
            
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player" && grabbed == false && canGrab == true)
            {
                carnScript = collision.GetComponent<CarnevileContext>();

                StartCoroutine(StartFlash2());

            }
        }

        IEnumerator StartFlash()
        {
            canGrab = false;
            mySR.sprite = flasSprite;
            yield return new WaitForSeconds(startFlashTime);
            mySR.sprite = normalSprite;
            canGrab = true;
        }

        IEnumerator StartFlash2()///Use For Pickup
        {
            grabbed = true;
            canGrab = false;
            mySR.sprite = flasSprite;
            carnScript.shotAmount += magicToAdd;
            yield return new WaitForSeconds(startFlashTime);
            mySR.sprite = normalSprite;
            Destroy(gameObject);
        }
    }
}
