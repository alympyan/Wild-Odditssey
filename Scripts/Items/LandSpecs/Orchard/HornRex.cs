using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class HornRex : MonoBehaviour
    {
        [SerializeField] RexBase rexBase;
        [SerializeField] BoxCollider2D box;
        [SerializeField] bool collected;
        [SerializeField] bool partPlay;
        [SerializeField] ParticleSystem part;
        [SerializeField] float delayTime;
        [SerializeField] AudioSource audio;


        // Start is called before the first frame update
        void Start()
        {
            rexBase = FindObjectOfType<RexBase>();
            box = GetComponent<BoxCollider2D>();
            part = GetComponent<ParticleSystem>();
            audio = GetComponent<AudioSource>();
        }


        // Update is called once per frame
        void Update()
        {
            if(collected == true && partPlay == false)
            {
                StartCoroutine(PlayPart());
            }
        }

        IEnumerator PlayPart()
        {
            partPlay = true;
            part.Play();
            ///Play Audio Future -- Horn Sound
            yield return new WaitForSeconds(part.duration);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player" && collected == false)
            {
                if (rexBase != null)///Ensure when Deleted No Null 
                {
                    if (rexBase.hornSounded == false)
                    {
                        rexBase.hornSounded = true;

                        collected = true;
                    }
                }
            }
        }
    }
}
