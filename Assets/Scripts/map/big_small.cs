﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_small : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
