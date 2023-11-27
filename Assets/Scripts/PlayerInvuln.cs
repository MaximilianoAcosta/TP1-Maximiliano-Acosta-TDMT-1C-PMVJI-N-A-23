using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: TP2 - Unclear name - Please name it invulnerability or Invincible at least :)
public class PlayerInvuln : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D capsuleCollider;
    [SerializeField] float invulnTimer;
    internal void ActiveInvuln()
    {
        StartCoroutine(Invulnerability());
    }
    private IEnumerator Invulnerability()
    {
        capsuleCollider.enabled = false;
        yield return new WaitForSeconds(invulnTimer);
        capsuleCollider.enabled = true;
    }
}
