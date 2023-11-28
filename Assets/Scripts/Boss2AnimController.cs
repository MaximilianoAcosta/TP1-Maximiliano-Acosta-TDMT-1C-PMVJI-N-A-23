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



    //TODO: TP2 - Syntax - Consistency in naming convention - Rename to EnableOrDisable
    public void AttackAnimationWalk(bool EnableOrDisable)
    {
        AttackAnimation(animatorParameterOnWalkAttack, EnableOrDisable);
    }
    public void AttackAnimationRay(bool EnableOrDisable)
    {
        AttackAnimation(animatorParameterOnRayAttack, EnableOrDisable);
    }
    public void AttackAnimationSlam(bool EnableOrDisable)
    {
        AttackAnimation(animatorParameterStompAttack, EnableOrDisable);
    }
    public void AttackAnimationTeleport(bool EnableOrDisable)
    {
        AttackAnimation(animatorParameterJumpAttack, EnableOrDisable);
    }
    public void AttackAnimationLastAttack(bool EnableOrDisable)
    {
        AttackAnimation(animatorParameterLastPhase, EnableOrDisable);
    }
    public void AttackAnimationDeath(bool EnableOrDisable)
    {
        AttackAnimation(animatorParameterDeath, EnableOrDisable);
    }
    private void AttackAnimation(string AnimationParameter, bool onAttack)
    {
        animator.SetBool(AnimationParameter, onAttack);

    }
}
