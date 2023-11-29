using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;


//TODO: TP2 - Unclear name - Logic is not a very good name. All C# is logic.
//A better name could be BossActions, or even BossBehaviour
public class Boss1Behaviour : MonoBehaviour
{
    [SerializeField] BulletPool pool;
    [SerializeField] List<Gun> guns;
    [SerializeField] Gun gunForRing;
    [SerializeField] Boss1AnimController animator;
    [SerializeField] Boss1Controller bossController;
    [SerializeField] public float shotPotency;
    [Space(20)]
    [SerializeField] public float shotingCooldown;
    [Space(20)]
    [SerializeField] float attack1AnimationDelay;
    [SerializeField] public float burstDelay;
    [SerializeField] public int burstAmmount;
    [Space(20)]
    [SerializeField] float attack2AnimationDelay;
    [SerializeField] public int ringAmmount;
    [Space(20)]
    [SerializeField] float teleportAnimationinDelay;
    [SerializeField] float teleportAnimationOutDelay;
    [Space(20)]
    [SerializeField] float lineAttackDuration;
    [SerializeField] public float lineAttackDelay;
    private float radiusRingAttack = 10f;
    private float angleRingAttack = 10f;
    public int phase = 1;
 


    public IEnumerator BasicShot()
    {
        
        yield return new WaitForSeconds(shotingCooldown);
        
        animator.AttackAnimationSwipe(true);
        yield return new WaitForSeconds(attack1AnimationDelay);
        for (int i = 0; i < burstAmmount; i++)
        {
            foreach (Gun gun in guns)
            {
                Attack(gun);
            }
            yield return new WaitForSeconds(burstDelay);
            
            animator.AttackAnimationSwipe(false);
        }
        
        bossController.ResetShot();
    }

    public IEnumerator LineShot()
    {
        yield return new WaitForSeconds(shotingCooldown);
        animator.AttackAnimationSwipe(true);
        yield return new WaitForSeconds(attack1AnimationDelay);
        for (int i = 0; i < lineAttackDuration; i++)
        {

            Attack(guns[0]);           
            yield return new WaitForSeconds(lineAttackDelay);
            animator.AttackAnimationSwipe(false);
        }
        bossController.ResetShot();
    }
    public IEnumerator RingShot()
    {
        
        yield return new WaitForSeconds(shotingCooldown);
        
        animator.AttackAnimationSlam(true);
        yield return new WaitForSeconds(attack2AnimationDelay);
        Attack(ringAmmount, gunForRing);
        
        animator.AttackAnimationSlam(false);
        
        bossController.ResetShot();
    }
    public IEnumerator Teleport(float minX, float maxX,float minY, float MaxY)
    {
        yield return new WaitForSeconds(shotingCooldown);
        
        animator.AttackAnimationTeleport(true);
       yield return new WaitForSeconds(teleportAnimationinDelay);
        
        gameObject.GetComponent<Transform>().SetPositionAndRotation(new Vector3(Random.Range(minX, maxX), Random.Range(minY, MaxY)),transform.rotation);

        
        animator.AttackAnimationTeleport(false);
        yield return new WaitForSeconds(teleportAnimationOutDelay);
        bossController.ResetShot();
    }
    
    //TODO: TP2 - Syntax - Consistency in naming convention - Rename to BigShot
    public IEnumerator BigShot()
    {
        yield return new WaitForSeconds(shotingCooldown);

        animator.AttackAnimationSlam(true);
        yield return new WaitForSeconds(attack2AnimationDelay);
        BIGAttack(guns[0]);

        animator.AttackAnimationSlam(false);
        bossController.ResetShot();
    }

    private void Attack(Gun gun)
    {
        //TODO: TP2 - Optimization - Cache values/refs - cache the pool.GetComponent
        GameObject attack = pool.GetBullet();
        gun.Shoot(attack, shotPotency);

    }
    private void Attack(int numberOfProyectiles, Gun gun)
    {

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
            gun.Shoot(attack, shotPotency, projectileMoveDirection);
            angleRingAttack += angleStep;

        }
    }
    private void BIGAttack(Gun gun)
    {
        GameObject attack = pool.GetBigBullet();
        gun.Shoot(attack, shotPotency);
    }  
   
}
