using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothness;
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    void Start()
    {
        initalOffset = transform.position - targetObject.position;
    }

    void FixedUpdate()
    {
        cameraPosition = targetObject.position + initalOffset;
        //transform.position = Vector3.Lerp(transform.position + new Vector3(0.0f, -0.025f, 0.0f), cameraPosition, smoothness * Time.fixedDeltaTime);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, cameraPosition.x, smoothness * Time.fixedDeltaTime), cameraPosition.y, cameraPosition.z);
    }
}
