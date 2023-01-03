using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class SwitchLevel : MonoBehaviour
    {
        [SerializeField] CartMovingPlat cartPlatA;
        [SerializeField] CartMovingPlat cartPlatB;
        [SerializeField] Rigidbody2D myRig;
        [SerializeField] SpriteRenderer mySR;
        [SerializeField] Sprite switchA;
        [SerializeField] Sprite switchB;
        [SerializeField] public bool switchModeA;
        [SerializeField] public bool switchModeB;

        // Start is called before the first frame update
        void Start()
        {
            mySR = GetComponent<SpriteRenderer>();
            myRig = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

            switchModeA = cartPlatA.aSwitch;
            switchModeB = cartPlatA.bSwitch;

            if(switchModeA == true)
            {
                mySR.sprite = switchA;
            }
            if (switchModeB == true)
            {
                mySR.sprite = switchB;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "TailKiss" && cartPlatA.homeSwitch == true && cartPlatA.movingState == false && cartPlatA.aSwitch == false) ///Turn A On
            {
                print("wayA tail Hit");
                cartPlatA.aSwitch = true;
                cartPlatA.bSwitch = false;
            }
            else if (collision.tag == "TailKiss" && cartPlatA.homeSwitch == true && cartPlatA.movingState == false && cartPlatA.bSwitch == false) /// Turn B On
            {
                print("wayB tail Hit");
                cartPlatA.bSwitch = true;
                cartPlatA.aSwitch = false;
            }
        }
    }
}
