using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBulletController : MonoBehaviour
{
    [SerializeField] BulletPool pool;
    [SerializeField] Gun gun;
    [SerializeField] float burstDelay;
    [SerializeField] float shotPotency;
    [SerializeField] float numberOfShots;
    [SerializeField] string bulletPoolTag;
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    

    private void Awake()
    {
        //TODO: TP2 - Fix - Why is this class setting a variable in another one based on an entirely separate object?
        //Try not to use Find()
        //transform.Find("bulletGun").GetComponent<AimRotator>().target = GameObject.FindGameObjectWithTag("playerCollider");
        //TODO: TP2 - Fix - Hardcoded value/s
        pool = GameObject.FindGameObjectWithTag(bulletPoolTag).GetComponent<BulletPool>();
    }


    void OnEnable()
    {
        StartCoroutine(bigBulletShot());
    }
    private IEnumerator bigBulletShot()
    {
        for(int i = 0; i < numberOfShots; i++)
        {
            yield return new WaitForSeconds(burstDelay);
            GameObject attack = pool.GetBullet();
            gun.Shoot(attack, shotPotency);
        }
       

    }
}
