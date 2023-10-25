using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private string colideWithTag;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == colideWithTag)
        {

            GameObject CollisionTarget = col.gameObject;

            HealthPoints EntityHp = CollisionTarget.GetComponent<HealthPoints>();
            EntityHp.TakeDamage(damage);
            PlayerInvuln invulnerability = CollisionTarget.GetComponent<PlayerInvuln>();
            if (invulnerability != null)
            {
                invulnerability.ActiveInvuln();
            }
        }
    }
}
