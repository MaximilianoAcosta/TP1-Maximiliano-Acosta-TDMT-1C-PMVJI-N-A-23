using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] BossLogic IAcontroller;
    private static float TpMinX = -1f;
    private static float TpMaxX = 4.5f;
    private static float TpMinY = -2f;
    private static float TpMaxY = 0.5f;

    void Start()
    {
        
        StartCoroutine(IAcontroller.Teleport(TpMinX, TpMaxX, TpMinY, TpMaxY));
    }
    public void ResetShot()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue == 0)
        {
            StartCoroutine(IAcontroller.RingShot());
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
            StartCoroutine(IAcontroller.LineShot());
        }
        else if(randomValue == 4)
        {
            StartCoroutine(IAcontroller.BIGShot());
        }

    }

}
