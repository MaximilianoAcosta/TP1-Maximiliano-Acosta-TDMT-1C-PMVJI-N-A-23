using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] public int maxHP = 100;
    [SerializeField] public int HP = 100;
    [SerializeField] public HealthManager healthManager;
    private HealthPointsBar healthBar;

    [SerializeField] private float DeathAnimationDelay;

    public UnityEvent OnDeath;
    private void Start()
    {
        healthBar = GetComponent<HealthPointsBar>();
        if (healthBar != null) healthBar.SetMaxHealth(HP, maxHP);
    }
    public void TakeDamage(int damage)
    {
        HP = healthManager.HandleDamage(HP,damage);
        if (healthBar != null)  healthBar.SetHealth(HP);
        if (HP <= 0)
        {
            OnDeath.Invoke();
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
