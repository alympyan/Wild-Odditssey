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

        // Start is called before the first frame update
        void Start()
        {
            mainCam = FindObjectOfType<Camera>();

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == ("Player"))
            {
                //attaObj = collision.gameObject;
                //mainCam.transform.position = warpPoint.transform.position + new Vector3(0, 0, -10);
               // attaObj.transform.position = warpPoint.transform.position;
                SceneManager.LoadSceneAsync(sceneIndex);
            }
        }

    }
}