
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheatEnabler : MonoBehaviour
{
    [SerializeField] HealthManager newhealthManager;
    [SerializeField] HealthPoints playerHp;
    [SerializeField] CharacterMovement playerspeed;
    [SerializeField] int speedCheatActiveValue;
    [SerializeField] int speedCheatInactiveValue;
    [SerializeField] List<HealthPoints> enemyHealth;
    [SerializeField] int damageFraction;
    int damageCheatDamage;
    bool speedCheatIsActive = false;
    public void EnableInvincibilityCheat(InputAction.CallbackContext inputContext)
    {

        if (inputContext.started)
        {
            HealthManager oldHandlerHolder = playerHp.healthManager;
            playerHp.healthManager = newhealthManager;
            newhealthManager = oldHandlerHolder;
        }
    }
    public void EnableSpeedCheat(InputAction.CallbackContext inputContext)
    {

        if (inputContext.started)
        {
            if (!speedCheatIsActive)
            {
                playerspeed.SetSpeed(speedCheatActiveValue);
                speedCheatIsActive = true;
            }
            else
            {
                playerspeed.SetSpeed(speedCheatInactiveValue);
                speedCheatIsActive = false;
            }
        }
    }
    public void DamageCheat(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            foreach (HealthPoints bossHp in enemyHealth)
            {
                if (bossHp.isActiveAndEnabled== true)
                {
                    damageCheatDamage = bossHp.maxHP / damageFraction;

                    bossHp.TakeDamage(damageCheatDamage);
                }
            }
        }


    }
}
