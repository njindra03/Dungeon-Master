using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float range;
    [SerializeField]private float minDistance = 10.0f;
    private bool targetCollision = false;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private int experience = 10;
    private float thrust = 1.0f;
    private Transform target;
    [SerializeField] private int health = 5;

    void Start()
    {
        Debug.Log("EnemyScript is running");
    }

    void Update()
    {
        range = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (range < minDistance)
        {
            if (!targetCollision)
            {
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                transform.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
        transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !targetCollision)
        {
            Vector3 contactPoint = collision.GetContact(0).point;
            Vector3 center = collision.collider.bounds.center;

            targetCollision = true;
            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;
            bool bottom = contactPoint.y < center.y;

            if (right) GetComponent<Rigidbody2D>().AddForce(transform.right * thrust, ForceMode2D.Impulse);
            if (left) GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust, ForceMode2D.Impulse);
            if (top) GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            if (bottom) GetComponent<Rigidbody2D>().AddForce(-transform.up * thrust, ForceMode2D.Impulse);
            Invoke("FalseCollision", 0.5f);
            Debug.Log("Enemy collided with player");
        }
    }

    void FalseCollision()
    {
        targetCollision = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage called with amount: " + amount);
        health -= amount;
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().GainExperience(experience);
            Destroy(gameObject);
        }
    }
}