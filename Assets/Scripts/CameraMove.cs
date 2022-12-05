using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{

    public float turnSpeed = 4.0f; // 마우스 회전 속도    
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )
    private float xPosition = 0.0f;




    private void Awake()
    {
        transform.Rotate(new Vector3(0 , 0 , 0));  // 카메라 시작 시점
    }


    void Start()
    {
        
    }

    
    private void Update()
    {
       

    } 
}