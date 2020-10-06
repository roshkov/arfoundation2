using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimationSwitch : MonoBehaviour
{
    GameObject ARSessionOrig;

  public void OnButtonClickedChangeAnimation(GameObject animation) {
      ARSessionOrig = GameObject.FindWithTag("ARSessionOrig");
      

  }



}
