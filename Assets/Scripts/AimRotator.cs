using UnityEngine;
using UnityEngine.InputSystem;

public class AimRotator : MonoBehaviour
{
    //TODO: TP2 - Fix - Add getter for private variable (also known as property with backing field)
    //Or just serialize a property
    //[field: SerializeField]public GameObject Target { get; set; }
    //TODO: TP2 - Unclear name - A better name would be "target".
    [SerializeField] public GameObject player;
    private Vector3 targetPosition;
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    Vector3 worldpos;
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    void Update()
    {
        GetTargetPosition();
    }
    private void GetTargetPosition()
    {
        //TODO: TP2 - Comment - If you know about inheritance already, try separating these 2 behaviours into different inheritor classes. There is no problem if you can't
        if (player != null)
        {
           
            targetPosition = player.transform.position;
            //TODO: TP2 - Fix - Clean code
            targetPosition.z = player.transform.position.z;
            worldpos = player.transform.position;
        }
        else
        {
            targetPosition = Mouse.current.position.ReadValue();
            //TODO: TP2 - Optimization - Cache values/refs
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
