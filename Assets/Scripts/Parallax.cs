using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private Vector3 startpos;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startpos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos.x + dist, startpos.y, transform.position.z);
    }
}
