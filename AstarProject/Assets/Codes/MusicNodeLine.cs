﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//노드가 떨어지는 라인
/*
 그 라인만 담당한다. 
     */

    public enum ComboResult
{
    None=0,
    Miss,
    Good,
    Great,
    Perfect

}
//public struct NodeLine
//{
//    public List<MusicNode> Line;
//    public string LineName;
//    public Vector3 LineZeroPoint;

//}
public class MusicNodeLine : MonoBehaviour
{
    private const float DetectRange = 3.0f;

    private const float MissRange = 2.0f;

    private const float GoodRange = 1.0f;

    private const float GreatRange = 0.5f;

    private const float PerfectRange = 0.0f;

    private const float Interval = 0.3f;
    private float timer;
    //각 줄에 대한 Linkedlist
    [SerializeField] public LinkedList<MusicNode> Line;

    public  Vector3 LinePos;
    public Vector3 LineSpawnPos;
    public  LineName LineName;
    //[SerializeField] public List<MusicNode> ALine;
    //[SerializeField] public List<MusicNode> DLine;
    //[SerializeField] public List<MusicNode> FLine;
    private static float speed;


    private void Awake()
    {
        Line =new LinkedList<MusicNode>();
        //ALine=new List<MusicNode>();
        //DLine =new List<MusicNode>();
        //FLine=new List<MusicNode>();
         speed = 0.5f;
        timer = 0.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        //EventManger.Instance.AddEvent(EventType.CheackA, )
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0.0f) timer -= Time.deltaTime;
        else if (timer < 0.0f) timer = 0.0f;

        if (Line.Count == 0) return;
        foreach(var index in Line)
        {
            
                index.Drop(LinePos, speed);
        }
    }
    //버튼이 눌렸을 때, 그것의 콤보 결과 값을 리턴해준다. 
    private ComboResult CheackCombo()
    {
        float distance = Vector3.Distance(LinePos, Line.First.Value.GetPos());
        if (distance <= PerfectRange) return ComboResult.Perfect;
        else if (distance <= GreatRange) return ComboResult.Great;
        else if (distance <= GoodRange) return ComboResult.Good;
        else if (distance <= MissRange) return ComboResult.Miss;
        else return ComboResult.None;
    }
    //결과에 따라 팝 처리
    public void TryPop()
    {
        ComboResult result = CheackCombo();
        switch(result)
        {
            case ComboResult.None:
                return;
                
                //miss가 뜬다면 다시 누를 수 없어야 된다
            case ComboResult.Miss:
                Line.RemoveFirst();
                break;
            case ComboResult.Good:
                Line.First.Value.PopNode();
                Line.RemoveFirst();
                break;
            case ComboResult.Great:
                Line.First.Value.PopNode();
                Line.RemoveFirst();
                break;
            case ComboResult.Perfect:
                Line.First.Value.PopNode();
                Line.RemoveFirst();
                break;

        }
    }
    public void CraeteNode()
    {
        if (timer == 0.0f) return; 



        var newNode = Resources.Load("MusicNode")as MusicNode;
        newNode.transform.position = LineSpawnPos;
        Line.AddLast(newNode);
        timer = Interval;
        
    }
    

    public static  void IncreaseSpeed()
    {
        speed += 0.5f;
    }
    public static void DecreaseSpeed()
    {
        
        speed -= 0.5f;
        if (speed < 0.0f) speed = 0.0f;
    }
   
    public void SetLineName(LineName name)
    {
        LineName = name;
    }
}
