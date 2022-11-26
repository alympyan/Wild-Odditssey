using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AwesomsseyEngine
{
    public class CoinsBase : MonoBehaviour
    {
        /// <summary>
        /// Class Controls Coins - NOT ON ATTA PLAYER 
        /// CoinAInventory is on player
        /// </summary>
        /// 


        [Header("Sprites and More")]
        [SerializeField] SpriteRenderer coinSR;
        [SerializeField] Sprite greenBagSprite;
        [SerializeField] Sprite blueBagSprite;
        [SerializeField] Sprite redBagSprite;
        [SerializeField] ParticleSystem coinPart;
        [SerializeField] GameObject coinParticleObject;

        [Header("Options")]
        [SerializeField] public bool greenSeeds;
        [SerializeField] public bool blueSeeds;
        [SerializeField] public bool redSeeds;

        [Header("Vars And Values")]
        [SerializeField] float coinAmount;
        [SerializeField] bool animateStarted;
        [SerializeField] Vector3 animateRos;
        [SerializeField] float animateAngle;


        // Start is called before the first frame update
        void Start()
        {
            coinPart = GetComponent<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            AnimateCoinTrans();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == ("Player"))
            {
                CoinsAInventory coinsInv = collision.GetComponent<CoinsAInventory>();
                AddCoin(coinsInv);
            }
        }


        void AnimateCoinTrans()
        {
            transform.Rotate(animateRos, animateAngle);
        }

        void AddCoin(CoinsAInventory coinInvFunc)
        {
            coinInvFunc.coinsCurrent += coinAmount;
            Instantiate(coinParticleObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        ///FUTURE PARTICLE
    }
}
