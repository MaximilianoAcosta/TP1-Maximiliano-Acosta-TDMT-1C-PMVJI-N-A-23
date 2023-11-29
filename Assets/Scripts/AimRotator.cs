using UnityEngine;
using UnityEngine.InputSystem;

public class AimRotator : MonoBehaviour
{
    //TODO: TP2 - Fix - Add getter for private variable (also known as property with backing field)
    //Or just serialize a property
    //[field: SerializeField]public GameObject Target { get; set; }
    //TODO: TP2 - Unclear name - A better name would be "target".
    
    public Vector3 targetPosition;
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    public Vector3 worldPosition;
    new Camera camera;
    Mouse mouse;
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    //TODO: TP2 - Optimization - Cache values/refs
    private void Awake()
    {
        camera = Camera.main;
        mouse = Mouse.current;
    }
    public virtual void GetTargetPosition()
    {   
        targetPosition = mouse.position.ReadValue();
        targetPosition.z = camera.nearClipPlane;
        worldPosition = camera.ScreenToWorldPoint(targetPosition);
        
        RotateAimTarget(worldPosition);
    }
    public void RotateAimTarget(Vector3 worldpos)
    {
        Vector3 rotation = (worldpos - transform.position).normalized;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
    public void HandleMouseLookInput(InputAction.CallbackContext inputContext)
    {
        targetPosition = inputContext.ReadValue<Vector2>();
        targetPosition.z = camera.nearClipPlane;
        worldPosition = camera.ScreenToWorldPoint(targetPosition);
        RotateAimTarget(worldPosition);
    }
    public void HandleLookInput(InputAction.CallbackContext inputContext)
    {
        Vector3 inputValue = inputContext.ReadValue<Vector2>();
        float rotationZ = Mathf.Atan2(inputValue.y, inputValue.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ); 
    }

}
