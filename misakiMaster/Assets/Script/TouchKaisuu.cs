﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchKaisuu : MonoBehaviour
{
    // タッチ状態管理Managerの読み込み
    GameObject RetryPanelMakeObj = default;
    RetryPanelMake RetryPanelMakeScript = default;

    Text boardText;
    Touch touchScript;
    public int Operate;
    private int Operate_kawaru;
    public static int operate;  //ゲッター用

    // Start is called before the first frame update
    void Start()
    {
        RetryPanelMakeObj = GameObject.Find("RetryPanelMake");
        RetryPanelMakeScript = RetryPanelMakeObj.GetComponent<RetryPanelMake>();

        boardText = this.GetComponent<Text>();
        touchScript = GameObject.Find("TouchManager").GetComponent<Touch>();

        Operate_kawaru = Operate;
        
    }

    // Update is called once per frame
    void Update()
    {
        touchScript = GameObject.Find("TouchManager").GetComponent<Touch>();
  
        boardText.text = ""+(Operate - touchScript.touchNum);

        Operate_kawaru -= touchScript.touchNum;
        if (Operate_kawaru == 0)
        {
            RetryPanelMakeScript.SetGameOverFlag();
        }
        else
        {
            Operate_kawaru = Operate;
        }
        operate = Operate - touchScript.touchNum;
    }

    //げったーロボ
    public static int GetOperate()
    {
        return operate;
    }
}
