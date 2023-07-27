using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Death":
                Debug.Log(this.name + "Collided with :" + other.gameObject.name);
                Destroy(other.gameObject);
                Reload_Level();
                //Destroy(gameObject);
                break;
            case "Finish":             
                Debug.Log("You have Finished");
                Reload_Level();
                break;
            case "Pickup":
                Debug.Log("Pickup");
                break;
            default:
                
                break;
        }    
    }

    private void Reload_Level()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
