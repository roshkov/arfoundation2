using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingController : MonoBehaviour
{
    private GameObject ARSessionOrig;
  

    public void OnPlay() { 
         ARSessionOrig = GameObject.FindWithTag("ARSessionOrig");   
        //  ARSessionOrig.GetComponent<ARTapToPlaceObjectScript>().gameObjectToInstantiate.GetComponent<ButtonOnClickPassAnimation>().Play();
         ARSessionOrig.GetComponent<ARTapToPlaceObjectScript>().playAnimation("Illegal Elbow Punch");
    }

    public void onPause () {  
         ARSessionOrig = GameObject.FindWithTag("ARSessionOrig");   
         ARSessionOrig.GetComponent<ARTapToPlaceObjectScript>().stopAnimation();
    }


}
