using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    public float thrustMax = 2f;
    float thrustAmount;
    float regenerateSpeed = 5f;
    public float speed;
    public float jump = 10f;
    public Transform rayOrigin;
    public float rayCheckDistance = 1f;
    Rigidbody2D rb;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thrustAmount = thrustMax;

    }

    void FixedUpdate()
    {
        print(thrustAmount);
        grounded = Physics2D.Raycast(rayOrigin.position, Vector2.down, rayCheckDistance, 1 << LayerMask.NameToLayer("ground"));
        if (grounded)
        {
            thrustAmount = Mathf.MoveTowards(thrustAmount, thrustMax, Time.deltaTime * regenerateSpeed);
        }

        float x = Input.GetAxis("Horizontal");
        if (Input.GetButton ("Jump") && thrustAmount > 0f) {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Force);
            thrustAmount -= Time.deltaTime;
        }
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);

    }
}