using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// Class Controls Costume Events For Atta
    /// 
    /// </summary>
    public class PlayerCostumes : MonoBehaviour
    {
        [SerializeField] LevelGuide levelGuide;
        [SerializeField] Animator attaAnimRunning;
        [SerializeField] Animator attaAnimMag;
        [SerializeField] Animator attaAnimOG;
        [SerializeField] RuntimeAnimatorController attaRuntimeRunning;
        [SerializeField] RuntimeAnimatorController attaRuntimeOG;
        [SerializeField] RuntimeAnimatorController attaMagRuntime;
        [SerializeField] 

        // Start is called before the first frame update
        void Start()
        {
            levelGuide = FindObjectOfType<LevelGuide>();
            attaRuntimeRunning = GetComponent<RuntimeAnimatorController>();
            attaAnimRunning = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            levelGuide = FindObjectOfType<LevelGuide>();///Always Find Level Select
            if (levelGuide.carnevileLand == true) ///Grab attaAnimRunning,runtime and switch with Another RUNTIME
            {
                //attaRuntimeRunning = attaMagRuntime;
               // attaAnimRunning = attaAnimMag;
                attaAnimRunning.runtimeAnimatorController = attaMagRuntime;
                print("anim is carnevile");
            }

            if (levelGuide.landRideStation == true)
            {
                attaAnimRunning.runtimeAnimatorController = attaRuntimeOG;
                //attaRuntimeRunning = attaRuntimeOG;
                //attaAnimRunning = attaAnimOG;
            }
        }
    }
}
