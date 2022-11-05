using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OdditsseyEngine
{
    public class LevelGuide : MonoBehaviour
    {
        [SerializeField] GameObject attaPlayer;
        [SerializeField] PlayerMove playerMove;
        [SerializeField] Vector3 playerStartPos;
        


        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            playerMove.transform.position = playerStartPos;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
