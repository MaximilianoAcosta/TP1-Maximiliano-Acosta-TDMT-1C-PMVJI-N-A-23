using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerLookInput : MonoBehaviour
{
    [SerializeField] GameObject aimRotator;
   public void HandleLookInput(InputAction.CallbackContext inputContext)
    {
        Vector2 inputValue = inputContext.ReadValue<Vector2>();
        float rotationZ = Mathf.Atan2(inputValue.y, inputValue.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
