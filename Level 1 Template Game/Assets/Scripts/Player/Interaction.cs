using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Health Item"))
        {
            Debug.Log("Health added");
            gameObject.GetComponent<PlayerHealth>().playerHealth += 10f;
            Destroy(other.gameObject);
        }
    }
}
