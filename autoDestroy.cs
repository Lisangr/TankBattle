using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructTime = 2f;

    void Start()
    {
        Destroy(this.gameObject, selfDestructTime);
    }
}