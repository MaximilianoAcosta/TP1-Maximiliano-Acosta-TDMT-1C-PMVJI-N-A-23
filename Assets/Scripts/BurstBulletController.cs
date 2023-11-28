using System.Collections;
using UnityEngine;

public class BurstBulletController : MonoBehaviour
{
    [SerializeField] BulletPool pool;
    [SerializeField] Gun gun;
    [SerializeField] float ShotPotency;
    [SerializeField] float numberOfProyectiles;
    [SerializeField] float aliveTime;
    [SerializeField] HealthPoints bulletHealth ;
    const int  BulletDamageTaken = 1 ;
    //TODO: TP1 - Unused method/variable
    float radiusRingAttack;
    float angleRingAttack;

    private void Awake()
    {
        pool = GameObject.FindGameObjectWithTag("pool").GetComponent<BulletPool>();
        bulletHealth = GetComponent<HealthPoints>();
    }


    void OnEnable()
    {       
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
            GameObject attack = pool.GetBullet();

            float projectileDirXposition = startPoint.x + Mathf.Sin((angleRingAttack * Mathf.PI) / 180) * radiusRingAttack;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angleRingAttack * Mathf.PI) / 180) * radiusRingAttack;

            Vector2 projectileVector = new(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized;
            gun.Shoot(attack, ShotPotency, projectileMoveDirection);
            angleRingAttack += angleStep;

        }
        //TODO: TP2 - Fix - Hardcoded value/s
        bulletHealth.TakeDamage(BulletDamageTaken);
    }


}