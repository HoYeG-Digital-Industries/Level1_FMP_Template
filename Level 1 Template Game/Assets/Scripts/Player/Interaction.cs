using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interaction : MonoBehaviour
{
    public Text scoreText;
    int score;

    void Update(){
        scoreText.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Health Item"))
        {
            Debug.Log("Health added");
            gameObject.GetComponent<PlayerHealth>().playerHealth += 10f;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Score Item"))
        {
            Debug.Log("Score added");
            score++;
            Destroy(other.gameObject);
        }
    }
}
