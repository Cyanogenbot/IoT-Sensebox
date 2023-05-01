using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSR {
public class Footstep : MonoBehaviour
{   
    public FSR_Player fsr;
    float elapsedTime;
    float timeLimit = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    elapsedTime += Time.deltaTime;

    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
    if (elapsedTime >= timeLimit){
        elapsedTime = 0;
        fsr.step();
    }
   }
  }
 }
}