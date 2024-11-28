using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }

    public AnimatedSpriteRenderer srUp;
    public AnimatedSpriteRenderer srDown;
    public AnimatedSpriteRenderer srLeft;
    public AnimatedSpriteRenderer srRight;

    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    private Vector2 direction = Vector2.down;
    private AnimatedSpriteRenderer activeSr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSr = srDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, srUp);
        } else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, srDown);
        } else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, srLeft);
        } else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, srRight);
        } else
        {
            SetDirection(Vector2.zero, activeSr);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer sr)
    {
        direction = newDirection;

        srUp.enabled = sr == srUp;
        srDown.enabled = sr == srDown;
        srLeft.enabled = sr == srLeft;
        srRight.enabled = sr == srRight;

        activeSr = sr;
        activeSr.idle = direction == Vector2.zero;
    }
}
