using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBullet : MonoBehaviour
{
    const int secondsToWaitBeforeBulletReturnsToOriginalPosition = 2;
    void Start()
    {
        StartCoroutine(ResetPosition(transform.position));
    }
    public IEnumerator ResetPosition( Vector3 startingPosition)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        yield return new WaitForSeconds(secondsToWaitBeforeBulletReturnsToOriginalPosition);
        transform.position = startingPosition;
        StartCoroutine(ResetPosition(transform.position));
    }
}
