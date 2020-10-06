using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObjectScript : MonoBehaviour
{
    [SerializeField]

    //what we place in the space
    public GameObject gameObjectToInstantiate; 

    private GameObject spawnedObject;    

    private ARRaycastManager _arRaycastManager;

    private Vector2 touchPosition;  //where we touch with the finger


    // is used when you change the animation, so it will appear at the same place 
    //with no need to press the screen with the finger in order it to appear
    // private bool noFingerHitNeeded = false ;    
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    
    

     private void Awake() {
         _arRaycastManager = GetComponent<ARRaycastManager>();

     }

     bool TryGetTouchPosition(out Vector2 touchPosition) {
         if (Input.touchCount > 0 ) {
               touchPosition = Input.GetTouch(0).position; 
               return true;
         }

         touchPosition = default;
         return false;
     }
    
     public void setGameObjectToInstantiate(GameObject newObj) {
         Destroy (spawnedObject);
         spawnedObject = null;
         gameObjectToInstantiate = newObj; 
     }  

     public void stopAnimation () {
         gameObjectToInstantiate.GetComponent<Animation>().Stop();
     }
     public void playAnimation (String name) {
         gameObjectToInstantiate.GetComponent<Animation>().Play(name);
     }
    

    void Update()
    {
        
            if (!TryGetTouchPosition(out Vector2 touchPosition)) 
            return;

            if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)) {
                spawnOrReplaceTheObject(hits[0].pose);  
            }
           
    }



    public void spawnOrReplaceTheObject (Pose hitPose) {
            if (spawnedObject == null ) 
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation) ;
            }
            else 
            {
                spawnedObject.transform.position = hitPose.position;
            }
    }



}
