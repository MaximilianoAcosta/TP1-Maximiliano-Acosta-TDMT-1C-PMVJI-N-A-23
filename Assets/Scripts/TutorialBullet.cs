using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBullet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ResetPosition(transform.position));
    }
    public IEnumerator ResetPosition( Vector3 startingPosition)
    {
        yield return new WaitForSeconds(2);
        transform.position = startingPosition;
        StartCoroutine(ResetPosition(transform.position));
    }
}
