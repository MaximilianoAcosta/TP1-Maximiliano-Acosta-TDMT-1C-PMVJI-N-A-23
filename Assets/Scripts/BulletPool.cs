using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    //TODO: TP2 - Spelling error/Code in spanish/Code in spanglish
    [SerializeField] private GameObject playerBulletPrefav;
    [SerializeField] private GameObject BIGPrefav;
    

    [SerializeField] private int poolSize;
    [SerializeField] private int playerPoolSize;
    [SerializeField] private int BIGSize;
    

    [SerializeField] private List<GameObject> bulletList;
    [SerializeField] private List<GameObject> playerBulletList;
    //TODO: TP2 - Syntax - Consistency in naming convention
    [SerializeField] private List<GameObject> BigList;
      
    void Start()
    {
        AddBulletsToPool(bulletList, bulletPrefab, poolSize);
        AddBulletsToPool(playerBulletList, playerBulletPrefav, playerPoolSize);
        AddBulletsToPool(BigList, BIGPrefav, BIGSize);
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
        return ChoseBulletFromList(playerBulletList, playerBulletPrefav);
    }
    public GameObject GetBigBullet()
    {
        return ChoseBulletFromList(BigList, BIGPrefav);
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
