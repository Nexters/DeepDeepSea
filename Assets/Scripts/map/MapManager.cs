﻿using System.Collections; using UnityEngine; using UnityEngine.UI; using UnityEngine.SceneManagement; using System.Collections.Generic;  public enum GAMESTAGETYPE {     GameStart,     GamePlay,     GameEnd } public class MapManager : MonoBehaviour {     public GameObject[] l_wall;      public GameObject[] r_wall;          public GameObject[] ROBJ;     public GameObject[] itemrandom;      public GameObject rightObs;     public GameObject leftObs;       public int startingHealth = 100;                            // The amount of health the player starts the game with.     public int currentHealth;                                   // The current health the player has.     public Slider healthSlider;       private int damagespeed = 1;     public GAMESTAGETYPE gamestageType;     public bool EpilagicZone;//표해수층     public bool MesopelagicZone;//중심해층     public bool BathypelagicZone;//점심해층     public bool AbyssopelagicZone;//심해저대     public bool HadalpelagicZone;//초심해저대     public int seameter;     public Text seameterText;     public string zoneName;       private int waittime;     float interval = 0;     public bool gameover;     private Image moveIMG;         float totalTime = 300f; //2 minutes      public Text timer;      private GameObject screenObject;      public void UpdateLevelTimer(float totalSeconds)     {         int minutes = Mathf.FloorToInt(totalSeconds / 60f);         int seconds = Mathf.RoundToInt(totalSeconds % 60f);          string formatedSeconds = seconds.ToString();          if (seconds == 60)         {             seconds = 0;             minutes += 1;         }          timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");     }       void Awake()     {         currentHealth = startingHealth;         healthSlider.value = currentHealth;          gamestageType = GAMESTAGETYPE.GameStart;         //Debug.Log(gamestageType);          screenObject = GameObject.FindGameObjectWithTag("ScreenObject");     }          void Start()     {         EpilagicZone = true;         gameover = false;         seameter = 0;                  StartCoroutine("maprandom");         if (gamestageType == GAMESTAGETYPE.GameStart)         {                      gamestageType = GAMESTAGETYPE.GamePlay;                   }     }      public void Update()     {         if (gamestageType == GAMESTAGETYPE.GamePlay)         {             interval += Time.deltaTime;             if (interval > 5.6f)             {                 Vector3 rightwall_pos;                 Vector3 leftwall_pos;                 if (r_wall.Length > 0)                 {                     rightwall_pos = screenObject.transform.position + new Vector3(4, -26);                     Instantiate(r_wall[Random.Range(0, r_wall.Length)], rightwall_pos, Quaternion.identity);                 }                 if (l_wall.Length > 0)                 {                     leftwall_pos = screenObject.transform.position + new Vector3(-5, -20);                     Instantiate(l_wall[Random.Range(0, l_wall.Length)], leftwall_pos, Quaternion.identity);                 }                 interval = 0;                     }          }          totalTime -= Time.deltaTime;         UpdateLevelTimer(totalTime);      }      public IEnumerator maprandom(){          Debug.Log(gameover);         while(gameover==false){             yield return new WaitForSeconds(3.0f);             Vector3 location;             Vector3 location1;             Vector3 location2;             Vector3 location3;             Vector3 location4;             Vector3 location5;               Vector3 euler = transform.eulerAngles;             euler.z = Random.Range(-180.0f, 180.0f);             euler.y= Random.Range(-180.0f, 180.0f);             ROBJ[Random.Range(0, ROBJ.Length)].transform.eulerAngles = euler;            //ㄴ ROBJ[Random.Range(0, ROBJ.Length)].transform.rotation = Random.rotation;                         float MyAngle = Random.Range(-180f, 180f);              Quaternion quart = Quaternion.AngleAxis(MyAngle, Vector3.forward);              float rightA = 60.0f;             float leftA = -60.0f;             Quaternion rightangle = Quaternion.AngleAxis(rightA, Vector3.forward);             Quaternion leftangle = Quaternion.AngleAxis(leftA, Vector3.forward);                //  Instantiate(게임오브젝트, 포지션, quart);                location = screenObject.transform.position + new Vector3(Random.Range(1.4f, 2.4f),  -7.07f);             Instantiate(itemrandom[Random.Range(0, itemrandom.Length)], location, quart);             location1 =screenObject.transform.position + new Vector3(Random.Range(-4.0f, -2.0f), -7.07f);             Instantiate(itemrandom[Random.Range(0, itemrandom.Length)], location1, quart);              Debug.Log("distance");              location2 = screenObject.transform.position + new Vector3(Random.Range(-6.0f, -4.0f),Random.Range(-14.0f, -2.0f) );             Instantiate(ROBJ[Random.Range(0, ROBJ.Length)], location2, quart);              location3 = screenObject.transform.position + new Vector3(Random.Range(3.0f, 5.0f), Random.Range(-14.0f, -2.0f));             Instantiate(ROBJ[Random.Range(0, ROBJ.Length)], location3,quart);              location4 = screenObject.transform.position + new Vector3(Random.Range(4.5f, 6.0f), Random.Range(-14.0f, -2.0f));             Instantiate(rightObs, location4, rightangle);                         location5= screenObject.transform.position + new Vector3(Random.Range(-8.0f, -6.5f), Random.Range(-14.0f, -2.0f));             Instantiate(leftObs, location5, leftangle);              /* location5 = screenObject.transform.position + new Vector3(Random.Range(3.0f, 5.0f), Random.Range(-10.0f, -7.0f));             Instantiate(ROBJ[Random.Range(0, ROBJ.Length)], location5, quart); */                            if(gameover==true){                 yield break;             }           }                           /*                  Vector3 location;                 Vector3 location1;                 Vector3 location2;                 Vector3 location3;                    location = screenObject.transform.position + new Vector3(2.0f, -38.0f);                 Instantiate(maptype[Random.Range(0, maptype.Length)], location, Quaternion.identity);                  location1 = screenObject.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-10.0f, -4.0f));                 Instantiate(mine[Random.Range(0, mine.Length)], location1, Quaternion.identity);                                 location2 = screenObject.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-10.0f, -4.0f));                 Instantiate(ROBJ[Random.Range(0, ROBJ.Length)], location2, Quaternion.identity);                  location3 = screenObject.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-10.0f, -4.0f));                 Instantiate(itemrandom[Random.Range(0, itemrandom.Length)], location3, Quaternion.identity);            */     }  }   