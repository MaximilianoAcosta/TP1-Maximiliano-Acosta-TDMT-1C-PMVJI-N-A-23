using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private HealthPoints characterHP;
    [SerializeField] private string animatorParameterDirX = "dir_x";
    [SerializeField] private string animatorParameterDirY = "dir_y";
    [SerializeField] private string animatorParameterIsMoving = "isMoving";
    [SerializeField] private string animatorParameterIsDashing = "isDashing";
    [SerializeField] private string animatorParameterIsDead = "isDead";
    [SerializeField] private Camera MainCamera;

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
