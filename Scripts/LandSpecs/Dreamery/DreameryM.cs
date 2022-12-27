using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class DreameryM : MonoBehaviour
    {
        [SerializeField] GameEngine gameEngine;
        [SerializeField] KladderWarp odditWarp;
        [SerializeField] CartObj[] cart;
        [SerializeField] public string sceneToLoad;
        [SerializeField] public Vector2 cartPos;
        [SerializeField] public bool cartInserted;
        [SerializeField] Animator myAnim;

        // Start is called before the first frame update
        void Start()
        {
            gameEngine = FindObjectOfType<GameEngine>();
            odditWarp = FindObjectOfType<KladderWarp>();
            myAnim = GetComponent<Animator>();
            
        }

        // Update is called once per frame
        void Update()
        {
            if(cartInserted == true)
            {
                cart = GetComponentsInChildren<CartObj>();
                sceneToLoad = cart[0].sceneCart;///Should Always Be 0
                odditWarp.sceneStringOdd = sceneToLoad;
                odditWarp.activatePort = true;
                myAnim.SetBool("Activate", true);
                
            }
            if (cartInserted == false)
            {
                sceneToLoad = null;
                odditWarp.activatePort = false;
                odditWarp.sceneStringOdd = sceneToLoad;///Null Check
                myAnim.SetBool("Activate", false);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name.Contains("Cart") && cartInserted == false)
            {
              
               
                
            }
        }
    }

}