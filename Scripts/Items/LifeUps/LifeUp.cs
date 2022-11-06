using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{ 
public class LifeUp : MonoBehaviour
{
  
    [Header("Sprites and More")]
    [SerializeField] SpriteRenderer lifeSR;




    [Header("Vars And Values")]
    [SerializeField] float lifeAmount;
    [SerializeField] bool animateStarted;
    [SerializeField] Vector3 animatePos;
        [SerializeField] bool pickedUp;

    // Start is called before the first frame update
    void Start()
    {
        lifeSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

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
        lifeSR.color = Color.magenta;
        StartCoroutine(LifeDestroy());
    }

    IEnumerator LifeDestroy()
    {
            
        yield return new WaitForSeconds(.3f);
        Destroy(this.gameObject);
    }
}
}

