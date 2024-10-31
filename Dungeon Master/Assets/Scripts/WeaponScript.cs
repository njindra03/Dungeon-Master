using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Animator weaponController;
    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if (Input.GetMouseButtonDown(0))
        {
            sr.enabled = true;
            collider.enabled = true;
            weaponController.SetBool("OnSpace", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sr.enabled = false;
            collider.enabled = false;
            weaponController.SetBool("OnSpace", false);
        }
    }
}
