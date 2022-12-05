using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState curState = CurrentState.idle;

    private Transform transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    private Animator animator;

    public float traceDist = 40.0f; // 추적 사정거리
    public float attackDist = 2.0f;  // 공격 사정거리

    private bool isDead = false;  // 사망여부

    // Use this for initialization
    void Start()
    {
        traceDist = 30.0f;
        attackDist = 2.0f;
        transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();  // 추적 대상의 위치를 설정하면 추적 시작
                        //nvAgemt.destination = playerTransform.position;

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    private void Update()
    {

       
    }

    IEnumerator CheckState()
    {   
        while (!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTransform.position, transform.position);

            if (dist <= attackDist)
            {
                curState = CurrentState.attack;
                this.GetComponent<Animator>().Play("Attack");
                
            }
            else if (dist <= traceDist)
            {
                curState = CurrentState.trace;
                this.GetComponent<Animator>().Play("Walk");
            }
            else
            {
                curState = CurrentState.idle;
                this.GetComponent<Animator>().Play("Idle");
            }
        }


    }
    IEnumerator CheckStateForAction()
    {
        while (!isDead)
        {
            switch (curState)
            {
                case CurrentState.idle:
                    nvAgent.Stop();
                    break;
                case CurrentState.trace:
                    nvAgent.destination = playerTransform.position;
                    nvAgent.Resume();
                    break;
                case CurrentState.attack:
                    break;

            }

            yield return null;
        }

    }
}


