using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monsters : MonoBehaviour
{
    public string monster1Name = "����";
    public int monsters1HP = 400;
    public int monsters1ATK = 50;
    Player player;
    Sword sword;
    Dagger dagger;
    
    Rigidbody mons;
    

    private Animator animator;

    private Transform monstertr;  // �׺���̼� ���� ����
    private Transform playertr;
    private NavMeshAgent nvAgent;

    public void OnCollisionEnter(Collision collision)  // �÷��̾� �浹
    {
        
        Sword sword = collision.gameObject.GetComponent<Sword>();  // ���� ������ ����
        if (sword)
        {
            monsters1HP -= sword.playerSword;
            Debug.Log("-50");
        }


    }

    public void OnCollisionExit(Collision collision)  // �÷��̾� �浹 ��
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

    public void MonsterDie()  //  ���� ���
    {

        if (monsters1HP <= 0)
        {
            this.GetComponent<Animator>().Play("Death");
            Destroy(this.GetComponent<BoxCollider>());
        }
    }

    


    

    }
