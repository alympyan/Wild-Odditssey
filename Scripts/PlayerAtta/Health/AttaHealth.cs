using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class AttaHealth : MonoBehaviour
    {
        /// <summary>
        /// Clss handle Player Atta Health
        /// </summary>

        [Header("Health Vars")]
        [SerializeField] public float currentPlayerHealth; ///SAVE VAR
        [SerializeField] public float CurrentPlayerMaxHealth; ///SAVE VAR
        [Header("HealthUpgrades")]
        [SerializeField] public bool healthUP0; ///SAVE VAR
        [SerializeField] public bool healthUP1; ///SAVE VAR
        [SerializeField] public bool healthUP2; ///SAVE VAR
        [SerializeField] public bool healthUP3; ///SAVE VAR
        [SerializeField] public bool healthUP4; ///SAVE VAR
        [SerializeField] public bool healthUP5; ///SAVE VAR
        [SerializeField] public bool healthUP6; ///SAVE VAR
        [SerializeField] public bool healthUP7; ///SAVE VAR
        [SerializeField] public bool healthUP8; ///SAVE VAR
        [Header("Life Counter")]
        [SerializeField] public float lifeCurrent; ///SAVE VAR
        [Header("CheckPoint Lantern")]
        [SerializeField] public Vector3 myCheckPointPos;
        [SerializeField] float respawnTimer;
        [SerializeField] bool fallenState;
        [Header("Scripts")]
        [SerializeField] GameEngine gameEngine;
        [SerializeField] GUIUpdater guiUpdater; ///SEND TO FOR GUI DATA - GUI SCRIPTS PULLS FROM HERE
                                                ///FUTURE FOR SAVESYSTEM - SEND DAT TO AND LOAD DATA FROM
        [Header("Comp")]
        [SerializeField] Animator myAnim;




        // Start is called before the first frame update
        void Start()
        {
            gameEngine = FindObjectOfType<GameEngine>();
            guiUpdater = FindObjectOfType<GUIUpdater>();
            myAnim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            HpUpgrade();///CALL EVERY FRAME
           ///FUTURE SET TO ONETIME EVENT ON PURCHJASE 
            guiUpdater = FindObjectOfType<GUIUpdater>();
        }


        void HpUpgrade() ///Monitors MAX HEalth
        {
            if(healthUP0 == true)
            {
                CurrentPlayerMaxHealth = 2f;
            }
            if (healthUP1 == true)
            {
                CurrentPlayerMaxHealth = 3f;
            }
            if (healthUP2 == true)
            {
                CurrentPlayerMaxHealth = 4f;
            }
            if (healthUP3 == true)
            {
                CurrentPlayerMaxHealth = 5f;
            }
            if (healthUP4 == true)
            {
                CurrentPlayerMaxHealth = 6f;
            }
            if (healthUP5 == true)
            {
                CurrentPlayerMaxHealth = 7f;
            }
            if (healthUP6 == true)
            {
                CurrentPlayerMaxHealth = 8f;
            }
            if (healthUP7 == true)
            {
                CurrentPlayerMaxHealth = 9f;
            }
            if (healthUP8 == true)
            {
                CurrentPlayerMaxHealth = 10f;
            }

            ///HEALTH MAX LIMIT
            if(currentPlayerHealth >= CurrentPlayerMaxHealth)
            {
                currentPlayerHealth = CurrentPlayerMaxHealth;
            }
            if(currentPlayerHealth <0)
            {
                currentPlayerHealth = 0;
            }

            ///future fall code
            ///
            if(currentPlayerHealth <= 0 && fallenState == false)
            {

                myAnim.SetBool("Fallen", true);
                guiUpdater.removeLifeAnim = true;
                print("life removeExec");

                StartCoroutine(FallLife());
            }

        }

        IEnumerator FallLife()
        {
            print("fall life is playing");
            fallenState = true;
            
            yield return new WaitForSeconds(respawnTimer);
            currentPlayerHealth = CurrentPlayerMaxHealth;
            if (myCheckPointPos != Vector3.zero)
            {
                this.transform.position = myCheckPointPos;
            }

            if (myCheckPointPos == Vector3.zero)
            {
                this.transform.position = Vector3.zero;
            }
            lifeCurrent -= 1f;
           
            myAnim.SetBool("Fallen", false);
            myAnim.SetBool("Idle", true);
            guiUpdater.removeLifeAnim = true;
            fallenState = false;

            
        }
    }
}
