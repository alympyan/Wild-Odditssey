using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// Class Controls Atta's Collisions 
    /// </summary>
    public class AttaCollisions : MonoBehaviour
    {
        [Header("COmp")]
        [SerializeField] Rigidbody2D attaRig;
        [SerializeField] SpriteRenderer attaSR;
        [SerializeField] AudioSource attaAudio;
        [SerializeField] BoxCollider2D attaBox;
        [SerializeField] CapsuleCollider2D attaCap;


        // Start is called before the first frame update
        void Start()
        {
            attaRig = GetComponent<Rigidbody2D>();
            attaSR = GetComponent<SpriteRenderer>();
            attaAudio = GetComponent<AudioSource>();
            attaBox = GetComponent<BoxCollider2D>();
            attaCap = GetComponent<CapsuleCollider2D>();

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
