using UnityEngine;
public class BossAimRotator : AimRotator
{
    [SerializeField] public GameObject target;
    [SerializeField] string targetTag;

    void Update()
    {
        GetTargetPosition();
    }
    private void Awake()
    {
        target = FindObject(targetTag);
        GetTargetPosition();
    }
    public GameObject FindObject(string targetTag)
    {
        return GameObject.FindGameObjectWithTag(targetTag);
    }
    public override void GetTargetPosition()
    {
            targetPosition = target.transform.position;
            targetPosition.z = target.transform.position.z;
            worldPosition = target.transform.position;
        
        RotateAimTarget(worldPosition);
        
    }
}
