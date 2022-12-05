using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    
    string playerName = "ââââ���";
    public int playerMaxHP = 800;
    public int playerHP = 800;
    
   
    
    Monsters monster;
    Animator animator;

    PlayerManager playerManager;


    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�    
    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )
    private float xPosition = 0.0f;


    public float moveSpeed = 5.0f; // �̵� �ӵ�
    public float speed;

    public Vector3 move;
   
    
   




    private void Start()
    {

        animator = GetComponent<Animator>();
    }




    private void Update()
    {
        
        
        PlayerPoint();
        PlayerDie();
        
        PlayerMove();

    }





    public void PlayerPoint()   // �÷��̾� �̵�����
    {



        Vector3 move =
            transform.forward * Input.GetAxis("Vertical") +
            transform.right * Input.GetAxis("Horizontal");


        transform.position += move * moveSpeed * Time.deltaTime;   // �̵����� ��ǥ�� �ݿ�


        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float yPosition = transform.position.x;



        // Clamp �� ���� ������ �����ϴ� �Լ�
        yPosition = Mathf.Clamp(yPosition + xRotateSize, 0, 0);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(0, yRotate, 0);


    }



    public void OnCollisionEnter(Collision collision)
    {
        Monsters monster = collision.gameObject.GetComponent<Monsters>();
        FonsVitae fonsvitae = collision.gameObject.GetComponent<FonsVitae>();
        if (monster)
        {
            playerHP -= monster.monsters1ATK; // �÷��̾� ������ ����

        }
        if (fonsvitae)
        {
            GameManager.OpenFonsvitaeUI();  // ������ �� UI ����
        }



    }

    public void OnCollisionExit(Collision collision)
    {
        Monsters monster = collision.gameObject.GetComponent<Monsters>();
        FonsVitae fonsvitae = collision.gameObject.GetComponent<FonsVitae>();
    }


    public void PlayerDie()  // �÷��̾� ���
    {

        if (playerHP <= 0)
        {
            Debug.Log("������");
            Destroy(this.gameObject);
        }
    }   

    public void PlayerDamage()
    {
        
        
    }

 
    public void PlayerMove()
    {
        if (Input.GetMouseButton(0) )
        {
            this.GetComponent<Animator>().Play("Attack01");

        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Animator>().Play("Run");

        }


        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Animator>().Play("WalkForwardBattle");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Animator>().Play("RunForwardBattle");
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Animator>().Play("RunForwardBattle");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Animator>().Play("RunForwardBattle");
        }
        else
        {
            this.GetComponent<Animator>().Play("Idle_Battle");
        }
    }
    

}






