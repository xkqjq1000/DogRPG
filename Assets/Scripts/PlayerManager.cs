using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
  static public PlayerManager instance;


    public float speed = 0.05f;

    private Animator animator;
    Player player;




    void Start()

    {
        instance = this;
        animator = GetComponent<Animator>();
        
        

    }

    void Update()
    {


       

    }

    

}

