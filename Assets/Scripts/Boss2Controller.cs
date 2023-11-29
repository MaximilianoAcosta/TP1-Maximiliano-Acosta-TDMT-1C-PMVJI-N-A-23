using System.Collections;
using UnityEngine;

public class Boss2Controller : MonoBehaviour
{
    [SerializeField] Boss2Behaviour IAcontroller;
    //TODO: TP1 - Unused method/variable 
    static float TpMinX = -9f;
    static float TpMaxX = -5f;
    static float TpMinY = -7f;
    static float TpMaxY = -5f;
    public bool finalPhase = false;
    public bool finalPhaseRunning = false;
    static float teleportFinalValueX = -7;
    static float teleportFinalValueY = -6;
    void Start()
    {

        ResetShot();

    }

    public void ResetShot()
    {
        if (!finalPhaseRunning)
        {

            if (finalPhase)
            {
                IAcontroller.StopAllCoroutines();
                StartCoroutine(FinalAttack());
            }
            else
            {
                int randomValue = Random.Range(0, 5);
                if (randomValue == 0)
                {
                    StartCoroutine(IAcontroller.FastShot());
                }
                else if (randomValue == 1)
                {
                    StartCoroutine(IAcontroller.BasicShot());
                }
                else if (randomValue == 2)
                {
                    StartCoroutine(IAcontroller.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
                }
                else if (randomValue == 3)
                {
                    StartCoroutine(IAcontroller.RingShot());
                    StartCoroutine(IAcontroller.Move());
                    StartCoroutine(IAcontroller.LineShot());
                }
                else if (randomValue == 4)
                {
                    StartCoroutine(IAcontroller.ShotBurstBullet());
                }
            }
        }
    }

    public IEnumerator FinalAttack()
    {
        finalPhaseRunning = true;
        StartCoroutine(IAcontroller.Teleport(teleportFinalValueX, teleportFinalValueX, teleportFinalValueY, teleportFinalValueY));

        yield return new WaitForSeconds(3);
        StartCoroutine(IAcontroller.RingShot());
        StartCoroutine(IAcontroller.BasicShot());

    }

}
