using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    [SerializeField]  Animator animator;
    [SerializeField]  CharacterMovement characterMovement;
    [SerializeField]  HealthPoints characterHP;
    [SerializeField]  string animatorParameterDirX = "dir_x";
    [SerializeField]  string animatorParameterDirY = "dir_y";
    [SerializeField]  string animatorParameterIsMoving = "isMoving";
    [SerializeField]  string animatorParameterIsDashing = "isDashing";
    [SerializeField]  string animatorParameterIsDead = "isDead";
    [SerializeField]  Camera MainCamera;

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //TODO: TP2 - Optimization - Should be event based
        if(characterHP.HP <= 0)
        {
            isDeadAnimation();
        }
        Vector2 direction = characterMovement.direction;


        float dirX = direction.x;
        float dirY = direction.y;
        bool isMoving = direction != Vector2.zero;
        animator.SetBool(animatorParameterIsMoving, isMoving);

        if (isMoving)
        {
            animator.SetFloat(animatorParameterDirX, dirX);
            animator.SetFloat(animatorParameterDirY, dirY);
        }
    }

    public void isDashingAnimation(bool isDashing)
    {
        animator.SetBool(animatorParameterIsDashing, isDashing);
    }
    public void isDeadAnimation()
    {
        DetachCamera();
        animator.SetBool(animatorParameterIsDead, true);
    }

    private void DetachCamera()
    {
        MainCamera.transform.parent = null;
    }
}
