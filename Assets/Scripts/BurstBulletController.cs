using System.Collections;
using UnityEngine;

public class BurstBulletController : MonoBehaviour
{
    [SerializeField] GameObject pool;
    [SerializeField] Gun gun;
    [SerializeField] float ShotPotency;
    [SerializeField] float numberOfProyectiles;
    [SerializeField] float aliveTime;
    [SerializeField] HealthPoints bulletHealth ;
    BulletPool bulletPool;
    private float radiusRingAttack;
    private float angleRingAttack;

    private void Awake()
    {
        pool = GameObject.FindGameObjectWithTag("pool");
        bulletHealth = GetComponent<HealthPoints>();
    }


    void OnEnable()
    {
        bulletPool = pool.GetComponent<BulletPool>();
        StartCoroutine(burstBulletShot());
    }
    private IEnumerator burstBulletShot()
    {
        yield return new WaitForSeconds(aliveTime);
        
        float angleStep = 360f / numberOfProyectiles;
        radiusRingAttack = 10f;
        angleRingAttack = 10f;

        Vector2 startPoint = Vector2.up;

        for (int i = 0; i <= numberOfProyectiles - 1; i++)
        {
            GameObject attack = pool.GetComponent<BulletPool>().GetBullet();

            float projectileDirXposition = startPoint.x + Mathf.Sin((angleRingAttack * Mathf.PI) / 180) * radiusRingAttack;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angleRingAttack * Mathf.PI) / 180) * radiusRingAttack;

            Vector2 projectileVector = new(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized;
            gun.Shoot(attack, ShotPotency, projectileMoveDirection);
            angleRingAttack += angleStep;

        }
        bulletHealth.TakeDamage(1);
    }


}