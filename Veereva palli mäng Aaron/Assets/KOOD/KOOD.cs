using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KOOD : MonoBehaviour
{
    public float speed;
    public Text ScoreText;
    public Text winText;
    public GameObject Sein;
    private Rigidbody rb;
    public int Score;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;
        SetScoreText ();
        winText.text = "";
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 hüppa = new Vector3(0.0f, 40.0f, 0.0f);
            rb.AddForce(hüppa * speed);

        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Münt"))
        {
            other.gameObject.SetActive(false);
            Score ++;
            SetScoreText();
            if (Score >= 4)
            {
                Sein.gameObject.SetActive(false);
            }


        }


        if (other.gameObject.tag == "Vaenlane")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();


        if (Score >= 8)
        {
            winText.text = "You Win! Press R to restart or ESC to exit";
        }
    }


}

    