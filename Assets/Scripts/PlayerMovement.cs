using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 direction = Vector2.zero;
    [SerializeField] float _speed =5f;
    //[SerializeField] bool isJumping = false;
    //[SerializeField] bool isWalking = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }

        transform.Translate(direction * _speed * Time.deltaTime);
        direction = Vector2.zero;
        
    }
}
