using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] string animatorParameterOnAttackBurst = "onAttackBurst";
    [SerializeField] string animatorParameterOnAttackRing = "onAttackRing";
    [SerializeField] string animatorParameterIsTeleporting = "isTeleporting";

    public void AttackAnimationSwipe(bool EnableORdisable)
    {
        AttackAnimation(animatorParameterOnAttackBurst, EnableORdisable);
    }
    public void AttackAnimationSlam(bool EnableORdisable) 
    {
        AttackAnimation(animatorParameterOnAttackRing, EnableORdisable);
    }
    public void AttackAnimationTeleport(bool EnableORdisable) 
    {
        AttackAnimation(animatorParameterIsTeleporting, EnableORdisable);
    }
    private void AttackAnimation(string AnimationParameter, bool onAttack)
    {
        animator.SetBool(AnimationParameter, onAttack);

    }
}
