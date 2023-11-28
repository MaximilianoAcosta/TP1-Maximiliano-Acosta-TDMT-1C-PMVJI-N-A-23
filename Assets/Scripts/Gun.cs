using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]  Transform spawnPoint;
    [SerializeField]  float timerCheck;
    [SerializeField]  AudioSource gunAudio;
    bool canShoot = true;
    
    
    private void Start()
    {
        gunAudio = GetComponent<AudioSource>();
    }


    
        //TODO: TP2 - Could be a coroutine/Invoke
    
    private IEnumerator CheckForShotCooldown()
    {
        yield return new WaitForSeconds(timerCheck);
        canShoot = true;
    }
    public void Shoot(GameObject bullet)
    {
        if (canShoot)
        {
            StartCoroutine(CheckForShotCooldown());
            canShoot = false;
            gunAudio.Play();
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;
            var bulletMovement = bullet.GetComponent<CharacterMovement>();

            bulletMovement.SetDirection(spawnPoint.right);

        }
        else
        {
            bullet.SetActive(false);
            canShoot = false;
        }

    }
    public void Shoot(GameObject bullet,float potency)
    {
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;
            var bulletMovement = bullet.GetComponent<CharacterMovement>();
        gunAudio.Play();
        bulletMovement.SetDirection(spawnPoint.right * potency);

    }
    public void Shoot(GameObject bullet, float potency,Vector3 direction)
    {


        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = spawnPoint.rotation;
        var bulletMovement = bullet.GetComponent<CharacterMovement>();
        gunAudio.Play();
        bulletMovement.SetDirection(direction * potency);

    }

}
