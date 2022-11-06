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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == ("Player"))
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
    }
    

}