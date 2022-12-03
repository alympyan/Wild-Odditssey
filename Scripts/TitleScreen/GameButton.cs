using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class GameButton : MonoBehaviour
    {

        [SerializeField] BaseEventData m_BaseData;
        [SerializeField] Button myButton;
        [SerializeField] Image myImage;
        [SerializeField] SpriteRenderer mySR;
        [SerializeField] Sprite buttonClicked;
        [SerializeField] Sprite buttonIdle;
        [SerializeField] Sprite buttonHover;
        [SerializeField] bool cursorOn;
        [SerializeField] public bool startButton;
        [SerializeField] bool exitButton;

        // Start is called before the first frame update
        void Start()
        {
            //myButton = GetComponent<Button>();
            mySR = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
           
            if(cursorOn == true && Input.GetButton("Submit"))
            {
                if(startButton == true)
                {
                    mySR.sprite = buttonClicked;
                    StartCoroutine(DelayButton());
                }
                if (exitButton == true)
                {
                    mySR.sprite = buttonClicked;
                    StartCoroutine(DelayExit());
                }

            }

            
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            GameCursor gameCusror = collision.GetComponent<GameCursor>();
            if(collision.name.Contains("Cursor"))
            {
                print("cursor on");
                cursorOn = true;
                mySR.sprite = buttonHover;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            GameCursor gameCusror = collision.GetComponent<GameCursor>();
            if (collision.name.Contains("Cursor"))
            {
                cursorOn = false;
                mySR.sprite = buttonIdle;
            }
        }

        public void OnSelect(BaseEventData baseData)
        {
            //print("High");
            

        }

      

        private void OnGUI()
        {
           
        }

        IEnumerator DelayButton()
        {
            yield return new WaitForSeconds(.5f);
            LoadNewGame();
        }

        IEnumerator DelayExit()
        {
            print("Yoyo");
            yield return new WaitForSeconds(.5f);
            Application.Quit();
        }

        public void LoadNewGame()
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            
        }
       
    }
}
