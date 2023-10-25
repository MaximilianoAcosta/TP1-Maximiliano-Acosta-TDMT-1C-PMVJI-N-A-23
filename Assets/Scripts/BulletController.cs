using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] HealthPoints bulletHealth;
    [SerializeField] Animator bulletAnimation;
    [SerializeField] string animatorParameterIsDead = "isDead";
    [SerializeField] GameObject player;
    [SerializeField] AudioSource bullet;

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

            if (bulletHealth.HP <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                
                bulletAnimation.SetBool(animatorParameterIsDead, true);
            }

        }
    }
}
