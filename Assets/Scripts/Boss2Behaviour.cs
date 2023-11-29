using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behaviour : MonoBehaviour
{
    [SerializeField] BulletPool pool;
    [SerializeField] List<Gun> guns;
    [SerializeField] Gun gunForRing;
    [SerializeField] Gun gunForSingleShot;
    [SerializeField] Boss2AnimController animator;
    [SerializeField] Boss2Controller bossController;
    [SerializeField] HealthPoints healthPoints;
    [Space(20)]
    [SerializeField] public float shotPotency;
    [Space(20)]
    [SerializeField] public float shotingCooldown;
    [Space(20)]
    [SerializeField] float attack1AnimationDelay;
    [SerializeField] public float burstDelay;
    [SerializeField] public int burstAmmount;
    [Space(20)]
    [SerializeField] float attack2AnimationDelay;
    [SerializeField] public int ringRepeatAmmount;
    [SerializeField] public int ringAmmount;
    [Space(20)]
    [SerializeField] float fastAttackAnimationDelay;
    [SerializeField] int fastShotSpeedMultiplier;
    [Space(20)]
    [SerializeField] float teleportAnimationinDelay;
    [SerializeField] float teleportAnimationOutDelay;
    [Space(20)]
    [SerializeField] float lineAttackDuration;
    [SerializeField] public float lineAttackDelay;
    float radiusRingAttack = 10f;
    float angleRingAttack = 10f;
    
    [SerializeField] GameObject player;
    
    private Vector2 movementDirection;
    [SerializeField] CharacterMovement movement;

    public void OnDead()
    {
        //TODO: TP2 - Optimization - Should be event based
        
            StopAllCoroutines();
            animator.AttackAnimationDeath(true);
        
    }


    public IEnumerator BasicShot()
    {

        yield return new WaitForSeconds(shotingCooldown);

        animator.AttackAnimationLastAttack(true);
        yield return new WaitForSeconds(attack1AnimationDelay);
        for (int i = 0; i < burstAmmount; i++)
        {
            foreach (Gun gun in guns)
            {
                Attack(gun);
            }
            yield return new WaitForSeconds(burstDelay);

           animator.AttackAnimationLastAttack(false);
        }

        bossController.ResetShot();
    }
    public IEnumerator Move()
    {
        yield return new WaitForSeconds(shotingCooldown);
        animator.AttackAnimationWalk(true); 
        movementDirection = player.transform.position - transform.position;
        movement.SetDirection(movementDirection);
        yield return new WaitForSeconds(lineAttackDelay * lineAttackDuration);
        movement.SetDirection(new Vector2(0, 0));
        animator.AttackAnimationWalk(false);
    }
    public IEnumerator LineShot()
    {
        yield return new WaitForSeconds(shotingCooldown);
        
        for (int i = 0; i < lineAttackDuration; i++)
        {

            Attack(gunForSingleShot);
            yield return new WaitForSeconds(lineAttackDelay);
         
        }
        bossController.ResetShot();
    }
    public IEnumerator RingShot()
    {
        yield return new WaitForSeconds(shotingCooldown);
        for (int i = 0; i < ringRepeatAmmount; i++)
        {
            Attack(ringAmmount, gunForRing);
            yield return new WaitForSeconds(lineAttackDelay * lineAttackDuration);
        } 
    }    
    public IEnumerator FastShot()
    {
        yield return new WaitForSeconds(shotingCooldown);
        float tempHolder = shotPotency;
        shotPotency = fastShotSpeedMultiplier * shotPotency;
        animator.AttackAnimationRay(true);
        yield return new WaitForSeconds(fastAttackAnimationDelay);
        Attack(gunForSingleShot);
        shotPotency = tempHolder;
        animator.AttackAnimationRay(false);
        bossController.ResetShot();
    }

    public IEnumerator Teleport(float minX, float maxX, float minY, float MaxY)
    {
        yield return new WaitForSeconds(shotingCooldown);

       animator.AttackAnimationTeleport(true);
        yield return new WaitForSeconds(teleportAnimationinDelay);

        gameObject.GetComponent<Transform>().SetPositionAndRotation(new Vector3(Random.Range(minX, maxX), Random.Range(minY, MaxY)), transform.rotation);


       animator.AttackAnimationTeleport(false);
        yield return new WaitForSeconds(teleportAnimationOutDelay);
        Attack(ringAmmount, gunForRing);
        bossController.ResetShot();
    }

    public IEnumerator ShotBurstBullet()
    {
        yield return new WaitForSeconds(shotingCooldown);

        animator.AttackAnimationSlam(true);
        yield return new WaitForSeconds(attack2AnimationDelay);
        BigAttack(gunForSingleShot);

        animator.AttackAnimationSlam(false);
        bossController.ResetShot();
    }

    private void Attack(Gun gun)
    {
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
    private void BigAttack(Gun gun)
    {
        GameObject attack = pool.GetBigBullet();
        gun.Shoot(attack, shotPotency);
    }
}
