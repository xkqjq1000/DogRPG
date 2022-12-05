using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    
    string playerName = "창창창창모드";
    public int playerMaxHP = 800;
    public int playerHP = 800;
    
   
    
    Monsters monster;
    Animator animator;

    PlayerManager playerManager;


    public float turnSpeed = 4.0f; // 마우스 회전 속도    
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )
    private float xPosition = 0.0f;


    public float moveSpeed = 5.0f; // 이동 속도
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





    public void PlayerPoint()   // 플레이어 이동관련
    {



        Vector3 move =
            transform.forward * Input.GetAxis("Vertical") +
            transform.right * Input.GetAxis("Horizontal");


        transform.position += move * moveSpeed * Time.deltaTime;   // 이동량을 좌표에 반영


        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float yPosition = transform.position.x;



        // Clamp 는 값의 범위를 제한하는 함수
        yPosition = Mathf.Clamp(yPosition + xRotateSize, 0, 0);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(0, yRotate, 0);


    }



    public void OnCollisionEnter(Collision collision)
    {
        Monsters monster = collision.gameObject.GetComponent<Monsters>();
        FonsVitae fonsvitae = collision.gameObject.GetComponent<FonsVitae>();
        if (monster)
        {
            playerHP -= monster.monsters1ATK; // 플레이어 데미지 입음

        }
        if (fonsvitae)
        {
            GameManager.OpenFonsvitaeUI();  // 생명의 샘 UI 오픈
        }



    }

    public void OnCollisionExit(Collision collision)
    {
        Monsters monster = collision.gameObject.GetComponent<Monsters>();
        FonsVitae fonsvitae = collision.gameObject.GetComponent<FonsVitae>();
    }


    public void PlayerDie()  // 플레이어 사망
    {

        if (playerHP <= 0)
        {
            Debug.Log("유다희");
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






