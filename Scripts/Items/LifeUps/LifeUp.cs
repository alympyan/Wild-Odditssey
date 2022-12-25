using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{ 
public class LifeUp : MonoBehaviour
{
  
    [Header("Sprites and More")]
    [SerializeField] SpriteRenderer lifeSR;
    [SerializeField] GUIUpdater guiUp;




    [Header("Vars And Values")]
    [SerializeField] float lifeAmount;
    [SerializeField] bool animateStarted;
    [SerializeField] Vector3 animatePos;
    [SerializeField] bool pickedUp;
        [SerializeField] bool playingAnim;

    // Start is called before the first frame update
    void Start()
    {
        lifeSR = GetComponent<SpriteRenderer>();
            guiUp = FindObjectOfType<GUIUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
            if (playingAnim == false)
            {
                StartCoroutine(Anim());
            }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && pickedUp == false)
        {
                pickedUp = true;
            AttaHealth attaLife = collision.GetComponent<AttaHealth>();
            LifeAdd(attaLife);
        }
    }

    void LifeAdd(AttaHealth attaHealthScript)
    {
        attaHealthScript.lifeCurrent += lifeAmount;
        ///Future Particle
        lifeSR.color = Color.green;
        guiUp.addLifeAnim = true;
        StartCoroutine(LifeDestroy());
    }


        IEnumerator Anim()
        {
            playingAnim = true;
            transform.position = transform.position + new Vector3(0, .1f);
            yield return new WaitForSeconds(.5f);
            transform.position = transform.position - new Vector3(0, .1f);
            yield return new WaitForSeconds(.5f);
            playingAnim = false;
        }

    IEnumerator LifeDestroy()
    {
            
        yield return new WaitForSeconds(.3f);
        Destroy(this.gameObject);
    }
}
}

