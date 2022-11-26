using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class SpawnItems : MonoBehaviour
    {
        /// <summary>
        /// Class controls Item Spawns from Object Destruction
        /// </summary>
        /// 

        [Header("Options")]
        [SerializeField] GameObject objectToSpawn;
        [SerializeField] GameObject spawnedObject;
        [SerializeField] float countOfObjects;
        [SerializeField] float spawnSpeed;
        [SerializeField] bool spawnedAlready;
        [SerializeField] Vector2 spawnDir;
        [SerializeField] ParticleSystem spawnPart;
        [SerializeField] bool particleSystOn;
        [SerializeField] bool explodeDirOn;
        [SerializeField] Vector3 newPos;///POS OFFSET
        [SerializeField] bool vectorOffestOn;
        [SerializeField] public bool spawningMode;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
        }

        private void FixedUpdate()///LATE UPDATE FOR PHYSICS
        {
            if (spawningMode == true && spawnedAlready == false)
            {
                spawnedAlready = true;
                print("spawnItem is spawning");
                if(vectorOffestOn == true)
                {
                    spawnedObject = Instantiate(objectToSpawn, transform.position + newPos, transform.rotation);
                }
                if(vectorOffestOn == false)
                {
                    spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
                }
               
                if (explodeDirOn == true)
                {
                    Rigidbody2D spawnRig = spawnedObject.GetComponent<Rigidbody2D>();
                    spawnRig.AddForce(spawnDir * spawnSpeed * Time.deltaTime, ForceMode2D.Impulse);
                }

            }
        }
    }

}