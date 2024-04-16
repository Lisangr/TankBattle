using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(prefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
