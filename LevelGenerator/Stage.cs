using UnityEngine;

public class Stage : MonoBehaviour
{
    public Transform begin;
    public Transform end;

    //public Mesh[] blockMashes; //if need customise level

    private void Start()
    {
        /*foreach (var filter in GetComponentsInChildren<MeshFilter>())
        {
            if (filter.sharedMesh == blockMashes[0])
            {
                filter.sharedMesh = blockMashes[Random.Range(0, blockMashes.Length)];
            }
        }*/

    }
}
