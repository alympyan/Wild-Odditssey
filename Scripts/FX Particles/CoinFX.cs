using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AwesomsseyEngine
{
    public class CoinFX : MonoBehaviour
    {
        [SerializeField] float lifeTime;
        [SerializeField] ParticleSystem coinPart;


        // Start is called before the first frame update
        void Start()
        {
            coinPart = GetComponent<ParticleSystem>();
            lifeTime = coinPart.duration ;
        }

        // Update is called once per frame
        void Update()
        {
            //lifeTime = coinPart.duration;

            lifeTime -= Time.deltaTime;

            if(lifeTime <= 0 )
            {
                Destroy(gameObject);
            }
        }
    }

}