using UnityEngine;
public class BossAimRotator : AimRotator
{

    [SerializeField] string targetTag;

    private void Awake()
    {
        target = FindObject(targetTag);
        GetTargetPosition();
    }
    public GameObject FindObject(string targetTag)
    {
        return GameObject.FindGameObjectWithTag(targetTag);
    }
    private void GetTargetPosition()
    {
            targetPosition = target.transform.position;
            targetPosition.z = target.transform.position.z;
            worldPosition = target.transform.position;
        
        RotateAimTarget(worldPosition, transform);
    }
}
