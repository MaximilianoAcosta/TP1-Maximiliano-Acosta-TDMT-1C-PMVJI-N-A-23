using UnityEngine;

public class Boss1AnimController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] string animatorParameterOnAttackBurst = "onAttackBurst";
    [SerializeField] string animatorParameterOnAttackRing = "onAttackRing";
    [SerializeField] string animatorParameterIsTeleporting = "isTeleporting";

    public void AttackAnimationSwipe(bool EnableOrDisable)
    {
        AttackAnimation(animatorParameterOnAttackBurst, EnableOrDisable);
    }
    public void AttackAnimationSlam(bool EnableOrDisable) 
    {
        AttackAnimation(animatorParameterOnAttackRing, EnableOrDisable);
    }
    public void AttackAnimationTeleport(bool EnableOrDisable) 
    {
        AttackAnimation(animatorParameterIsTeleporting, EnableOrDisable);
    }
    private void AttackAnimation(string AnimationParameter, bool onAttack)
    {
        animator.SetBool(AnimationParameter, onAttack);

    }
}
