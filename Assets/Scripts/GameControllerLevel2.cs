using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControllerLevel2 : MonoBehaviour
{
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss1HpBar;
    [SerializeField] GameObject bridgeToDisable;
    [SerializeField] List<GameObject> collidersToEnable;
    [SerializeField] List<GameObject> buttons;
    [SerializeField] GameObject player;
    [SerializeField] Boss_2_GunRotationScript rotationScript;
    [SerializeField] string colideWithTag;
    [Space(20)]
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioClip idleMusic;
    [SerializeField] AudioClip combatMusic;
    [SerializeField] AudioClip phase2Music;
    [Space(20)]   
    [SerializeField] int phase2BurstAmmount;
    [SerializeField] int phase2RingAmmount;
    [SerializeField] float phase2RotationSpeed;
    [SerializeField] int phase2RingRepeatAmmount;
    [Space(20)]
    
    HealthPoints boss1Hp;
    bool changedPhase;
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
        ChangeMusic(combatMusic);
        bridgeToDisable.SetActive(false);
        foreach (GameObject collider in collidersToEnable)
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
       
    }
    private void CheckWinCondition(HealthPoints boss1HP)
    {
        if (boss1HP.HP <= 0 && !bossIsDead)
        {
            bossIsDead = true;
            ChangeMusic(idleMusic);
            bridgeToDisable.SetActive(true);
            foreach (GameObject collider in collidersToEnable)
            {
                collider.SetActive(false);
            }

            boss1HpBar.SetActive(false);
            
        }
    }
    public void DeathHudCheck()
    {
        if (player.GetComponent<HealthPoints>().HP <= 0)
        {
            foreach (GameObject button in buttons)
            {
                button.SetActive(true);
            }
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(buttons[0]);
        }
    }
    private void CheckPhaseChange(GameObject boss1, HealthPoints bossHP1)
    {
        if (bossHP1.HP <= bossHP1.maxHP *0.25 && !changedPhase)
        {
            changedPhase = true;
            PhaseChange(boss1);
            ChangeMusic(phase2Music);
        }
       
    }

    private void PhaseChange(GameObject boss)
    {
        
        Boss2Behaviour valueToChange = boss.GetComponent<Boss2Behaviour>();
        rotationScript.rotationSpeed = phase2RotationSpeed;
        valueToChange.burstAmmount = phase2BurstAmmount;
        valueToChange.ringAmmount = phase2RingAmmount;
        valueToChange.ringRepeatAmmount = phase2RingRepeatAmmount;
        boss1.GetComponent<Boss2Controller>().finalPhase = true;
    }

    private void ChangeMusic(AudioClip clip)
    {
        bgm.Stop();
        bgm.clip = clip;
        bgm.Play();
    }
}
