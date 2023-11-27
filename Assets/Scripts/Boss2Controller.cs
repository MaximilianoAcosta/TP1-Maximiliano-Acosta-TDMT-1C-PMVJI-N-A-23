using System.Collections;
using UnityEngine;

public class Boss2Controller : MonoBehaviour
{
    [SerializeField] Boss2Logic IAcontroller;
    //TODO: TP1 - Unused method/variable
    [SerializeField] CharacterMovement Movement;
    [SerializeField] GameObject player;
    [SerializeField] float movementTimer;
    private static float TpMinX = -9f;
    private static float TpMaxX = -5f;
    private static float TpMinY = -7f;
    private static float TpMaxY = -5f;
    public bool finalPhase = false;
    public bool finalPhaseRunning = false;

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
                StopAllCoroutines();
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
        StartCoroutine(IAcontroller.Teleport(-7, -7, -6, -6));

        yield return new WaitForSeconds(3);
        StartCoroutine(IAcontroller.RingShot());
        StartCoroutine(IAcontroller.BasicShot());

    }

}
