using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class FonsVitae : MonoBehaviour
{
    int healing = 30;



    private void Start()
    {
       
    }
    public void Healing(Player player)  // ������ �� ��Ʈ ��
    {
        int i = 0;
        while(i <= 10)
        { 
            player.playerHP += healing;

            i++;
        }

        
    
    }
    
}
