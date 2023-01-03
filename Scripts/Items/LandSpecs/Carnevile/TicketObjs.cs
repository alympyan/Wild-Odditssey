using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class TicketObjs : MonoBehaviour
    {
        [SerializeField] BoxCollider2D myBox;
        [SerializeField] GameObject ticketObj; ///Change colors
        [SerializeField] GameObject ticketSpawn;
        [SerializeField] Animator myAim;
        [SerializeField] AudioSource myAud;
        [SerializeField] SpriteRenderer mySR;
        [SerializeField] Sprite flasSprite;
        [SerializeField] Sprite normalSprite;
        [SerializeField] bool canGrab;
        [SerializeField] float startFlashTime;
        [SerializeField] bool grabbed;
        [SerializeField] CarnGUI carnGui;
        [SerializeField] CarnevileContext carnScript;


        // Start is called before the first frame update
        void Start()
        {
            myBox = GetComponent<BoxCollider2D>();
            myAud = GetComponent<AudioSource>();
            myAim = GetComponent<Animator>();
            mySR = GetComponent<SpriteRenderer>();
            carnGui = FindObjectOfType<CarnGUI>();
            StartCoroutine(StartFlash());

        }

        // Update is called once per frame
        void Update()
        {
            if (canGrab == false)
            {
                myBox.enabled = false;
            }
            if (canGrab == true)
            {
                myBox.enabled = true;
            }
            if(grabbed == true)
            {
                Destroy(gameObject);
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player" && grabbed == false)
            {
                grabbed = true;
                canGrab = false;
                carnScript = collision.GetComponent<CarnevileContext>();
                carnScript.ticketCount += 1;
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
    }
}
