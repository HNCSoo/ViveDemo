using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Vivecontroller : MonoBehaviour
{

    //컨트롤러 정의
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources any;

    //컨트롤러 입력값 정의
    public SteamVR_Action_Boolean trigger;
    
    //트랙패드 클릭
    public SteamVR_Action_Boolean trackPadCilck = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackPadTouch;
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackPadPosition;

    public SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;
    void Awake()
    {
        trigger = SteamVR_Actions.default_InteractUI; 
    }


    // Update is called once per frame
    void Update()
    {
        // 왼손 컨트롤러 트리거를 눌렀을 때 
        if(trigger.GetStateDown(leftHand))
        {
            Debug.Log("click left trigger");
            haptic.Execute(0.2f,0.5f,200.0f,1f,leftHand); //웨이팅 타임 지속시간, 주파수, 진폭
        }

        //오른손 컨트롤러 트리거를 눌렀다가 떼었을때 
        if(trigger.GetStateUp(rightHand)){
            Debug.Log ("Released Triiger button");
              haptic.Execute(0.2f,0.5f,200.0f,1f,rightHand); //웨이팅 타임 지속시간, 주파수, 진폭
        }
    
        if(trackPadCilck.GetStateDown(any)){
            Debug.Log ("TrackPad Click");
        }

        if(trackPadTouch.GetState(any))
        {
        Vector2 pos = trackPadPosition.GetAxis(any);  
        Debug.Log($"Touch pos x= {pos.x}/y={pos.y}");
        }     

    }

}
