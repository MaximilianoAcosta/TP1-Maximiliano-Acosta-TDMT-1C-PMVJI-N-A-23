using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBulletController : MonoBehaviour
{
    [SerializeField] GameObject pool;
    [SerializeField] Gun gun;
    [SerializeField] float burstDelay;
    [SerializeField] float ShotPotency;
    [SerializeField] float NumberOfShots;
        BulletPool bulletPool;

    private void Awake()
    {
        transform.Find("bulletGun").GetComponent<AimRotator>().player = GameObject.FindGameObjectWithTag("playerCollider");
        pool = GameObject.FindGameObjectWithTag("pool");
    }


    void OnEnable()
    {
        bulletPool = pool.GetComponent<BulletPool>();
        StartCoroutine(bigBulletShot());
    }
    private IEnumerator bigBulletShot()
    {
        for(int i = 0; i < NumberOfShots; i++)
        {
            yield return new WaitForSeconds(burstDelay);
            GameObject attack = bulletPool.GetBullet();
            gun.Shoot(attack, ShotPotency);
        }
       

    }
}
