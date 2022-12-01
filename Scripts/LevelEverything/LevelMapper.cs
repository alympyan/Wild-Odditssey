using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AwesomsseyEngine
{
    public class LevelMapper : MonoBehaviour
    {
        /// <summary>
        /// Class Controls Level Mapping of Which Level You are On. Attached to GameEngine and feeds and loads from SAve+Load System
        /// This class will feed the other scripts in a level and track gmae progress of a level i.e beat he leve, grabbed the secret, etc
        /// 
        /// </summary>

        [Header("Lands Completed")]
        [SerializeField] public bool orchardLand;
        [SerializeField] public bool carnevilLand;

        [Header("Secrets Unlocked")]///Save Data and Load Data In Start 
        [SerializeField] public bool orchardCard;
        [SerializeField] public bool carnevilCard;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}