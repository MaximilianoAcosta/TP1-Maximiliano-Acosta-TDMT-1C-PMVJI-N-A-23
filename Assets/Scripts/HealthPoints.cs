using System.Collections;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] public int maxHP = 100;
    [SerializeField] public int HP = 100;
    private HealthPointsBar healthBar;

    [SerializeField] private float DeathAnimationDelay;

    private void Start()
    {
        healthBar = GetComponent<HealthPointsBar>();
        if (healthBar != null) healthBar.SetMaxHealth(HP, maxHP);
    }
    public void TakeDamage(int value)
    {
        HP -= value;
        if (healthBar != null)  healthBar.SetHealth(HP);
        if (HP <= 0)
        {
            StartCoroutine(DeathSequence());
        }
        
    }
    private IEnumerator DeathSequence()
    {
        if (gameObject.GetComponent<CharacterMovement>() != null)
        {
            CharacterMovement entitytodisable = gameObject.GetComponent<CharacterMovement>();

            entitytodisable.enabled = false;


            yield return new WaitForSeconds(DeathAnimationDelay);
            gameObject.SetActive(false);
            entitytodisable.enabled = true;
        }
        else
        {
            yield return new WaitForSeconds(DeathAnimationDelay);
            gameObject.SetActive(false);
        }
    }
}
