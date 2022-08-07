using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float followSpeed = 0.5f;
    public Vector3 offset = new Vector3(0, 2, -10);

    public bool lock_x = false;
    public bool lock_y = false;
    public bool lock_z = false;
    
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        transform.position = target.position + offset;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(offset);;
        float x = lock_x ? transform.position.x : targetPosition.x;
        float y = lock_y ? transform.position.y : targetPosition.y;
        float z = lock_z ? transform.position.z : targetPosition.z;

        Vector3 newPosition = new Vector3(x, y, z);

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, followSpeed);
    }
}
