using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OdditsseyEngine

{
    public class PlayerPickup : MonoBehaviour
    {
        [Header("Stored Objs")]

        [SerializeField] Rigidbody2D attaRig;
        [SerializeField] public  float appleNumbers;
        [SerializeField] bool objPicked;

        [Header("SCripts")]
        [SerializeField] AttaItemDsp itemDsp;
        [SerializeField] ContexButtons contexButtons;


        // Start is called before the first frame update
        void Start()
        {
            attaRig = GetComponent<Rigidbody2D>();
            itemDsp = FindObjectOfType<AttaItemDsp>();
            contexButtons = FindObjectOfType<ContexButtons>();
        }

        // Update is called once per frame
        void Update()
        {

        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == ("Apple") && objPicked == false && contexButtons.throwingState == false)
            {

                itemDsp.itemDspSR.sprite = itemDsp.appleSprite;

                GameObject appleObj = collision.gameObject;
                SpriteRenderer appleSR = collision.GetComponent<SpriteRenderer>();
                //appleSR.enabled = false;
                //appleObj.transform.SetParent(this.transform);
               // appleObj.transform.localPosition = new Vector3(0, 1);
               // appleObj.gameObject.tag = ("Player");
                //Rigidbody2D appleRig = collision.gameObject.GetComponent<Rigidbody2D>();
                //appleRig.isKinematic = true;
                appleNumbers += 1f;
                objPicked = true;

            }
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            objPicked = false;
        }
    }

}