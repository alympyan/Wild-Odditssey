using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class RexWayPoint : MonoBehaviour
    {

       // [SerializeField] bool wayA;
        [SerializeField] bool wayB;
        [SerializeField] bool wayC;
        [SerializeField] bool wayD;
        [SerializeField] bool wayE;
        [SerializeField] bool wayF;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.name.Contains("Rex"))
            {
                RexBase rex = collision.GetComponent<RexBase>();
                if(wayB)
                {
                    rex.wayBbool = true;
                }
                if (wayC)
                {
                    rex.wayCbool = true;
                }
                if (wayD)
                {
                    rex.wayDbool = true;
                }
                if (wayE)
                {
                    rex.wayEbool = true;
                }
                if (wayF)
                {
                    rex.wayFbool = true;
                }
            }
        }
    }
}
