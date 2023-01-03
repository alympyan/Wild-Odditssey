using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace AwesomsseyEngine
{
    public class CarnGUI : MonoBehaviour
    {
        /// <summary>
        /// Class Update Carn Gui
        /// </summary>

        [SerializeField] CarnevileContext carnScript;
        [SerializeField] TMP_Text ticketTextField;
        [SerializeField] Image meterImage;
        [SerializeField] Image ticketImage;
        [SerializeField] Sprite meterFullSp;
        [SerializeField] Sprite meter2Sp;
        [SerializeField] Sprite meter1Sp;
        [SerializeField] Sprite meterEmptySp;
        [SerializeField] 
        

        // Start is called before the first frame update
        void Start()
        {
            carnScript = FindObjectOfType<CarnevileContext>();
        }

        // Update is called once per frame
        void Update()
        {
            if(carnScript.shotAmount == 3)
            {
                meterImage.sprite = meterFullSp;
            }

            if (carnScript.shotAmount == 2)
            {
                meterImage.sprite = meter2Sp;
            }

            if (carnScript.shotAmount == 1)
            {
                meterImage.sprite = meter1Sp;
            }

            if (carnScript.shotAmount == 0)
            {
                meterImage.sprite = meterEmptySp;
            }



            ticketTextField.text = "x " + carnScript.ticketCount.ToString() + "/" + carnScript.tickeMax;
        }
    }
}
