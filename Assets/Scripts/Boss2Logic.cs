using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Logic : MonoBehaviour
{
    [SerializeField] GameObject pool;
    [SerializeField] List<Gun> Guns;
    [SerializeField] Gun GunForRing;
    [SerializeField] Gun GunForSingleShot;
    [SerializeField] Boss2AnimController Animation;
    [SerializeField] Boss2Controller BossController;
    [Space(20)]
    [SerializeField] public float ShotPotency;
    [Space(20)]
    [SerializeField] public float ShotingCooldown;
    [Space(20)]
    [SerializeField] float Attack1AnimationDelay;
    [SerializeField] public float burstDelay;
    [SerializeField] public int burstAmmount;
    [Space(20)]
    [SerializeField] float Attack2AnimationDelay;
    [SerializeField] public int RingRepeatAmmount;
    [SerializeField] public int RingAmmount;
    [Space(20)]
    [SerializeField] float FastAttackAnimationDelay;
    [Space(20)]
    [SerializeField] float teleportAnimationinDelay;
    [SerializeField] float teleportAnimationOutDelay;
    [Space(20)]
    [SerializeField] float LineAttackDuration;
    [SerializeField] public float LineAttackDelay;
    private float radiusRingAttack = 10f;
    private float angleRingAttack = 10f;
    public int phase = 1;
    [SerializeField] GameObject player;
    
    private Vector2 movementDirection;
    [SerializeField] CharacterMovement Movement;

    private void Update()
    {
        if (this.GetComponent<HealthPoints>().HP <= 0)
        {
            StopAllCoroutines();
            Animation.AttackAnimationDeath(true);
        }
    }


    public IEnumerator BasicShot()
    {

        yield return new WaitForSeconds(ShotingCooldown);

        Animation.AttackAnimationLastAttack(true);
        yield return new WaitForSeconds(Attack1AnimationDelay);
        for (int i = 0; i < burstAmmount; i++)
        {
            foreach (Gun gun in Guns)
            {
                Attack(gun);
            }
            yield return new WaitForSeconds(burstDelay);

           Animation.AttackAnimationLastAttack(false);
        }

        BossController.ResetShot();
    }
    public IEnumerator Move()
    {
        yield return new WaitForSeconds(ShotingCooldown);
        Animation.AttackAnimationWalk(true); 
        movementDirection = player.transform.position - transform.position;
        Movement.SetDirection(movementDirection);
        yield return new WaitForSeconds(LineAttackDelay * LineAttackDuration);
        Movement.SetDirection(new Vector2(0, 0));
        Animation.AttackAnimationWalk(false);
    }
    public IEnumerator LineShot()
    {
        yield return new WaitForSeconds(ShotingCooldown);
        
        for (int i = 0; i < LineAttackDuration; i++)
        {

            Attack(GunForSingleShot);
            yield return new WaitForSeconds(LineAttackDelay);
         
        }
        BossController.ResetShot();
    }
    public IEnumerator RingShot()
    {
        yield return new WaitForSeconds(ShotingCooldown);
        for (int i = 0; i < RingRepeatAmmount; i++)
        {
            Attack(RingAmmount, GunForRing);
            yield return new WaitForSeconds(LineAttackDelay * LineAttackDuration);
        } 
    }
    
    public IEnumerator FastShot()
    {
        yield return new WaitForSeconds(ShotingCooldown);
        float tempHolder = ShotPotency;
        ShotPotency = 3 * ShotPotency;
        Animation.AttackAnimationRay(true);
        yield return new WaitForSeconds(FastAttackAnimationDelay);
        Attack(GunForSingleShot);
        ShotPotency = tempHolder;
        Animation.AttackAnimationRay(false);
        BossController.ResetShot();
    }

    public IEnumerator Teleport(float minX, float maxX, float minY, float MaxY)
    {
        yield return new WaitForSeconds(ShotingCooldown);

       Animation.AttackAnimationTeleport(true);
        yield return new WaitForSeconds(teleportAnimationinDelay);

        gameObject.GetComponent<Transform>().SetPositionAndRotation(new Vector3(Random.Range(minX, maxX), Random.Range(minY, MaxY)), transform.rotation);


       Animation.AttackAnimationTeleport(false);
        yield return new WaitForSeconds(teleportAnimationOutDelay);
        Attack(RingAmmount, GunForRing);
        BossController.ResetShot();
    }

    public IEnumerator ShotBurstBullet()
    {
        yield return new WaitForSeconds(ShotingCooldown);

        Animation.AttackAnimationSlam(true);
        yield return new WaitForSeconds(Attack2AnimationDelay);
        BIGAttack(GunForSingleShot);

        Animation.AttackAnimationSlam(false);
        BossController.ResetShot();
    }

    private void Attack(Gun gun)
    {
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
