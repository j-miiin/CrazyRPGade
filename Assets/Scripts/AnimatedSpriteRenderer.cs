using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    public float animationTime = 0.25f;
    public Sprite idleSprite;
    public Sprite[] animationSprites;

    public bool loop = true;
    public bool idle = true;

    private SpriteRenderer sr;
    private int animationFrame;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    private void OnEnable()
    {
        sr.enabled = true;
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }
    private void NextFrame()
    {
        animationFrame++;

        if (loop && animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        if (idle)
        {
            sr.sprite = idleSprite;
        } else if (animationFrame >= 0 && animationFrame < animationSprites.Length)
        {
            sr.sprite = animationSprites[animationFrame];
        }
    }

    private void OnDisable()
    {
        sr.enabled = false;
    }    
}
