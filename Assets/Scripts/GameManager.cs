using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Slider hpbarSlider;
    Player player;
    Monsters monster;
    FonsVitae fonsVitae;

    public Button healButton;

    public static GameObject fonsvitae;

    private void Awake()
    {
        instance = this;
        
    }


    public void PlayerMa(Player player)
    {

    }

    public void HPbar()  // HP 체력바를 줄어들게 만듬
    {
        hpbarSlider.value = (float)player.playerHP / (float)player.playerMaxHP; 
        
        
    }

    public void MonstersMa(Monsters monsters)
    {
        player.playerHP -= monsters.monsters1ATK;
    }

    void Start()
    {
        
    }


    void Update()
    {
        player.PlayerDie();
        
    }


    public void Players(Player player)
    {


    }


    public static void OpenFonsvitaeUI() //  생명의 샘 UI 오픈
    {
        if (fonsvitae == null)
        {
            Object fonsvitaeM = Resources.Load("null");
            fonsvitae = (GameObject)Instantiate(fonsvitaeM);
        }
        fonsvitae.SetActive(true);
    }

    public static void CloseFonsvitaeUI()   //  생명의 샘 UI 클로즈
    {
        if (fonsvitae != null)
        {
            fonsvitae.SetActive(false);
        }
    }




}
