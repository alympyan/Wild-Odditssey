using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class Splash : MonoBehaviour
    {
        [SerializeField] float lifeTimer;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            lifeTimer -= Time.deltaTime;
            if(lifeTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
