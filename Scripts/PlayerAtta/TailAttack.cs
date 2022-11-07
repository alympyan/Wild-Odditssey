using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomsseyEngine
{
    /// <summary>
    /// Class Controls TailKiss Attack
    /// </summary>
    public class TailAttack : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField] float kissDmg;
        [SerializeField] float kissDelay;
        [SerializeField] float boxDelay;
        [SerializeField] bool attackingTailScript;

        [Header("Comp")]///GRAB OWN COMPS RIG
        [SerializeField] BoxCollider2D kissBox;

        [Header("Scripts")]
        [SerializeField] PlayerMove playerMove;

        // Start is called before the first frame update
        void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            kissBox = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            attackingTailScript = playerMove.attacking;///TAIL IS ATTACKING IN PLAYERSCRIPT
            if(Input.GetButtonDown("TailKiss") && attackingTailScript == false)///SET ALL BOOL FROM PLAYERMOVE
            {
                playerMove.attaAnim.SetBool("Tail", true);
                playerMove.tailAttackstate = true;
                StartCoroutine(TailKissAttack());
            }
        }


        IEnumerator TailKissAttack()
        {
            print("TailKiss is Attacking");
           playerMove.attacking = true;///SET PLAYERMOVE ATTACKING TO TRUE
            kissBox.enabled = true;
            yield return new WaitForSeconds(boxDelay);
            kissBox.enabled = false;
           //yield return new WaitForSeconds(kissDelay);
            playerMove.attacking = false;
            playerMove.tailAttackstate = false;

        }
    }

}