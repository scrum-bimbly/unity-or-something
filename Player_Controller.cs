using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public int contactCount;
    public float horizontalInput;
    public float verticalInput;
    public float jumpForce = 10;
    public float speed = 10;
    public bool isOnGround = true;
    public bool levelOver = false;
    public bool gameOver = false;
    public bool isFlying = false;

    void start()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    void Update()
    {
        
        if (gameOver == false)
        {
            //player movement
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.up);
        }
        //press r to "r"estart
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            gameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision2D)
    {
        //touch capsule, win
        if (collision2D.gameObject.CompareTag("finish"))
        {
            levelOver = true;
            Debug.Log("Level Complete");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //touch spike, die
        if (collision2D.gameObject.CompareTag("danger"))
        {
            gameOver = true;
            Debug.Log("oops. death (press R to restart)");
        }
    }
}