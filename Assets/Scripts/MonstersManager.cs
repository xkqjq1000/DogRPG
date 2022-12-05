using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    
    void Start()
    {
        Object SkeletonSkin = Resources.Load("SkeletonSkin");  // 利焙 罚待积己

        Random.Range(-10, 10);
        Random.Range(-10, 10.0f);

        for (int i = 0; i < 10; i++)
        {
            int x = Random.Range(0,100);
            int z = Random.Range(0, 100);
            Instantiate(SkeletonSkin, new Vector3(x, 3, z), Quaternion.identity);  // 利 积己
        }
    }

    
    void Update()
    {
        
    }
}
