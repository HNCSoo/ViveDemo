using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class LaserPoint : MonoBehaviour
{

    private SteamVR_Behaviour_Pose pose; //컨트롤의 위치, 회전 값을 가져오기 위해
    private SteamVR_Input_Sources hands;
    private SteamVR_Action_Boolean teleport;
    
    [SerializeField] //프라이빗이지만 인스펙터창에 보여짐
    private GameObject pointerPrefab;
    private GameObject pointer;

    //라인렌더러 속성변수
    private LineRenderer line;
    [Range(3.0f,10.0f)] //
    public float distance =5.0f;

    public Color defaltColor = Color.green;
    public Color clikedColor = Color.blue;

    //Raycast
    private RaycastHit hit;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hands = SteamVR_Input_Sources.LeftHand;
        teleport = SteamVR_Actions.default_Teleport;
        CreateLine();

        pointerPrefab = Resources.Load<GameObject>("Pointer");
        //pointerPrefab = Resources.Load("Pointer") as GameObject;
   
        pointer = Instantiate<GameObject>(pointerPrefab,this.transform);//(pointerPrefab,위치,각도, 부모)
        tr = GetComponent<Transform>();

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

    void Update()
    {
        if(Physics.Raycast(tr.position,tr.forward, out hit, distance))//시작좌표. 광선의 방향(0.0.1), 맞은 오브젝트의 정보, 광선의 거리
        {
            line.SetPosition(1,new Vector3(0,0,hit.distance));//라인 렌더러의 끝점을 오브젝트의 거리 까지만 한다. 
        
            pointer.transform.position = hit.point + (hit.normal*0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);// 물체와 부딧
        }

        else {
            pointer.transform.position = tr.position +(tr.forward * distance); //하늘을 바라봤을 때 수직으로보게한다 
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward); //올일러를 하면 오류가있을수있음  벡터의 각도를 쿼터니온 각도로 변환해서 넣어준다. 
        }


    }
}
