using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace AwesomsseyEngine
{


    public class KladderWarp : MonoBehaviour
    {
        [SerializeField] Camera mainCam;
        [SerializeField] Vector2 currentPos;
        [SerializeField] Vector3 nextWarpPOS;
        [SerializeField] GameObject attaObj;
        [SerializeField] GameObject warpPoint;
        [SerializeField] Scene nextScene;
        [SerializeField] int sceneIndex;
        [SerializeField] Vector3 warpPos;
        [SerializeField] Animator myAnim;
        
        [SerializeField] public string sceneStringOdd;
        [SerializeField] public bool activatePort;
        [SerializeField] public bool levelFinished; ///Future Use For End Of Level Portal Open
        [SerializeField] bool runningPort;

        // Start is called before the first frame update
        void Start()
        {
            //mainCam = FindObjectOfType<Camera>();
            myAnim = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {
            if(activatePort == true && runningPort == false)
            {
                myAnim.SetBool("Idle", false);
                myAnim.SetBool("Activate", true);
            }
            if (activatePort == false)
            {
                runningPort = false;
                myAnim.SetBool("Activate", false);
                myAnim.SetBool("Run", false);
                myAnim.SetBool("Idle", true);
            }
        }


        void RunPort()
        {
            runningPort = true;
            myAnim.SetBool("Run", true);
            myAnim.SetBool("Activate", false);
            myAnim.SetBool("Idle", false);
          
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == ("Player"))
            {
                //attaObj = collision.gameObject;
                //mainCam.transform.position = warpPoint.transform.position + new Vector3(0, 0, -10);
                // attaObj.transform.position = warpPoint.transform.position;
                //SceneManager.LoadSceneAsync(sceneIndex);
                PlayerMove player = collision.GetComponent<PlayerMove>();

                if (sceneStringOdd != null && player.kladderOn == true)
                {
                    SceneManager.LoadSceneAsync(sceneStringOdd);///Load By String From Odditssey
                }
            }
        }

    }
}