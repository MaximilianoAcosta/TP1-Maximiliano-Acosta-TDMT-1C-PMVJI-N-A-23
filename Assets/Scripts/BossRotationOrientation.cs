using UnityEngine;

public class BossRotationOrientation : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    void Update()
    {
        
        bool flip = player.transform.position.x < transform.position.x;
        transform.rotation = Quaternion.Euler(new Vector3(0, flip ? 180f : 0f, 0f));
    }
}
