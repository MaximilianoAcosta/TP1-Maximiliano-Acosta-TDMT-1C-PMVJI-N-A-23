using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    
    public Vector2 direction;


    private void FixedUpdate()
    {
        //TODO: TP2 - Fix - In fixedUpdate we use Time.fixedDeltaTime
        transform.position += new Vector3(direction.x, direction.y) * (speed * Time.fixedDeltaTime);
        
    }

    public void SetDirection(Vector2 Direction)
    {
        direction = Direction;
    }
    public void SetSpeed(int value)
    {
        speed = value;
    }
}