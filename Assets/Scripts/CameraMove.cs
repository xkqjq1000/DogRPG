using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{

    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�    
    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )
    private float xPosition = 0.0f;




    private void Awake()
    {
        transform.Rotate(new Vector3(0 , 0 , 0));  // ī�޶� ���� ����
    }


    void Start()
    {
        
    }

    
    private void Update()
    {
       

    } 
}