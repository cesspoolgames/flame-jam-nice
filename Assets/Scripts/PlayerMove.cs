using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{

    public float speed = 4;

    void Start()
    {
        speed = GlobalState.instance.playerSpeed;
    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        RotateAccordingToPosition(horizontal, vertical);
    }

    private void RotateAccordingToPosition(float horizontal, float vertical)
    {
        if (horizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void Move(float horizontal, float vertical)
    {
        var movement = new Vector3(horizontal, vertical, 0);
        var factorByGameObjectScale = transform.localScale.x;

        movement = movement.normalized * speed * factorByGameObjectScale;
        transform.position += movement * Time.deltaTime;
    }
}