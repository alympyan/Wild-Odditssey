using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class LuckySandsBase : MonoBehaviour
    {

        /// <summary>
        /// CLASS controls LuckySand Items
        /// </summary>

        [Header("Sand Options")] 
        [SerializeField] float jumpAddCount;
        [SerializeField] bool yelllowSand;
        [SerializeField] bool blueSand;
        [SerializeField] bool redSand;
        [SerializeField] bool greenSand;
        [SerializeField] bool bowSand;
        [SerializeField] AudioSource sandAudio;
        [SerializeField] SpriteRenderer sandSR;
        [SerializeField] Rigidbody2D sandRig;
        [SerializeField] BoxCollider2D sandBox;
        
        //[SerializeField] GameObject fxJump;


        // Start is called before the first frame update
        void Start()
        {
            sandAudio = GetComponent<AudioSource>();
            sandBox = GetComponent<BoxCollider2D>();
            sandRig = GetComponent<Rigidbody2D>();
            sandSR = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == ("Player"))
            {
                LuckyJump playerLucky = collision.gameObject.GetComponent<LuckyJump>();
                sandAudio.Play();
                JumpColorSet(playerLucky);///SET COLOR FIRST!!!!
                AddLuckyJumps(playerLucky);
            }
        }


        void JumpColorSet()
        {
            if(yelllowSand == true)
            {

            }
        }

        void AddLuckyJumps(LuckyJump luckyJump)
        {
            sandAudio.Play();
            luckyJump.luckyJumpMode = true;
            luckyJump.luckJMAX = jumpAddCount;
            luckyJump.luckJCount += jumpAddCount;
            JumpColorSet();
            sandSR.enabled = false;
            SpriteRenderer[] childSR = sandSR.GetComponentsInChildren<SpriteRenderer>();
            childSR[1].enabled = false;
            sandBox.enabled = false;
            sandRig.isKinematic = true;
            StartCoroutine(PlayBottleSound());

            
        }


        IEnumerator PlayBottleSound()
        {
            
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);

        }

        void JumpColorSet(LuckyJump luckyJump)
        {
            if (blueSand == true)
            {
                luckyJump.blueJump = true;
                luckyJump.greenJump = false;
                luckyJump.redJump = false;
                luckyJump.yellowJump = false;
                luckyJump.bowJump = false;
            }
            if (yelllowSand == true)
            {
                luckyJump.blueJump = false;
                luckyJump.greenJump = false;
                luckyJump.redJump = false;
                luckyJump.yellowJump = true;
                luckyJump.bowJump = false;
            }
            if (redSand == true)
            {
                luckyJump.blueJump = false;
                luckyJump.greenJump = false;
                luckyJump.redJump = true;
                luckyJump.yellowJump = false;
                luckyJump.bowJump = false;
            }
            if (greenSand == true)
            {
                luckyJump.blueJump = false;
                luckyJump.greenJump = true;
                luckyJump.redJump = false;
                luckyJump.yellowJump = false;
                luckyJump.bowJump = false;
            }
            if (bowSand == true)
            {
                luckyJump.blueJump = false;
                luckyJump.greenJump = false;
                luckyJump.redJump = false;
                luckyJump.yellowJump = false;
                luckyJump.bowJump = true;
            }
        }
    }
}
