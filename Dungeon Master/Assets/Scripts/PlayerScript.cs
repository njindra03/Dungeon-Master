using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    Rigidbody2D rb;
    private float speed = 4.0f;
    private int level = 1;
    private int health = 100;
    private int experience = 0;

    public bool turnedLeft = false;

    public GameObject weapon;
    public Image healthfill;
    private float healthWidth;
    private float healthHeight;

    public TextMeshProUGUI expText;

    void Start()
    {
        HidePlayerBlood();
        rb = GetComponent<Rigidbody2D>();

        healthWidth = 604f;
        healthHeight = 46f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            turnedLeft = true;
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            turnedLeft = false; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.GetChild(1).gameObject.SetActive(true);
            health -= 10;
            healthWidth -= 10;
            Vector2 temp = new Vector2(healthWidth, healthHeight);
            healthfill.rectTransform.sizeDelta = temp;
            Invoke("HidePlayerBlood", 0.25f);
        }
    }

    void HidePlayerBlood()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        expText.text = experience.ToString();
    }

}
