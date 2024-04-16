using UnityEngine;

public class TheSun : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5.0f;

    public void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, target.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
