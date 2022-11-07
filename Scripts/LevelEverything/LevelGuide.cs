using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class LevelGuide : MonoBehaviour
    {
        [SerializeField] GameObject attaPlayer;
        [SerializeField] PlayerMove playerMove;
        [SerializeField] Vector3 playerStartPos;
        [SerializeField] Vector3 cameraOffSetLevel;
        [SerializeField] Camera pixelCamera;///MANUALLY SET EACH LAND
        [SerializeField] CameraFollow cameraFollow;
        


        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            playerMove.transform.position = playerStartPos;
            cameraFollow = pixelCamera.GetComponent<CameraFollow>();
            cameraFollow.levelOffSet = cameraOffSetLevel;///SET LEVEL CAMERA OFFSET
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
