using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    [SerializeField] Boss1Behaviour iaController;
    private static float TpMinX = -1f;
    private static float TpMaxX = 4.5f;
    private static float TpMinY = -2f;
    private static float TpMaxY = 0.5f;

    void Start()
    {
        
        StartCoroutine(iaController.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
    }
    public void ResetShot()
    {
        int randomValue = Random.Range(0, 5);
        //TODO: TP2 - Fix - Clean code - You could create a list of IEnumerators and use the random number as the index :)
        // IEnumerator[] attacks = { IAcontroller.RingShot(), IAcontroller.BasicShot(), ...};
        // StartCoroutine(attacks[randomValue]);
        if (randomValue == 0)
        {
            StartCoroutine(iaController.RingShot());
        }
        else if (randomValue == 1)
        {
            StartCoroutine(iaController.BasicShot());
        }
        else if (randomValue == 2)
        {
            StartCoroutine(iaController.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
        }
        else if (randomValue == 3)
        {
            StartCoroutine(iaController.LineShot());
        }
        else if(randomValue == 4)
        {
            StartCoroutine(iaController.BigShot());
        }

    }

}
