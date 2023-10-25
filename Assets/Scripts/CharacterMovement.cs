using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    public Vector2 direction;


    private void FixedUpdate()
    {
        transform.position += new Vector3(direction.x, direction.y) * (speed * Time.deltaTime);
        
    }

    public void SetDirection(Vector2 Direction)
    {
        direction = Direction;
    }
}