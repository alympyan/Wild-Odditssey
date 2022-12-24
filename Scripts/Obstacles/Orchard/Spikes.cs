using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField] int dmgToPlayer;
        [SerializeField] AttaCollisions attaCol;
        [SerializeField] AttaHealth attaHealth;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                attaCol = collision.gameObject.GetComponent<AttaCollisions>();
                attaHealth = collision.gameObject.GetComponent<AttaHealth>();
                if(attaCol.hitState == false)
                {
                    attaCol.hitState = true;
                    attaHealth.currentPlayerHealth -= dmgToPlayer;

                }
            }
        }
    }
}
