using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OdditsseyEngine
{
    public class LevelCast : MonoBehaviour
    {
        [SerializeField] RaycastHit2D[] sphereCast;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            sphereCast = Physics2D.CircleCastAll(transform.position, 10, Vector2.up);
            if(sphereCast != null)
            {
                print("CircleCast Hit = = " + sphereCast[0].transform.gameObject.tag + sphereCast[1].transform.gameObject.tag);
            }
            
        }
    }
}
