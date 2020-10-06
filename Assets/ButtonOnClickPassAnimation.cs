using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ButtonOnClickPassAnimation : MonoBehaviour
{
      [SerializeField] public GameObject animatedModel;
      GameObject ARSessionOrig;

      public void passToHandleSwitch() {
             Debug.Log("passToHandleSwitch() is passed");
            ARSessionOrig = GameObject.FindWithTag("ARSessionOrig");
            ARSessionOrig.GetComponent<ARTapToPlaceObjectScript>().setGameObjectToInstantiate(animatedModel);
            Debug.Log("passToHandleSwitch() is passed");
      }  
}
