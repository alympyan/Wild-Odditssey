using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using UnityEngine;

namespace AwesomsseyEngine
{

    /// <summary>
    /// Class controls Inventory Plus Hotbar system GUI
    /// Pulls from InvAtta - Atta is Data saved and loaded
    /// </summary>
    public class InventoryGlory : MonoBehaviour
    {
        [Header("Comp")]
        ///ACCESS TO IMAGE ON GUI NOT SRPITES
        [SerializeField] Image hotBarImage;
        [SerializeField] Image invSlot0;
        [SerializeField] Image invSlot1;
        [SerializeField] Image invSlot2;
        [SerializeField] Image invSlot3;
        [SerializeField] Image invSlot4;
        [SerializeField] InvAtta invAtta;
        ///SPRITES FOR IMAGES
        [SerializeField] Sprite hotBarSprite;
        [Header("Vars")]
        [SerializeField] GameObject hotBarItem;
        [SerializeField] GameObject item0;
        [SerializeField] GameObject item1;
        [SerializeField] GameObject item2;
        [SerializeField] GameObject item3;
        [SerializeField] GameObject item4;
        [SerializeField] GameObject item5;
        [Header("SpawnItem Options")]
        [SerializeField] GameObject itemToSpawn;
        [SerializeField] GameObject objectThatSpawned;
        [Header("Upgrades")]
        [SerializeField] bool noUpgrade; ///SAVE + LOAD
        [SerializeField] bool deepPockets; ///SAVE + LOAD
        [SerializeField] bool baggyPockets; ///SAVE + LOAD
        [Header("HotBar")]
        [SerializeField] GameObject hotBarPrep;
        





        // Start is called before the first frame update
        void Start()
        {
            invAtta = FindObjectOfType<InvAtta>();
        }

        // Update is called once per frame
        void Update()
        {
            ///Update Upgrades
            noUpgrade = invAtta.noUpgradeA;
            deepPockets = invAtta.deepPocketsA;
            baggyPockets = invAtta.baggyPocketsA;

            ///Udate Vars From InvAtta
            ///Check for Upgrades
            if (noUpgrade == true)
            {
                item0 = invAtta.item0A;
                item1 = invAtta.item1A;
            }
            if(deepPockets == true)
            {
                item0 = invAtta.item0A;
                item1 = invAtta.item1A;
                item2 = invAtta.item2A;
            }
            if (baggyPockets == true)
            {
                item0 = invAtta.item0A;
                item1 = invAtta.item1A;
                item2 = invAtta.item2A;
                item3 = invAtta.item3A;
            }

            hotBarItem = invAtta.hotBarPrepA;///PREP A IS HOTBAR ITEM
            if(invAtta.hotBarPrepA == null)///NULL CHECK DELETE IMAGE IF NULL
            {
                hotBarImage.enabled = false;
            }


            SpriteRenderer hotbarItemSR = hotBarItem.GetComponent<SpriteRenderer>();///GRAB HOTBARITEM
            Sprite hotBarSprite = hotbarItemSR.sprite;
            hotBarImage.sprite = hotBarSprite;
            hotBarImage.enabled = true;
            hotBarImage.rectTransform.sizeDelta = new Vector2(81.6699f, 69.6106f);
        }


       
    }
}
