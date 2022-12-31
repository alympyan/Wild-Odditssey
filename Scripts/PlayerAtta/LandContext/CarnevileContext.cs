using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class CarnevileContext : MonoBehaviour
    {
        /// <summary>
        /// Class controls Carnevile Context Moves
        /// </summary>

        [SerializeField] SpriteRenderer[] wandSR; ///6 Index
        [SerializeField] Sprite wandSprite;
        [SerializeField] bool wandPressed;
        [SerializeField] bool isShooting;
        [SerializeField] float delayTimer;
        [SerializeField] float delayTimerOG;
        [SerializeField] PlayerMove playerMove;
        [SerializeField] SeedShot seedShot;
        [SerializeField] GameObject wandToSpawn;
        [SerializeField] GameObject wandProjSpawnedObj;
        [SerializeField] float shootSpeed;
        [SerializeField] Vector3 shootOff;
        [SerializeField] int rightDir;
        [SerializeField] bool carnEnabled;
        [SerializeField] LevelGuide levelGuide;


        // Start is called before the first frame update
        void Start()
        {
            delayTimerOG = delayTimer;
            playerMove = GetComponent<PlayerMove>();
            seedShot = GetComponent<SeedShot>();
            wandSR = GetComponentsInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            levelGuide = FindObjectOfType<LevelGuide>();
            if(levelGuide.carnevileLand == true)///Go To Level Guide and Enable
            {
                carnEnabled = true;
            }
            if (levelGuide.carnevileLand == false)///Go To Level Guide and DisEnable
            {
                carnEnabled = false;
            }

            if (transform.right == Vector3.right)
            {
                rightDir = 1;
            }
            if (transform.right == Vector3.left)
            {
                rightDir = -1;
            }

            if (carnEnabled == true)///If Enabled By Level Script
            {
                if (Input.GetButtonDown("Throw") && wandPressed == false && isShooting == false && playerMove.attacking == false && seedShot.shootState == false)
                {
                    wandPressed = true;

                }
            }
        }

        private void FixedUpdate()
        {
            if(wandPressed == true && isShooting == false)
            {
                StartCoroutine(WandShoot());
            }
        }

         IEnumerator WandShoot()
        {
            isShooting = true;
            playerMove.attacking = true;
            wandSR[6].sprite = wandSprite;
            wandSR[6].enabled = true; /// Enable Wand Sprite 6
            // if(rightDir == 1)
            //{
            //wandProjSpawnedObj = Instantiate(wandToSpawn, transform.position + shootOff * rightDir, transform.rotation);
            // }
            //if (rightDir == -1)
            //{
            //wandProjSpawnedObj = Instantiate(wandToSpawn, transform.position - shootOff * rightDir, transform.rotation);
            //}
            wandProjSpawnedObj = Instantiate(wandToSpawn, transform.position + shootOff * rightDir, transform.rotation);
          
            Rigidbody2D wandRig = wandProjSpawnedObj.GetComponent<Rigidbody2D>();
            wandRig.AddForce(new Vector2(rightDir, 0) * shootSpeed * Time.deltaTime, ForceMode2D.Impulse);
            ///Aduio And Future Effects
            ///
            yield return new WaitForSeconds(delayTimer);
            isShooting = false;
            playerMove.attacking = false;
            wandSR[6].enabled = false;
        }
    }
}
