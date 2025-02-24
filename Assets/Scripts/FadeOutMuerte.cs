using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutMuerte : StateMachineBehaviour
{
    public float fadeTiempo = 0.5f;
    private float tiempoPasado = 0f;
    SpriteRenderer spriterenderer;
    GameObject objaEliminar;
    Color col;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       tiempoPasado = 0f;
       spriterenderer = animator.GetComponent<SpriteRenderer>(); 
       col = spriterenderer.color;   
       objaEliminar = animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempoPasado += Time.deltaTime;

        float nAlpha = col.a * (1 - (tiempoPasado / fadeTiempo));  // 1 - 0.5  nuevo alpha u aumenta transparencia

        spriterenderer.color = new Color(col.r, col.g, col.b, nAlpha);

        if (tiempoPasado > fadeTiempo)
        {
            Destroy(objaEliminar);
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
