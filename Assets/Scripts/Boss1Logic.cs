using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


//TODO: TP2 - Unclear name - Logic is not a very good name. All C# is logic.
//A better name could be BossActions, or even BossBehaviour
public class Boss1Logic : MonoBehaviour
{
    [SerializeField] GameObject pool;
    [SerializeField] List<Gun> Guns;
    [SerializeField] Gun GunForRing;
    [SerializeField] Boss1AnimController Animation;
    [SerializeField] Boss1Controller BossController;
    [SerializeField] public float ShotPotency;
    [Space(20)]
    [SerializeField] public float ShotingCooldown;
    [Space(20)]
    [SerializeField] float Attack1AnimationDelay;
    [SerializeField] public float burstDelay;
    [SerializeField] public int burstAmmount;
    [Space(20)]
    [SerializeField] float Attack2AnimationDelay;
    [SerializeField] public int RingAmmount;
    [Space(20)]
    [SerializeField] float teleportAnimationinDelay;
    [SerializeField] float teleportAnimationOutDelay;
    [Space(20)]
    [SerializeField] float LineAttackDuration;
    [SerializeField] public float LineAttackDelay;
    private float radiusRingAttack = 10f;
    private float angleRingAttack = 10f;
    public int phase = 1;

    



    public IEnumerator BasicShot()
    {
        
        yield return new WaitForSeconds(ShotingCooldown);
        
        Animation.AttackAnimationSwipe(true);
        yield return new WaitForSeconds(Attack1AnimationDelay);
        for (int i = 0; i < burstAmmount; i++)
        {
            foreach (Gun gun in Guns)
            {
                Attack(gun);
            }
            yield return new WaitForSeconds(burstDelay);
            
            Animation.AttackAnimationSwipe(false);
        }

        BossController.ResetShot();
    }

    public IEnumerator LineShot()
    {
        yield return new WaitForSeconds(ShotingCooldown);
        Animation.AttackAnimationSwipe(true);
        yield return new WaitForSeconds(Attack1AnimationDelay);
        for (int i = 0; i < LineAttackDuration; i++)
        {

            Attack(Guns[0]);           
            yield return new WaitForSeconds(LineAttackDelay);
            Animation.AttackAnimationSwipe(false);
        }
        BossController.ResetShot();
    }
    public IEnumerator RingShot()
    {
        
        yield return new WaitForSeconds(ShotingCooldown);
        
        Animation.AttackAnimationSlam(true);
        yield return new WaitForSeconds(Attack2AnimationDelay);
        Attack(RingAmmount, GunForRing);
        
        Animation.AttackAnimationSlam(false);
        BossController.ResetShot();
    }
    public IEnumerator Teleport(float minX, float maxX,float minY, float MaxY)
    {
        yield return new WaitForSeconds(ShotingCooldown);
        
        Animation.AttackAnimationTeleport(true);
       yield return new WaitForSeconds(teleportAnimationinDelay);
        
        gameObject.GetComponent<Transform>().SetPositionAndRotation(new Vector3(Random.Range(minX, maxX), Random.Range(minY, MaxY)),transform.rotation);

        
        Animation.AttackAnimationTeleport(false);
        yield return new WaitForSeconds(teleportAnimationOutDelay);
        BossController.ResetShot();
    }
    
    //TODO: TP2 - Syntax - Consistency in naming convention - Rename to BigShot
    public IEnumerator BIGShot()
    {
        yield return new WaitForSeconds(ShotingCooldown);

        Animation.AttackAnimationSlam(true);
        yield return new WaitForSeconds(Attack2AnimationDelay);
        BIGAttack(Guns[0]);

        Animation.AttackAnimationSlam(false);
        BossController.ResetShot();
    }

    private void Attack(Gun gun)
    {
        //TODO: TP2 - Optimization - Cache values/refs - cache the pool.GetComponent
        GameObject attack = pool.GetComponent<BulletPool>().GetBullet();
        gun.Shoot(attack, ShotPotency);

    }
    private void Attack(int numberOfProyectiles, Gun gun)
    {

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
    }
    private void BIGAttack(Gun gun)
    {
        GameObject attack = pool.GetComponent<BulletPool>().GetBigBullet();
        gun.Shoot(attack, ShotPotency);
    }  
   
}
