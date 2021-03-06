﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmingSystem : MonoBehaviour {
    public PlayerController[] PlayersController;
    private MyInputManager MyInput;
    private bool[] PlayerReadys = new bool[6];
    [Range(0,60)]
    public float NextSceneTimer=20;
    public float CountTimer = 0;
    bool NextFlag = false;
	// Use this for initialization
	void Start () {
        MyInput = FindObjectOfType<MyInputManager>();
        for (int i = 0; i < 6; i++) PlayerReadys[i] = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(!NextFlag)
        {
            NextSceneTimer -= Time.deltaTime;
            if ((NextSceneTimer <=0 ) ||(AllReadyCheck()))
            {
                NextFlag = true;
                SceneController.GetInstance.ChangeScene("GameScene", 2);
            }
        }

        for (int i = 0; i < 6; i++)
        {
            PlayerIdleCheck(i);
            ReadyInput(i);
        }


    }
    bool AllReadyCheck()
    {
        for(int i=0;i<6;i++)
        {
            if(!PlayerReadys[i])
            {
                return false;
            }
        }
        return true;
    }
    void ReadyInput(int Num)
    {
        if ((Input.GetButton("A_Player" + MyInput.joysticks[Num])) &&
            (Input.GetButton("B_Player" + MyInput.joysticks[Num]))&&
            (Input.GetButton("X_Player" + MyInput.joysticks[Num]))&&
            (Input.GetButton("Y_Player" + MyInput.joysticks[Num])))
        {
            PlayerReadys[Num] = true;
            Debug.Log("押されたよ" + MyInput.joysticks[Num]);
        }
    }
    public bool GetReadyFlag(int PlayerNum)
    {
        return PlayerReadys[PlayerNum];
    }
    void PlayerIdleCheck(int Num)
    {
        if ((PlayersController[Num].GetMyState() == PlayerController.EState.Init)|| 
            (PlayersController[Num].GetMyState() == PlayerController.EState.Wait))
        {
            PlayersController[Num].PlayStart();
        }
        //もしReadyになって止めるならここに書く
    }
}
