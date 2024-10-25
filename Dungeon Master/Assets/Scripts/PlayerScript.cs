using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    Rigidbody2D rb;
    private float speed = 4.0f;

    public bool turnedLeft = false;

    public GameObject weapon;

    void Start()
    {
        HidePlayerBlood();
        rb = GetComponent<Rigidbody2D>();
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
            Invoke("HidePlayerBlood", 0.25f);
        }
    }

    void HidePlayerBlood()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
