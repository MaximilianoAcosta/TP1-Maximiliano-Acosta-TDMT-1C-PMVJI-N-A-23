using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private GameObject pool;

    [SerializeField] private float dashingPower = 20f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 0.2f;

    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CapsuleCollider2D characterHitBox;
    [SerializeField] private CharacterView characterView;

    [SerializeField] private Gun gun;

    [SerializeField] public AudioSource playerAudio;

    private Vector2 inputValue;
    private bool canDash = true;
    private bool isDashing = false;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {

            

            inputValue = inputContext.ReadValue<Vector2>();
        if (!isDashing)
        {
            if (inputContext.started)
            {
                playerAudio.Play();

            }
            characterMovement.SetDirection(inputValue);
            
            if (inputContext.canceled)
            {
                
                playerAudio.Stop();
            }
        }
    }

    public void Shoot(InputAction.CallbackContext inputContext)
    {
        if (isDashing)
        {
            return;
        }
        if (inputContext.started)
        {
            GameObject attack = pool.GetComponent<BulletPool>().GetPlayerBullet();
            gun.Shoot(attack);
        }
    }

    public void Dash(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            if (canDash)
            {
                StartCoroutine(Dash());
            }
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        characterHitBox.enabled = false;
        characterView.isDashingAnimation(true);
        characterMovement.SetDirection(inputValue * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        characterView.isDashingAnimation(false);
        characterMovement.SetDirection(inputValue);
        characterHitBox.enabled = true;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


}
