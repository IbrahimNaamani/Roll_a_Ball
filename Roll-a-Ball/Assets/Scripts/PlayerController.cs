using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int score;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        updateScore();
        winText.text = "";
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {

            other.gameObject.SetActive(false);
            score++;
            updateScore();
        }
    }

    void updateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12)
        {
            winText.text = "You Win!";
        }
    }

}
