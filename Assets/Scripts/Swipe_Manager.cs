using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_Manager : MonoBehaviour
{
    #region Psuedocode 
    //i need variables for first touch & last touch
    //i also need variable for minimum drag & how long you were dragging for
    #endregion
    #region Variables
    //mesh filter
    [SerializeField] private GameObject blob;
    private Mesh updatedShape;
    [SerializeField] private Mesh swipeUp;
    [SerializeField] private Mesh swipeDown;
    [SerializeField] private Mesh swipeLeft;
    [SerializeField] private Mesh swipeRight;
    //swipe
    private Vector3 firstTouch;
    private Vector3 lastTouch;
    [SerializeField] private int dragDistance;
    [SerializeField] private bool fingerDown;

    //swipeUI
    //[SerializeField] private 
    //[SerializeField] private GameObject trail;

    private void Start()
    {

    }
    #endregion
    private void Update()
    {
        #region SwipeChanger
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            firstTouch = Input.touches[0].position;
            fingerDown = true;
            // trail.SetActive(true);
            //trail.transform.position = firstTouch;// where the rail will start
        }
        if (fingerDown)
        {
            if (Input.mousePosition.y >= firstTouch.y + dragDistance)
            {
                fingerDown = true;
                updatedShape = gameObject.GetComponent<MeshFilter>().mesh;
                gameObject.GetComponent<MeshFilter>().mesh = swipeUp;
                Debug.Log("Swipeup");
            }
            else if (Input.mousePosition.y <= firstTouch.y + -dragDistance)
            {
                fingerDown = true;
                updatedShape = gameObject.GetComponent<MeshFilter>().mesh;
                gameObject.GetComponent<MeshFilter>().mesh = swipeDown;
                Debug.Log("Swipedown");
            }
            else if (Input.mousePosition.x <= firstTouch.x + -dragDistance)
            {
                fingerDown = true;
                updatedShape = gameObject.GetComponent<MeshFilter>().mesh;
                gameObject.GetComponent<MeshFilter>().mesh = swipeLeft;
                Debug.Log("SwipeLeft");
            }
            else if (Input.mousePosition.x >= firstTouch.x + dragDistance)
            {
                fingerDown = true;
                updatedShape = gameObject.GetComponent<MeshFilter>().mesh;
                gameObject.GetComponent<MeshFilter>().mesh = swipeRight;
                Debug.Log("SwipeRight");
            }
            if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                fingerDown = false;
                //trail.SetActive(false);
            }
        }
        #endregion

    }

}
