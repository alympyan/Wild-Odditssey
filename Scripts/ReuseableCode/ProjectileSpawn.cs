using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AwesomsseyEngine
{

    /// <summary>
    /// CLASS Controls Basic Spawn Props, like lifeTimers
    /// </summary>
    public class ProjectileSpawn : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField] float lifeTimer;
        [SerializeField] bool particleSysOn;
        [SerializeField] bool isPlaying;
        [SerializeField] float damageToPlayer;

        [Header("Comp")]
        [SerializeField] Animator projAnim;
        [SerializeField] Rigidbody2D projRig;
        [SerializeField] BoxCollider2D projBox;
        [SerializeField] AudioSource projAudio;
        [SerializeField] ParticleSystem projPart;
        [SerializeField] SpriteRenderer projSR;


        // Start is called before the first frame update
        void Start()
        {
            projAnim = GetComponent<Animator>();
            projAudio = GetComponent<AudioSource>();
            projBox = GetComponent<BoxCollider2D>();
            projRig = GetComponent<Rigidbody2D>();
            projPart = GetComponent<ParticleSystem>();
            projSR = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            lifeTimer -= Time.deltaTime;

            if(lifeTimer <0)
            {
                if (particleSysOn == false)///USE ANIMATIONS INSTEAD
                {
                    projAnim.SetBool("Death", true);
                }
                if(particleSysOn == true && isPlaying == false)///ENSURE PARTICLE SYSTEM IS ON
                {
                    StartCoroutine(ParticlePlay());
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                AttaHealth playerHealth = collision.GetComponent<AttaHealth>();
                AttaCollisions attaColl = collision.GetComponent<AttaCollisions>();
                if (attaColl.invulState == false)///ENSURE PLAYER IS NOT INVUL
                {
                    attaColl.hitState = true;
                    playerHealth.currentPlayerHealth -= damageToPlayer;
                    print("atta flicker is Coroutine Before");
                    //StartCoroutine(attaColl.FlickerAtta());
                    print("atta flicker is Coroutine Start");
                    //attaColl.invulState = true;
                    ///TOGGLES FOR ANIMATION OR PARTICLE DEATH
                    if (particleSysOn == true)
                    {
                        StartCoroutine(ParticlePlay());
                    }
                    if(particleSysOn == false)///ENSURE COLLIDERS ARE DISABLED
                    {
                        projAnim.SetBool("Death", true);
                        projRig.isKinematic = true;
                        projRig.constraints = RigidbodyConstraints2D.FreezeAll;
                        projBox.enabled = false;
                        projSR.enabled = false;
                    }
                }
                ///Future FLICKER ON PLAYER CODE
            }
        }

        IEnumerator ParticlePlay()
        {
            isPlaying = true;
            projSR.enabled = false;
            print("Proj particlePlay");
            projPart.Play();
            projRig.isKinematic = true;
            projRig.constraints = RigidbodyConstraints2D.FreezeAll;
            projBox.enabled = false;
            yield return new WaitForSeconds(.4f);
            Destroy(this.gameObject);
        }

        void DestroyProj()
        {
            Destroy(this.gameObject);
            
        }
    }

}