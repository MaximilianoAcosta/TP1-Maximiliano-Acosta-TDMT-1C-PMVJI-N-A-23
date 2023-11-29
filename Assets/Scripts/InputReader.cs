using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField]  BulletPool pool;

    [SerializeField]  float dashingPower = 20f;
    [SerializeField]  float dashingTime = 0.2f;
    [SerializeField]  float dashingCooldown = 0.2f;

    [SerializeField]  CharacterMovement characterMovement;
    [SerializeField]  CapsuleCollider2D characterHitBox;
    [SerializeField]  CharacterView characterView;

    [SerializeField]  Gun gun;

    [SerializeField] public AudioSource playerAudio;
    [SerializeField] public AudioSource Dashaudio;

     Vector2 inputValue;
     bool canDash = true;
     bool isDashing = false;

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
            GameObject attack = pool.GetPlayerBullet();
            gun.Shoot(attack);
        }
    }

    public void Dash(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            if (canDash)
            {
                
                StartCoroutine(DashAction());
                
            }
        }
    }
    private IEnumerator DashAction()
    {
        canDash = false;
        isDashing = true;
        characterHitBox.enabled = false;
        characterView.isDashingAnimation(true);
        Dashaudio.Play();
        characterMovement.SetDirection(inputValue * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        characterView.isDashingAnimation(false);
        characterMovement.SetDirection(inputValue);
        characterHitBox.enabled = true;
        isDashing = false;
        Dashaudio.Stop();
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


}
