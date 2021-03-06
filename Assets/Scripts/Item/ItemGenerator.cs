﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject item;
    

	IEnumerator Generate()
    {
        Vector3 location = transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Define.SCREEN_HEIGHT / 2 * -1);
        Instantiate(item, location, Quaternion.identity);
        

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        StartCoroutine(Generate());
    }

    private void Start()
    {
        GameManager.Instance.AddStartGamePlayListener(OnStartPlay);
    }

    void OnStartPlay()
    {
        StartCoroutine(Generate());
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveStartGamePlayListener(OnStartPlay);
    }


}
