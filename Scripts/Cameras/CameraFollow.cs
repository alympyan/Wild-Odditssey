using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OdditsseyEngine
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] GameObject mainCam;
        [SerializeField] GameObject attaObj;
        [SerializeField] PlayerMove playerObj;

        // Start is called before the first frame update
        void Start()
        {
            playerObj = FindObjectOfType<PlayerMove>();
           
        }

        // Update is called once per frame
        void Update()
        {
            //playerObj = FindObjectOfType<PlayerMove>();
            this.transform.position = playerObj.transform.position + new Vector3(0,.5f,-10);
        }
    }

}