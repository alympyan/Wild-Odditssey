using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class SeedBagBase : MonoBehaviour
    {
        /// <summary>
        /// Calss Controls SeedBags
        /// </summary>
        /// 

        [Header("Sprites and More")]
        [SerializeField] SpriteRenderer bagSR;
        [SerializeField] Sprite greenBagSprite;
        [SerializeField] Sprite blueBagSprite;
        [SerializeField] Sprite redBagSprite;

        [Header("Options")]
        [SerializeField] public bool greenSeeds;
        [SerializeField] public bool blueSeeds;
        [SerializeField] public bool redSeeds;

        [Header("Vars And Values")]
        [SerializeField] float ammoAmount;
        [SerializeField] bool animateStarted;
        [SerializeField] Vector3 animatePos;

        // Start is called before the first frame update
        void Start()
        {
            bagSR = GetComponent<SpriteRenderer>();
            ChangeSeedBag();///Set BAG TYPE AND AMOUNT AND SPRITE
        }

        // Update is called once per frame
        void Update()
        {
            ChangeSeedBag();///FOR SPAWNING ITEMS
            if(animateStarted == false)
            {
                StartCoroutine(AnimateBagTrans());
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == ("Player"))
            {
                GameObject attaCol = collision.gameObject;
                SeedShot attaSeeds = collision.gameObject.GetComponent<SeedShot>();
                AddAmmoAtta(attaSeeds);
            }
        }

        void ChangeSeedBag()
        {
            if(greenSeeds == true)
            {
                ammoAmount = 2f;
                bagSR.sprite = greenBagSprite;
            }
            if (blueSeeds == true)
            {
                ammoAmount = 4f;
                bagSR.sprite = blueBagSprite;
            }
            if (redSeeds == true)
            {
                ammoAmount = 8f;
                bagSR.sprite = redBagSprite;
            }
        }

        IEnumerator AnimateBagTrans()
        {
            animateStarted = true;
            transform.position += animatePos;
            yield return new WaitForSeconds(.5f);
            transform.position -= animatePos;
            yield return new WaitForSeconds(.5f);
            animateStarted = false;


        }

        void AddAmmoAtta(SeedShot attaSeedsBag) 
        {
            attaSeedsBag.seedAmmoCurrent += ammoAmount;
            ///Current Death
            Destroy(gameObject);
        }

        ///FUTURE PARTICLE SYSTEM
    }
}
