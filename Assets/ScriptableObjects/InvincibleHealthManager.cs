using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvincibleDamageHandler", menuName = "Handler/InvincibleHealth", order = 1)]
public class InvincibleHealthManager : HealthManager
{
    public override int HandleDamage(int currentHp, int damage)
    {
        return currentHp;
    }
}