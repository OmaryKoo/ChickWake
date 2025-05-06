using UnityEngine;

public class CameraFallow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0f, 5f, -8f);
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if(target == null) return;

        Vector3 desirePosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desirePosition, followSpeed * Time.deltaTime);
    }
    
}
