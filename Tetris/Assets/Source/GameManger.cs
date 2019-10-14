﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private static GameManger instance = null;
    public GameObject ControllingObject = null;

    public static GameManger Instance
    {
        get
        {
            return instance;
        }
    }



    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        // Debug.LogWarning("Game manger instance Called");

        DontDestroyOnLoad(this);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
