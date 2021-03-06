﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.Instance.AddStartGamePlayListener(OnStartPlay);
	}
	
	void OnStartPlay()
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveStartGamePlayListener(OnStartPlay);
    }
}
