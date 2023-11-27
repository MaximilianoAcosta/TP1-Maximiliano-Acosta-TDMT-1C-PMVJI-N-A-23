using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerLevel2 : MonoBehaviour
{
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss1HpBar;
    [SerializeField] GameObject bridgeToDisable;
    [SerializeField] List<GameObject> CollidersToEnable;
    [SerializeField] List<GameObject> Buttons;
    [SerializeField] GameObject Player;
    [SerializeField] Boss_2_GunRotationScript rotationScript;
    [SerializeField] string colideWithTag;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioClip IdleMusic;
    [SerializeField] AudioClip CombatMusic;
    [SerializeField] AudioClip phase2Music;
    [Space(20)]   
    [SerializeField] int phase2BurstAmmount;
    [SerializeField] int phase2RingAmmount;
    [SerializeField] float phase2RotationSpeed;
    [SerializeField] int phase2RingRepeatAmmount;
    [Space(20)]
    
    HealthPoints boss1Hp;
    bool ChangedPhase;
    bool bossIsDead;
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
        
    }

    public void StartBossFight()
    {
        ChangeMusic(CombatMusic);
        bridgeToDisable.SetActive(false);
        foreach (GameObject collider in CollidersToEnable)
        {
            collider.SetActive(true);
        }
        boss1.SetActive(true);
        boss1HpBar.SetActive(true);

    }
    private void Update()
    {
        
        CheckPhaseChange(boss1, boss1Hp);
        CheckWinCondition(boss1Hp);
        if (Player.GetComponent<HealthPoints>().HP <= 0)
        {
            foreach (GameObject button in Buttons)
            {
                button.SetActive(true);
            }
        }
    }
    private void CheckWinCondition(HealthPoints boss1HP)
    {
        if (boss1HP.HP <= 0 && !bossIsDead)
        {
            bossIsDead = true;
            ChangeMusic(IdleMusic);
            bridgeToDisable.SetActive(true);
            foreach (GameObject collider in CollidersToEnable)
            {
                collider.SetActive(false);
            }

            boss1HpBar.SetActive(false);
            
        }
    }

    private void CheckPhaseChange(GameObject boss1, HealthPoints bossHP1)
    {
        if (bossHP1.HP <= bossHP1.maxHP *0.25 && !ChangedPhase)
        {
            ChangedPhase = true;
            PhaseChange(boss1);
            ChangeMusic(phase2Music);
        }
       
    }

    private void PhaseChange(GameObject boss)
    {
        
        Boss2Logic valueToChange = boss.GetComponent<Boss2Logic>();
        rotationScript.rotationSpeed = phase2RotationSpeed;
        valueToChange.burstAmmount = phase2BurstAmmount;
        valueToChange.RingAmmount = phase2RingAmmount;
        valueToChange.RingRepeatAmmount = phase2RingRepeatAmmount;
        boss1.GetComponent<Boss2Controller>().finalPhase = true;
    }

    private void ChangeMusic(AudioClip clip)
    {
        bgm.Stop();
        bgm.clip = clip;
        bgm.Play();
    }
}
