using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class GrabMgr : MonoBehaviour
{

    //z컨트롤러로 잡은 물체를 저장한다.
    private Transform grabObject;

    //공에 접촉했는지 여부
    private bool isTouched = false;

    private SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;
    private SteamVR_Action_Boolean tirgger = SteamVR_Actions.default_InteractUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouched == true && tirgger.GetStateDown(hand)){
            grabObject.SetParent(this.transform);
            grabObject.GetComponent<Rigidbody>().isKinematic = true; //잡은물체의 물리엔진을 끈다,.
        }
        
    }
    
     void OnTriggerEnter(Collider coll)
    {
      if(coll.CompareTag("Ball")){
          isTouched = true;
          grabObject = coll.transform;
      }      
    }
}
