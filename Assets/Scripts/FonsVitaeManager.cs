using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonsVitaeManager : MonoBehaviour
{
    
    void Start()
    {
        Object fonVitae = Resources.Load("FonsVitae"); ;  // ���� ��������

        Random.Range(-10, 10);
        Random.Range(-10, 10.0f);

        for (int i = 0; i < 2; i++)
        {
            int x = Random.Range(-20, 20);
            int z = Random.Range(-30, 30);
            Instantiate(fonVitae, new Vector3(x, 0, z), Quaternion.identity);  // �� ����
        }
    }


    void Update()
    {
        
    }
}
