﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum GAMESTAGETYPE
{
    GameStart,
    GamePlay,
    GameEnd


}

public class MapManager : MonoBehaviour
{


    public GameObject[] mapList = null;
    public GameObject[] mine = null;
    public GameObject[] obstacle = null;
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;
    private int damagespeed = 1;
    public GAMESTAGETYPE gamestageType;
    public bool EpilagicZone;//표해수층
    public bool MesopelagicZone;//중심해층
    public bool BathypelagicZone;//점심해층
    public bool AbyssopelagicZone;//심해저대
    public bool HadalpelagicZone;//초심해저대
    public int seameter;
    public Text seameterText;
    public string zoneName;
    private int waittime;
    float interval = 0;
    public bool gameover;
    public static MapManager instance = null;
    private Image moveIMG;

    void Awake()
    {
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;

        gamestageType = GAMESTAGETYPE.GameStart;
        Debug.Log(gamestageType);
        if (instance == null)
        {  
            instance = this;
        }
           
    }
    
    void Start()
    {

        EpilagicZone = true;
        gameover = false;
        seameter = 0;

        StartCoroutine("seameter_repeat");
        if (gamestageType == GAMESTAGETYPE.GameStart)
        {
           
            gamestageType = GAMESTAGETYPE.GamePlay;
           
        }
    }





    public IEnumerator seameter_repeat()
    {
        
        while (gameover == false)
        {
            
            yield return new WaitForSeconds(1.0f);
           
            switch (seameter)
            {
                case 0:
                    zoneName = "표해수층";
                    EpilagicZone = true;
                    seameterText.text = zoneName + " " + seameter + "M";
                    Debug.Log("표해수층");    

                    break;
                case 200:
                    MesopelagicZone = true;
                    zoneName = "중심해층";
                    Debug.Log("중심해층");
                    break;
                case 1000:
                    BathypelagicZone = true;
                    zoneName = "점심해수층";
                    Debug.Log("점심해수층");
                    break;
                case 3000:
                    AbyssopelagicZone = true;
                    zoneName = "심해저대";
                    Debug.Log("심해저대");

                    break;
                case 6000:
                    HadalpelagicZone = true;
                    zoneName = "초심해저대";
                    Debug.Log("초심해저대");

                    break;


            }
            seameter++;
            seameterText.text = zoneName + " " + seameter + "M";
           
        }
       
    }

    void Update()
    {

       
        if (gamestageType == GAMESTAGETYPE.GamePlay)
        {

        Debug.Log(gamestageType +" GAMESTAGETYPE.GamePlay");



            interval += Time.deltaTime;
            if (interval > 6.6f)
            {
                GameObject obj = Instantiate(mapList[Random.Range(0, 2)]);
                obj.transform.position = new Vector3(-0.3f, -8.45f, 0);
                GameObject mineOBJ = Instantiate(mine[Random.Range(0, 2)]);
                mineOBJ.transform.position = new Vector3(Random.Range(-2, 2), Random.Range(-4, 0), 0);
                interval = 0;
            }

            // zoneName = "표심해층";
            //seameter = 0;

            
           

        }



    }

    


}

