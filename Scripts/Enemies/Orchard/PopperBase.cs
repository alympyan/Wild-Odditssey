using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AwesomsseyEngine
{
    public class PopperBase : MonoBehaviour
    {
        [SerializeField] BoxCollider2D popBox;
        [SerializeField] AudioSource popAudio;
        [SerializeField] Rigidbody2D popRig;
        [SerializeField] SpriteRenderer popSR;
        [SerializeField] Animator popAnim;
        [SerializeField] ParticleSystem popPart;

        [SerializeField] float seedSpeed;
        [SerializeField] float seedShotTimer;
        [SerializeField] RaycastHit2D detectRay;
        [SerializeField] Vector2 rayOffsetX;
        [SerializeField] bool partIsPlaying;
        [SerializeField] bool partPlayed;
        [SerializeField] float popHealth;
        [SerializeField] GameObject spawnObj;
        [SerializeField] GameObject spawnedGrass;
        



        // Start is called before the first frame update
        void Start()
        {
            popAudio = GetComponent<AudioSource>();
            popSR = GetComponent<SpriteRenderer>();
            popAnim = GetComponent<Animator>();
            popPart = GetComponent<ParticleSystem>();

        }

        // Update is called once per frame
        void Update()
        {
            if (popSR.flipX == true)
            {
                transform.right = new Vector3(-1, 0);
                rayOffsetX = new Vector2(-1.1f, .5f);
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }

            if (popSR.flipX == false)
            {
                transform.right = new Vector3(1, 0);
                rayOffsetX = new Vector2(2f, .5f);
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }


            detectRay = Physics2D.Raycast(rayOffsetX, transform.right, 2f);
            Debug.DrawRay(rayOffsetX, transform.right * 2f, Color.yellow);

            if(detectRay.collider == null)
            {
                popAnim.SetBool("Popup", false);
                partPlayed = false;
                //popPart.enableEmission = false;
            }

            if(detectRay.collider != null)
            {
                print("Popper ray is colliding + = " + detectRay.collider.gameObject + "Popper transformRigh is = " + transform.right);
                if(detectRay.collider.tag == ("Player"))
                {
                   
                    popAnim.SetBool("Popup", true);
                    if(partIsPlaying == false && partPlayed == false)
                    {
                        StartCoroutine(PlayGrass());
                    }
                    
                }

                else if(detectRay.collider.tag != ("Player"))
                {
                    popAnim.SetBool("Popup", false);
                    //popPart.enableEmission = false;
                }
            }
        }

        IEnumerator PlayGrass()
        {
            partIsPlaying = true;
            popPart.enableEmission = true;
            popPart.Play();
            yield return new WaitForSeconds(.5f);
            popPart.Stop();
            partIsPlaying = false;
            partPlayed = true;
        }
    }

}