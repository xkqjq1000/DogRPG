using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monsters : MonoBehaviour
{
    public string monster1Name = "좀비";
    public int monsters1HP = 400;
    public int monsters1ATK = 50;
    Player player;
    Sword sword;
    Dagger dagger;
    
    Rigidbody mons;
    

    private Animator animator;

    private Transform monstertr;  // 네비게이션 전용 변수
    private Transform playertr;
    private NavMeshAgent nvAgent;

    public void OnCollisionEnter(Collision collision)  // 플레이어 충돌
    {
        
        Sword sword = collision.gameObject.GetComponent<Sword>();  // 몬스터 데미지 입음
        if (sword)
        {
            monsters1HP -= sword.playerSword;
            Debug.Log("-50");
        }


    }

    public void OnCollisionExit(Collision collision)  // 플레이어 충돌 끝
    {
        
    }

        
   

    public void SwordDamaged()        
    {

        monsters1HP -= sword.playerSword;

    }



    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }



    private void Update()
    {

        
        
    }

    public void MonsterDie()  //  몬스터 사망
    {

        if (monsters1HP <= 0)
        {
            this.GetComponent<Animator>().Play("Death");
            Destroy(this.GetComponent<BoxCollider>());
        }
    }

    


    

    }
