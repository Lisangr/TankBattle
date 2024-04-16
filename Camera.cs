using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    Vector3 offset;
    private Vector3 pos;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate ()
    {
        pos = player.position;
        pos.y = 6f;
        pos.z = -4f;

        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler(30f, player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
    }
}
