﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   

    private static Player instance=null;

    public static Player Instance
    {
        get
        {
           
            return instance;
        }

    }
       
    


    private void Awake()
    {
        if(instance!=null)
        {
            DestroyImmediate(gameObject);
            return;
        }
       // Debug.LogWarning("Player Instance Created");
        instance = this;
        DontDestroyOnLoad(this);
    }



    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.green;
    

      //  GameManger test;
    }

    // Update is called once per frame
     public  void Update()
    {
        
    }
    /*
     
    Estimate Distance Between This(player) to Target(Enermy)
    return value = Distance
    */
   public float EstimateDistance( Player From,Enermy  To)
    {
       if(From==null)
        {
            Debug.Log("Player value is Null ");
            return 99.0f;
        }
        float result = 0.0f;

        Vector3 playerPos = From.transform.position;
        Vector3 targetPos = To.transform.position;
        //result = Mathf.Sqrt(
        //    Mathf.Abs(playerPos.x  -  targetPos.x)+     Mathf.Abs(playerPos.y - targetPos.y)+     Mathf.Abs(playerPos.z  -  targetPos.z)   );
       // result = playerPos - targetPos;
        Debug.Log("result Distance : " + result);
        return result;
    }

    public static Player GetPlayer()
    {
        return instance;
    }

}
