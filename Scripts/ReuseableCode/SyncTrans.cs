using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class SyncTrans : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Physics2D.SyncTransforms();
        }

        private void LateUpdate()
        {
            Physics2D.SyncTransforms();
            this.transform.localPosition = this.transform.localPosition;
        }
    }

}