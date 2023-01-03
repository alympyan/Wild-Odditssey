using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class VanishPlat : MonoBehaviour
    {
        [SerializeField] float vanishTimer;
        [SerializeField] float vanishTimerOG;
        [SerializeField] bool vanishMode;/// Use for CoRoutine
        [SerializeField] bool vanishingState; ///use for State
        [SerializeField] bool vanishIn;
        [SerializeField] bool vanishOut;
        [SerializeField] BoxCollider2D myBox;
        [SerializeField] SpriteRenderer mySR;
        [SerializeField] float fadeDur;
        [SerializeField] bool fadeOut;
        [SerializeField] bool fadeIn;
        [SerializeField] bool startTimer;


        // Start is called before the first frame update
        void Start()
        {
            myBox = GetComponent<BoxCollider2D>();
            vanishTimerOG = vanishTimer;
            mySR = GetComponent<SpriteRenderer>();
            vanishOut = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(vanishingState == true && vanishOut == true)
            {
                //vanishTimer -= Time.deltaTime;
               
               
                
                    FadeOutFunc();
                 
                

            }

            if (vanishingState == true && vanishIn == true)
            {
                //vanishTimer -= Time.deltaTime;
               
               
                
                    FadeInFunc();


            }

            if(startTimer == true)
            {
                vanishTimer -= Time.deltaTime;
            }


            if (vanishTimer <= 0 && vanishOut == true )
            {
                
                fadeOut = false;
                vanishOut = false;
                vanishIn = true;
                startTimer = false;
                vanishingState = true;
                vanishMode = false;///Reset For Update Vanish
                vanishTimer = vanishTimerOG;
            }
            if (vanishTimer <= 0 && vanishIn == true)
            {
               
                fadeIn = false;
                vanishOut = true;
                vanishIn = false;
                startTimer = false;
                vanishingState = true;
                vanishMode = false;
                vanishTimer = vanishTimerOG;
            }
        }

   
        void FadeOutFunc()
        {
            fadeOut = true;
            float fadeAmout = mySR.color.a - (fadeDur * Time.deltaTime);
            mySR.color = new Color(mySR.color.r, mySR.color.g, mySR.color.b, fadeAmout);
            if(mySR.color.a <= 0)
            {
                myBox.enabled = false;
                //vanishOut = false;
                vanishMode = true;
                startTimer = true;
            }
        }

        void FadeInFunc()
        {
            fadeIn = true;
           
            //vanishMode = true;
            float fadeAmout = mySR.color.a + (fadeDur * Time.deltaTime);
            mySR.color = new Color(mySR.color.r, mySR.color.g, mySR.color.b, fadeAmout);
            if (mySR.color.a >= .5)
            {
                myBox.enabled = true;
                //vanishIn = false;
                vanishMode = true;
                startTimer = true;
            }
            if (mySR.color.a >= 1)
            {
                
                //vanishIn = false;
                vanishMode = true;
                startTimer = true;
            }
        }

    }
}
