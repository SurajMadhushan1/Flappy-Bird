using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // Sprite use for  2D
    private int spriteIndex;

    public float gravity = -9.8f;
    private Vector3 direction;
    public float strength = 5f ;


    private void Awake() // Awake function is run in very first time, 1 st frame . only one time it run
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // get access to Sprite render component
    }


    private void Start()
    {

        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f); // call function repeatedly
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // for computer
        {
            direction = Vector3.up*strength;
        }

        if (Input.touchCount>0) // check screen touch is greater than 0
        {
            Touch toch = Input.GetTouch(0); // get first touch
            if (toch.phase == TouchPhase.Began)

            {
                direction = Vector3.up * strength;

            }
        }

        direction.y += gravity * Time.deltaTime; // using time.deltatime it works same gravity in other frame rates
        transform.position += direction* Time.deltaTime;

    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;  
        direction = Vector3.zero;
    }


    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        if (collision.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }


}
