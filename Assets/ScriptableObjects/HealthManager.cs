using UnityEngine;

[CreateAssetMenu(fileName = "DamageHandler", menuName = "Handler/Health", order = 1)]
public class HealthManager : ScriptableObject
{
    public virtual int HandleDamage(int currentHp, int damage)
    {
        int newHp = currentHp - damage;
        return newHp;
    }
}
