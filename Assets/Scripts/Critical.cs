using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical : MonoBehaviour
{
    public bool Crit = Dods_ChanceMaker.GetThisChanceResult_Percentage(20);
    


    private void Start()
    {
        if (Crit)
        {
            print("Critical");
        }
    }


    
    

}
