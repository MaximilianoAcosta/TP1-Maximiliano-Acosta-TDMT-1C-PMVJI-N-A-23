using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss1HpBar;
    [SerializeField] GameObject boss2;
    [SerializeField] GameObject boss2HpBar;
    [SerializeField] GameObject bridgeToDisable;
    [SerializeField] List<GameObject> CollidersToEnable;
    [SerializeField] GameObject Player;
    [SerializeField] private List<GameObject> Buttons;
    [SerializeField] string colideWithTag;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioClip IdleMusic;
    [SerializeField] AudioClip CombatMusic;
    [Space(20)]
    [SerializeField] float phase2ShotingCooldown;
    [SerializeField] int phase2BurstAmmount;
    [SerializeField] float phase2BurstDelay;
    [SerializeField] int phase2RingAmmount;
    [SerializeField] float phase2ShotPotency;
    [SerializeField] float phase2LineDelay;
    [Space(20)]
    [SerializeField] float phase3ShotingCooldown;
    [SerializeField] int phase3BurstAmmount;
    [SerializeField] float phase3BurstDelay;
    [SerializeField] int phase3RingAmmount;
    [SerializeField] float phase3ShotPotency;
    [SerializeField] float phase3LineDelay;
    [Space(20)]
    [SerializeField] float phase4ShotingCooldown;
    [SerializeField] int phase4BurstAmmount;
    [SerializeField] float phase4BurstDelay;
    [SerializeField] int phase4RingAmmount;
    [SerializeField] float phase4ShotPotency;
    [SerializeField] float phase4LineDelay;
    HealthPoints boss1Hp;
    HealthPoints boss2Hp;
    bool secondBossSpawned = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == colideWithTag)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            StartBossFight();
        }
    }
    private void Awake()
    {
        boss1Hp = boss1.GetComponent<HealthPoints>();
        boss2Hp = boss2.GetComponent<HealthPoints>();
    }
    
    public void StartBossFight()
    {
        bgm.Stop();
        bgm.clip = CombatMusic;  
        bgm.Play(); 
        bridgeToDisable.SetActive(false);
        foreach(GameObject collider in CollidersToEnable)
        {
            collider.SetActive(true);
        }
        boss1.SetActive(true);
        boss1HpBar.SetActive(true);
       
    }
    private void Update()
    {
        if (boss1Hp.HP <= boss1Hp.maxHP / 2 && !secondBossSpawned)
        {
            boss2.SetActive(true);
            boss2HpBar.SetActive(true);
            secondBossSpawned = true;
        }
        CheckPhaseChange(boss1, boss2, boss1Hp);
        CheckPhaseChange(boss2, boss1, boss2Hp);
        CheckWinCondition(boss1Hp, boss2Hp);
        if (Player.GetComponent<HealthPoints>().HP <= 0)
        {
            foreach(GameObject button in Buttons)
            {
                button.SetActive(true);
            }
        }
    }
    private void CheckWinCondition(HealthPoints boss1HP, HealthPoints boss2HP)
    {
        if(boss1HP.HP <= 0 && boss2HP.HP<=0 && bridgeToDisable.activeSelf == false )
        {
            bgm.clip = IdleMusic;
            bgm.Play();
            bridgeToDisable.SetActive(true);
            foreach (GameObject collider in CollidersToEnable)
            {
                collider.SetActive(false);
            }

            boss1HpBar.SetActive(false);
            boss2HpBar.SetActive(false);
        }
    }

    private void CheckPhaseChange(GameObject boss1, GameObject boss2, HealthPoints bossHP1)
    {
        if (boss1.GetComponent<BossLogic>().phase == 1 && bossHP1.HP <= bossHP1.maxHP * 3 / 4)
        {
            PhaseChange(boss1, 2);
        }
        if (boss1.GetComponent<BossLogic>().phase == 2 && bossHP1.HP <= bossHP1.maxHP / 3)
        {
            PhaseChange(boss1, 3);
        }
        
        if (bossHP1.HP <= 0)
        {
            PhaseChange(boss2,4);
        }
    }

    private void PhaseChange(GameObject boss, int phase)
    {
        float newShotingCooldown = 0;
        int newBurstAmmount = 0;
        float newBurstDelay = 0;
        int newRingAmmount = 0;
        float newShotPotency = 0;
        float newLineAttackDelay = 0;
        BossLogic valueToChange = boss.GetComponent<BossLogic>();
        if (phase == 2)
        {
            newShotingCooldown = phase2ShotingCooldown;
            newBurstAmmount = phase2BurstAmmount;
            newBurstDelay = phase2BurstDelay;
            newRingAmmount = phase2RingAmmount;
            newShotPotency = phase2ShotPotency;
            newLineAttackDelay = phase2LineDelay;
        }
        else if (phase == 3)
        {
            newShotingCooldown = phase3ShotingCooldown;
            newBurstAmmount = phase3BurstAmmount;
            newBurstDelay = phase3BurstDelay;
            newRingAmmount = phase3RingAmmount;
            newShotPotency = phase3ShotPotency;
            newLineAttackDelay = phase3LineDelay;
        }
        else if (phase == 4)
        {
            newShotingCooldown = phase4ShotingCooldown;
            newBurstAmmount = phase4BurstAmmount;
            newBurstDelay = phase4BurstDelay;
            newRingAmmount = phase4RingAmmount;
            newShotPotency = phase4ShotPotency;
            newLineAttackDelay = phase4LineDelay;
        }

        valueToChange.ShotingCooldown = newShotingCooldown;
        valueToChange.burstAmmount = newBurstAmmount;
        valueToChange.burstDelay = newBurstDelay;
        valueToChange.RingAmmount = newRingAmmount;
        valueToChange.ShotPotency = newShotPotency;
        valueToChange.LineAttackDelay = newLineAttackDelay;
        valueToChange.phase = phase;
    }


}
