using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 4;

    void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
    }

    private void Move(float horizontal, float vertical)
    {
        var movement = new Vector3(horizontal, vertical, 0);

        movement = movement.normalized * speed;
        transform.position += movement * Time.deltaTime;
    }
}