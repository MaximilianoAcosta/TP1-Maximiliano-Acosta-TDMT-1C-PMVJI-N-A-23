using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2_GunRotationScript : MonoBehaviour
{
    [SerializeField] public float rotationSpeed;
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
