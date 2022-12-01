using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Class Controls Invetory Data for Atta
/// This saves and loads data and feeds to InventoryGlory
/// </summary>

namespace AwesomsseyEngine
{
    public class InvAtta : MonoBehaviour
    {
        ///SPRITES FOR IMAGES
        [SerializeField] Sprite hotBarSprite;
        [Header("Vars")]
        [SerializeField] public GameObject hotBarItemA;///SAVE + LOAD
        [SerializeField] public GameObject item0A; ///SAVE + LOAD
        [SerializeField] public GameObject item1A; ///SAVE + LOAD
        [SerializeField] public GameObject item2A; ///SAVE + LOAD
        [SerializeField] public GameObject item3A; ///SAVE + LOAD
        [SerializeField] public GameObject item4A; ///SAVE + LOAD
        [SerializeField] public GameObject item5A; ///SAVE + LOAD
        [Header("Upgrades")]
        [SerializeField] public bool noUpgradeA; ///SAVE + LOAD
        [SerializeField] public bool deepPocketsA; ///SAVE + LOAD
        [SerializeField] public bool baggyPocketsA; ///SAVE + LOAD
        [Header("HotBar")]
        [SerializeField] public GameObject hotBarPrepA;
        [SerializeField] int itemSlotMax;
        [SerializeField] int itemCurrentIndex; ///SAVE + LOAD
        [Header("Item Use")]
        [SerializeField] GameObject spawnedItem;
        [SerializeField] float dpadAxis;
        [SerializeField] RaycastHit2D[] wallDetectRay;
        [SerializeField] Vector3 rayOffsetRight;
        [SerializeField] Vector3 rayOffsetLeft;
        [SerializeField] bool colliding;
        [Header("Comp")]
        [SerializeField] PlayerMove playerMove; ///GET KLADDER BOOL STOPS PLAYER FROM SPAWNING ON LADDER
        [SerializeField] AttaItemBoxColl attaItemColl;///Box collider checks for clear space to spawn item - spawn item pos


        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            attaItemColl = FindObjectOfType<AttaItemBoxColl>();
        }

        // Update is called once per frame
        void Update()
        {
            if(noUpgradeA == true)
            {
                item2A = null;
                item3A = null;
                itemSlotMax = 1;
            }

            if (deepPocketsA == true && baggyPocketsA == false)
            {
               
                item3A = null;
                itemSlotMax = 2;

            }

            if (baggyPocketsA == true && deepPocketsA == true)///MAX Four Slots
            {
                itemSlotMax = 3;

            }
            hotBarItemA = hotBarPrepA;
            
            if (Input.GetButtonDown("CycleLeft"))
            {
                print("item pressed");
                itemCurrentIndex = itemCurrentIndex - 1;
                if(itemCurrentIndex < 0 )
                {
                    itemCurrentIndex = itemSlotMax;
                }
               
                print("item current index = " + itemCurrentIndex);
            }

            if (Input.GetButtonDown("CycleRight"))
            {
                print("item pressed");
                itemCurrentIndex = itemCurrentIndex + 1;
                if (itemCurrentIndex > itemSlotMax)
                {
                    itemCurrentIndex = 0;
                }

                print("item current index = " + itemCurrentIndex);
            }

            dpadAxis = Input.GetAxis("ItemUse");
            if(Input.GetAxis("ItemUse") < 0 && hotBarPrepA != null && playerMove.kladderOn == false && colliding == false)//&& attaItemColl.colliding == false
            {
                print("item use pressed");
                spawnedItem = Instantiate(hotBarPrepA, transform.position + transform.right, transform.rotation);
                HotBarDeleteItem();///DELETES ITEM
                //itemCurrentIndex = itemCurrentIndex + 1;
                //if(itemCurrentIndex >= itemSlotMax)
                //{
                   //itemCurrentIndex = 0;
                 
                //}

            }
            print("atta transform right = " + transform.right);
            if(transform.right == new Vector3(1,0,0))///Positive Rgiht Cast
            {
                print("atta transform ray is POSITIVE RAY OFFSET  = " + rayOffsetRight);
                wallDetectRay = Physics2D.RaycastAll(transform.position + rayOffsetRight, transform.right, .2f);
                Debug.DrawRay(transform.position + rayOffsetRight, transform.right * .2f, Color.green);
            }
            if (transform.right == new Vector3(-1, 0, 0)) ///Negative Left Cast
            {
                print("atta transform ray is NEGATIVE RAY OFFSET  = " + rayOffsetLeft);
                wallDetectRay = Physics2D.RaycastAll(transform.position - rayOffsetLeft, -transform.right, .2f);
                Debug.DrawRay(transform.position - rayOffsetLeft, -transform.right * .2f, Color.green);
            }
            
            WallDetection();
            HotBarSystem();
            HotBarNullCheck();
            
        }


        void WallDetection()
        {
           


            for (int i = 0; i < wallDetectRay.Length; i++)
            {
                print("wall detection tag is = " + wallDetectRay[i].collider.tag);
                if (wallDetectRay[i].collider.tag == "Platforms")
                {
                    colliding = true;
                    break;
                }
                else if (wallDetectRay[i].collider.tag == "Platforms")
                {
                    colliding = true;
                    break;
                }
                else if (wallDetectRay[i].collider.tag != "Platforms")
                { colliding = false; }
            }

           
            
        }


        void HotBarSystem()
        {
          if(itemCurrentIndex == 0 && item0A != null)
            {
                hotBarPrepA = item0A;
               
            }

            if (itemCurrentIndex == 1 && item1A != null)
            {
                hotBarPrepA = item1A;
            }
            if (itemCurrentIndex == 2 && item2A != null) ///3!
            {
                hotBarPrepA = item2A;
            }
            if (itemCurrentIndex == 3 && item3A != null)
            {
                hotBarPrepA = item3A;
            }
            if (itemCurrentIndex == 4 && item4A != null)
            {
                hotBarPrepA = item4A;
            }
            if (itemCurrentIndex == 5 && item5A != null)
            {
                hotBarPrepA = item5A;
            }

        }


        void HotBarNullCheck()
        {
            if (itemCurrentIndex == 0 && item0A == null)
            {
                hotBarPrepA = null;

            }
            if (itemCurrentIndex == 1 && item1A == null)
            {
                hotBarPrepA = null;

            }
            if (itemCurrentIndex == 2 && item2A == null)
            {
                hotBarPrepA = null;

            }
            if (itemCurrentIndex == 3 && item3A == null)
            {
                hotBarPrepA = null;

            }
        }

        void HotBarDeleteItem()
        {
            if (itemCurrentIndex == 0)
            {
               item0A = null;
            }
            if (itemCurrentIndex == 1 && item1A != null)
            {
                item1A = null;
            }
            if (itemCurrentIndex == 2 && item2A != null) ///3!
            {
                item2A = null;
            }
            if (itemCurrentIndex == 3 && item3A != null) ///4!!!
            {
                item3A = null;
            }
        
           
        }
    }
}
