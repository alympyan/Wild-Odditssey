using System.Collections;
using System.Collections.Generic;
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

        // Start is called before the first frame update
        void Start()
        {
            playerObj = FindObjectOfType<PlayerMove>();
           
        }

        // Update is called once per frame
        void Update()
        {
            //playerObj = FindObjectOfType<PlayerMove>();
            levelGuide = FindObjectOfType<LevelGuide>();
            this.transform.position = playerObj.transform.position + new Vector3(0,.5f,-10) + levelOffSet;
        }
    }

}