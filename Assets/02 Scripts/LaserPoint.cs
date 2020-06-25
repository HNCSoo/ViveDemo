using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class LaserPoint : MonoBehaviour
{

    private SteamVR_Behaviour_Pose pose; //컨트롤의 위치, 회전 값을 가져오기 위해
    private SteamVR_Input_Sources hands;
    private SteamVR_Action_Boolean teleport;
    

    //라인렌더러 속성변수
    private LineRenderer line;
    [Range(3.0f,10.0f)] //
    public float distance =5.0f;

    public Color defaltColor = Color.green;
    public Color clikedColor = Color.blue;


    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hands = SteamVR_Input_Sources.LeftHand;
        teleport = SteamVR_Actions.default_Teleport;
        CreateLine();
    }

 
    void CreateLine()
    {
        line =this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0,0,distance));

        line.material = new Material(Shader.Find("Unlit/Color"));//스텐다드 쉐이더는 모바일에서 쓰기에는 무거움  언릿은 조명이없어도 색을 표현해주는 쉐이더 = > 이건 가벼움
        line.material.color = defaltColor;
        line.startWidth = 0.05f;
        line.endWidth = 0.005f;

    
    }
}
