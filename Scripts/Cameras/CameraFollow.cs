using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] GameObject mainCam;
        [SerializeField] GameObject attaObj;
        [SerializeField] PlayerMove playerObj;
        [SerializeField] public Vector3 levelOffSet;
        [SerializeField] LevelGuide levelGuide;
        [SerializeField] bool followPlat;
        [SerializeField] GameObject platObj;
        [SerializeField] CinemachineVirtualCamera myCM;

        // Start is called before the first frame update
        void Start()
        {
            playerObj = FindObjectOfType<PlayerMove>();
            if(GetComponentInChildren<CinemachineVirtualCamera>() == null)
            {
                myCM = null;
            }
            myCM = GetComponentInChildren<CinemachineVirtualCamera>();
           
        }

        // Update is called once per frame
        void Update()
        {
            if (myCM != null)
            {
                myCM.Follow = playerObj.transform;
            }
            if (followPlat == false)
            {
                //this.transform.position = playerObj.transform.position + new Vector3(0, .5f, -10) + levelOffSet;
               

            }
            if(followPlat == true)
            {
                this.transform.position = platObj.transform.position + new Vector3(0, .5f, -10) + levelOffSet;
            }

            //playerObj = FindObjectOfType<PlayerMove>();
            levelGuide = FindObjectOfType<LevelGuide>();
           
        }


        private void FixedUpdate()
        {
            //this.transform.position = playerObj.transform.position + new Vector3(0, .5f, -10) + levelOffSet;
        }

        private void LateUpdate()
        {
            //print("camera follow late");
           this.transform.position = playerObj.transform.position + new Vector3(0, .5f, -10) + levelOffSet;
        }
    }

}