using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    //TODO: TP2 - Spelling error/Code in spanish/Code in spanglish
    [SerializeField] GameObject playerBulletPrefab;
    [SerializeField] GameObject bigPrefav;


    [SerializeField] int poolSize;
    [SerializeField] int playerPoolSize;
    [SerializeField] int bigSize;


    [SerializeField] List<GameObject> bulletList;
    [SerializeField] List<GameObject> playerBulletList;
    //TODO: TP2 - Syntax - Consistency in naming convention
    [SerializeField] List<GameObject> bigList;

    void Start()
    {
        AddBulletsToPool(bulletList, bulletPrefab, poolSize);
        AddBulletsToPool(playerBulletList, playerBulletPrefab, playerPoolSize);
        AddBulletsToPool(bigList, bigPrefav, bigSize);
    }

    private void AddBulletsToPool(List<GameObject> pool, GameObject bullet, int ammount)
    {
        for (int i = 0; i < ammount; i++)
        {
            GameObject bossBullet = Instantiate(bullet);
            bossBullet.SetActive(false);
            pool.Add(bossBullet);
        }
    }

    public GameObject GetBullet()
    {
        return ChoseBulletFromList(bulletList, bulletPrefab);
    }
    public GameObject GetPlayerBullet()
    {
        return ChoseBulletFromList(playerBulletList, playerBulletPrefab);
    }
    public GameObject GetBigBullet()
    {
        return ChoseBulletFromList(bigList, bigPrefav);
    }

    private GameObject ChoseBulletFromList(List<GameObject> pool, GameObject bullet)
    {
        while (true)
        {

            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeSelf)
                {
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }
            AddBulletsToPool(pool, bullet, 1);
        }
    }
}
