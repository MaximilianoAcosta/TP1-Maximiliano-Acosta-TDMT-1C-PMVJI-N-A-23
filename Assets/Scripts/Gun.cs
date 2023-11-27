using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float TimerCheck;
    [SerializeField] private AudioSource gunAudio;
    
    private float gunTimer;
    private bool canShoot;
    private void Start()
    {
        gunAudio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        //TODO: TP2 - Could be a coroutine/Invoke
        gunTimer += Time.deltaTime;
        if(gunTimer >= TimerCheck)
        {
            gunTimer -= TimerCheck;
            canShoot = true;
        }
    }
    public void Shoot(GameObject bullet)
    {

        if (!spawnPoint)
        {
            Debug.LogError($"{name}: {nameof(spawnPoint)} is null!");
            return;
        }

        if (canShoot)
        {
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
