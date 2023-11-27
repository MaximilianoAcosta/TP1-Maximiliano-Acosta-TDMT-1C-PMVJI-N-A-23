using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AnimController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] string animatorParameterOnWalkAttack = "walkAttack";
    [SerializeField] string animatorParameterOnRayAttack = "rayAttack";
    [SerializeField] string animatorParameterJumpAttack = "jumpAttack";
    [SerializeField] string animatorParameterLastPhase = "lastPhase";
    [SerializeField] string animatorParameterDeath = "death";
    [SerializeField] string animatorParameterStompAttack = "stompAttack";



    public void AttackAnimationWalk(bool EnableORdisable)
    {
        AttackAnimation(animatorParameterOnWalkAttack, EnableORdisable);
    }
    public void AttackAnimationRay(bool EnableORdisable)
    {
        AttackAnimation(animatorParameterOnRayAttack, EnableORdisable);
    }
    public void AttackAnimationSlam(bool EnableORdisable)
    {
        AttackAnimation(animatorParameterStompAttack, EnableORdisable);
    }
    public void AttackAnimationTeleport(bool EnableORdisable)
    {
        AttackAnimation(animatorParameterJumpAttack, EnableORdisable);
    }
    public void AttackAnimationLastAttack(bool EnableORdisable)
    {
        AttackAnimation(animatorParameterLastPhase, EnableORdisable);
    }
    public void AttackAnimationDeath(bool EnableORdisable)
    {
        AttackAnimation(animatorParameterDeath, EnableORdisable);
    }
    private void AttackAnimation(string AnimationParameter, bool onAttack)
    {
        animator.SetBool(AnimationParameter, onAttack);

    }
}
