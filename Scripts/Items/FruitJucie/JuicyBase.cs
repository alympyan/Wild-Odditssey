using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// CLASS controls Jucy Health Item
    /// </summary>
    public class JuicyBase : MonoBehaviour
    {

        [Header("Vars And Values")]
        [SerializeField] float healthAmount;
        [SerializeField] bool animateStarted;
        [SerializeField] Vector3 animatePos;
        [SerializeField] BoxCollider2D jucyBox;
        [SerializeField] SpriteRenderer jucySR;
        [SerializeField] Sprite jucyFlashSprite;
        [SerializeField] Sprite jucyNonFlashSprite;
        [Header("Options")]
        [SerializeField] float startTimer;
        [SerializeField] bool spawnedFirst;

        private void Awake()
        {
            jucyBox = GetComponent<BoxCollider2D>();
            jucySR = GetComponent<SpriteRenderer>();
            StartCoroutine(Flash());
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == ("Player") && spawnedFirst == true)
            {
                AttaHealth attaHealth = collision.GetComponent<AttaHealth>();
                AddHealth(attaHealth);
            }
        }


        void AddHealth(AttaHealth attaHealthScript)
        {
            attaHealthScript.currentPlayerHealth += healthAmount;
            ///FUTURE PARTICLE
            Destroy(gameObject);
        }

        IEnumerator Flash()
        {
            jucyBox.enabled = false;
            jucySR.sprite = jucyFlashSprite;
            yield return new WaitForSeconds(.5f);
            jucyBox.enabled = true;
            jucySR.sprite = jucyNonFlashSprite;
            spawnedFirst = true;
        }
    }
    

}