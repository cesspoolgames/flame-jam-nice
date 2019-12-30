using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    private float powerUpTimeSeconds = 0;

    void Start()
    {
    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        RotateAccordingToPosition(horizontal, vertical);

        powerUpTimeSeconds -= Time.deltaTime;
        if (powerUpTimeSeconds < 0)
        {
            powerUpTimeSeconds = 0;
        }
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

        var effectiveSpeed = GlobalState.instance.playerSpeed;
        if (powerUpTimeSeconds > 0)
        {
            effectiveSpeed = GlobalState.instance.playerSpeed * GlobalState.instance.powerUpSpeedFactor;
        }

        movement = movement.normalized * effectiveSpeed * factorByGameObjectScale;
        transform.position += movement * Time.deltaTime;
    }

    public void GivePowerUp()
    {
        powerUpTimeSeconds += GlobalState.instance.powerUpTimeSeconds;
    }
}