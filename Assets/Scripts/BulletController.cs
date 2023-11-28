using UnityEngine;
using System;

public class BulletController : MonoBehaviour
{
    [SerializeField] HealthPoints bulletHealth;
    [SerializeField] Animator bulletAnimation;
    [SerializeField] string animatorParameterIsDead = "isDead";
    //TODO: TP1 - Unused method/variable
    public void OnEnable()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        bulletHealth.HP = bulletHealth.maxHP;
        bulletAnimation.SetBool(animatorParameterIsDead, false);
    }

    public void Update()
    {
        if (bulletHealth != null)
        {
            //TODO: TP2 - Optimization - Should be event based
            if (bulletHealth.HP <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                
                bulletAnimation.SetBool(animatorParameterIsDead, true);
            }
        }
    }
}
