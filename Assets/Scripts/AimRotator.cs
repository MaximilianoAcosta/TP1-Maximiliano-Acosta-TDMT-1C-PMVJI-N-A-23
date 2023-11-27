using UnityEngine;
using UnityEngine.InputSystem;

public class AimRotator : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private Vector3 targetPosition;
    Vector3 worldpos;
    void Update()
    {
        GetTargetPosition();
    }
    private void GetTargetPosition()
    {
        if (player != null)
        {
           
            targetPosition = player.transform.position;
            targetPosition.z = player.transform.position.z;
            worldpos = player.transform.position;
        }
        else
        {
            targetPosition = Mouse.current.position.ReadValue();
            targetPosition.z = Camera.main.nearClipPlane;
            worldpos = Camera.main.ScreenToWorldPoint(targetPosition);
        }
        RotateAimTarget(worldpos, transform);
    }
    
    private void RotateAimTarget(Vector3 worldpos, Transform transform)
    {
        Vector3 rotation = (worldpos - transform.position).normalized;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
