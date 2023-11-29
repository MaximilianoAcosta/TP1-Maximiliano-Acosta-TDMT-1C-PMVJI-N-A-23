using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss1Controller : MonoBehaviour
{
    [SerializeField] Boss1Behaviour iaController;
    private static float TpMinX = -1f;
    private static float TpMaxX = 4.5f;
    private static float TpMinY = -2f;
    private static float TpMaxY = 0.5f;
   
    List<IEnumerator> ATTACKS = new List<IEnumerator>();
    private void Awake()
    {
        ATTACKS.Add(iaController.RingShot());
        ATTACKS.Add(iaController.BasicShot());
        ATTACKS.Add(iaController.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
        ATTACKS.Add(iaController.LineShot());
        ATTACKS.Add(iaController.BigShot());
    }
    void Start()
    {
        StartCoroutine(iaController.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
    }
        //TODO: TP2 - Fix - Clean code - You could create a list of IEnumerators and use the random number as the index :)
        // IEnumerator[] attacks = { IAcontroller.RingShot(), IAcontroller.BasicShot(), ...};
        // StartCoroutine(attacks[randomValue]);
    public void ResetShot()
    {
        RestartList();
        int randomValue = Random.Range(0, 4);
        IEnumerator ChosenAttack = ATTACKS[randomValue];
        Debug.Log(ChosenAttack);
        StopAllCoroutines();
        StartCoroutine(ChosenAttack);
        
     
    }
    private void RestartList()
    {
        ATTACKS.Clear();
        ATTACKS.Add(iaController.RingShot());
        ATTACKS.Add(iaController.BasicShot());
        ATTACKS.Add(iaController.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
        ATTACKS.Add(iaController.LineShot());
        ATTACKS.Add(iaController.BigShot());
    }

}
