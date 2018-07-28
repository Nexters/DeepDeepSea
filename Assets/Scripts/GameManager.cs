﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameManager Class - Singleton Object
public class GameManager : MonoBehaviour {

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static GameManager instance = null;

    [SerializeField]
    private float backgroundSpeed = 3f;

    private float speedMode = 2.0f;

    private float boostedBackgroundSpeed = 0.001f;
    [HideInInspector]
    public bool isSpeedMode = false;

    [HideInInspector]
    public bool isPaused = false;
    private GameObject screenObject;
    
    /// <summary>
    /// 플레이어의 세로축 이동 속도
    /// </summary>
    public float PlayerVerticalSpeed
    {
        get
        {
            if (isSpeedMode)
            {
                return playerVerticalSpeed * speedMode;
            }
            else
            {
                return playerVerticalSpeed;
            }
        }
    }
    [SerializeField]
    private float playerVerticalSpeed = 3.0f;   // 플레이어의 세로축 이동 속도 ( private )
    public float playerHorizontalSpeed = 3.0f;  // 플레이어의 가로축 이동 속도

    private void Awake()
    {
        // 이미 해당 인스턴스 가 존재한다면 현재 오브젝트는 삭제
        if(instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetPause(false);
        screenObject = GameObject.Find("ScreenObject");
    }

    public void SpeedPlus() {
        playerVerticalSpeed += boostedBackgroundSpeed;
        Debug.Log ("GET ITEM" +backgroundSpeed );
    }

    public void SetPause(bool pause)
    {
        if (pause)
        {
            this.isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            this.isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
