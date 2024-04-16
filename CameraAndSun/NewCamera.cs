using UnityEngine;
using UnityEngine.SceneManagement;

public class NewCamera : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 6f, -10f);
    private Transform target;
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    void LateUpdate()
    {
        if (target != null)
        {
            this.transform.position = target.TransformPoint(camOffset);
            this.transform.LookAt(target);
        }
        else
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
