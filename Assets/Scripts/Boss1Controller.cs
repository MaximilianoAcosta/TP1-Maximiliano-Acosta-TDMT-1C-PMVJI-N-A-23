using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    [SerializeField] Boss1Behaviour iaController;
    static float TpMinX = -1f;
    static float TpMaxX = 4.5f;
    static float TpMinY = -2f;
    static float TpMaxY = 0.5f;
    void Start()
    {
        StartCoroutine(iaController.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
    }
    //TODO: TP2 - Fix - Clean code - You could create a list of IEnumerators and use the random number as the index :)
    // IEnumerator[] attacks = { IAcontroller.RingShot(), IAcontroller.BasicShot(), ...};
    // StartCoroutine(attacks[randomValue]);
    public void ResetShot()
    {
        IEnumerator[] attacks = 
        {                           
            iaController.RingShot(),
            iaController.BasicShot(),
            iaController.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY),
            iaController.LineShot(),
            iaController.BigShot(),
        };

        int randomValue = Random.Range(0, 5);
        StartCoroutine(attacks[randomValue]);
    }
}
