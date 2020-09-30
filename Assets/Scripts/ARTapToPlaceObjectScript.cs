using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObjectScript : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObjectToInstantiate; //what we place in the space
    private GameObject spawneObject;    
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;  //where we touch with the finger

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
    
        
    

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition)) 
        return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)) {
            var hitPose = hits[0].pose;

            if (spawneObject == null ) 
            {
                spawneObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation) ;
            }
            else 
            {
                spawneObject.transform.position = hitPose.position;
            }
        }
    }
}
