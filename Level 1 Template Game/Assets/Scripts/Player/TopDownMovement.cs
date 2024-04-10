using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopDownMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    public bool facingRight = true;
    public Vector2 moveDirection;
    public float walkSpeed;
    TMP_Text scoreText;
    public int scoreNum;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        rb2D = GetComponent<Rigidbody2D>();    
    }

    void Update(){
        scoreText.SetText("Score: " + scoreNum.ToString());
    }
    void FixedUpdate()
    {
        Move();
        //Rotate();
    }

    void Move()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        rb2D.MovePosition(rb2D.position + moveDirection * walkSpeed * Time.deltaTime);

        if(moveDirection.x > 0 && !facingRight){
            Flip();
        }
        else if(moveDirection.x < 0 && facingRight){
            Flip();
        }
    }

    void Rotate()
    {
        Vector2 lookDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

}
