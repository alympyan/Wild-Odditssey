using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class PowerSeed : MonoBehaviour
    {
        /// <summary>
        /// Class Controls Seed Projectile
        /// </summary>
        /// 

        [Header("Options")]
        [SerializeField] public float seedSpeed;
        [SerializeField] public float seedDMG;
        [SerializeField] public bool powerSeed;
        [SerializeField] public bool deviSeeds;
        [SerializeField] public bool slappinSeeds;
        [SerializeField] float lifeTimer;

        [Header("Comp")]
        [SerializeField] public SpriteRenderer seedSR;


        [Header("Script")]
        [SerializeField] GameEngine gameEngine;
        /// <summary>
        /// FUTURE USE FOR PTS DISPLAY
        /// </summary>


        private void Awake()
        {
            seedSR = GetComponent<SpriteRenderer>();
        }

        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            lifeTimer -= Time.deltaTime;
            if(lifeTimer<= 0)
            {
                ///FITURE PLAY PARTICLE
                Destroy(gameObject);
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)///PROJECTILES TRIGGER SO BOX DONT PUSH OBJECTS
        {
            if(collision.tag == ("Enemy"))
            {
                ///FUTURE PARTICLE
            }
        }
    }

}