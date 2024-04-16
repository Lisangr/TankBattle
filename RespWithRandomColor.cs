using System.Collections.Generic;
using UnityEngine;

public class RespWithRandomColor : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> gameObjectList; // ����� ������� ��� ������
    public float scalingFactor = 0.95f;
    // � ����������� ��������� �������� ������� ������ � ������ �����
    public int numCubes = 0; // ����������������������

    // ����������� ���� ����� ��� �������������
    void Start()
    {
        // ������������� ������ List<GameObject>
        gameObjectList = new List<GameObject>();
    }

    // Update ���������� � ������ �����
    void Update()
    {
        numCubes++; // ��������� ���������� ������� // �

        GameObject gObj = Instantiate<GameObject>(cubePrefabVar); // b
                                                                  // ��������� ������ ������������� ��������� �������� � ����� ������
        gObj.name = "Cube " + numCubes; // �
        gObj.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        // � �������� ��������� Renderer �� gObj � ��������� ��������� ����
        gObj.transform.position = Random.insideUnitSphere; // e
        gameObjectList.Add(gObj); // �������� gObj � ������ �������
        List<GameObject> removeList = new List<GameObject>(); // f
                                                              // � ������ removeList ����� ������� ������, ����������
                                                              // �������� �� ������ gameObjectList
                                                              // ����� ������� � gameObjectList
        foreach (GameObject goTemp in gameObjectList)
        { // g
          // �������� ������� ������
            float scale = goTemp.transform.localScale.x; // h
            scale *= scalingFactor; // �������� �� ����������� scalingFactor
            goTemp.transform.localScale = Vector3.one * scale;
            if (scale <= 0.1f)
            { // ���� ������� ������ 0.1f... // i
                removeList.Add(goTemp); // ...�������� ����� � removeList
            }
        }
        foreach (GameObject goTemp in removeList)
        { // g
            gameObjectList.Remove(goTemp); // j
                                           // � ������� ����� �� gameObjectList
            Destroy(goTemp); // ������� ������� ������ ������
        }
    }
}
