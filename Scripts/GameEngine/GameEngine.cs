using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OdditsseyEngine
{
    public class GameEngine : MonoBehaviour
    {

        [SerializeField] float money;
        [SerializeField] GameObject attPlayer;
        [SerializeField] PlayerMove playerMove;
        [SerializeField] GameObject gameEngine;
        [SerializeField] bool playerLoaded;

        private void Awake()
        {
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("GameEngine");
            GameObject[] attObj = GameObject.FindGameObjectsWithTag("Player");

            if(gameObject.Length > 1)
            {
                Destroy(gameObject[1]);
                playerLoaded = true;
            }
            if (attObj.Length > 1)
            {
                Destroy(attObj[1]);
            }

            if (playerLoaded == false)
            {
                Instantiate(attPlayer, transform.position, transform.localRotation);
                playerLoaded = true;
            }
            playerMove = FindObjectOfType<PlayerMove>();
        }


        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(playerMove.gameObject);
            DontDestroyOnLoad(this.gameObject);
           
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
