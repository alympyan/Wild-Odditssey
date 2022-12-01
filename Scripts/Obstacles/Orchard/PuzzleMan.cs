using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AwesomsseyEngine
{
    public class PuzzleMan : MonoBehaviour
    {

        /// <summary>
        /// Class Controls Wall Puzzles and Deletions
        /// </summary>
        /// 

        [SerializeField] GameObject[] wallsToDelete;
        [SerializeField] float numberOfWalls;
        [SerializeField] public bool wallDownMode;
       
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(wallDownMode == true)
            {
                for (int i = 0; i < wallsToDelete.Length; i++)
                {
                    Destroy(wallsToDelete[i]);
                }
            }
        }
    }
}
