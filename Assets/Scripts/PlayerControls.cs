using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private ScoreManager scoremanager;
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private float speed = 40;
    Camera mainCamera;
    float minY, maxY;

    Input input;
    Rigidbody2D rb;
    bool upPressed;

    void Awake() {
        input = new Input();
        input.Controls.Up.performed += ctx => upPressed = ctx.ReadValueAsButton();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CameraBounds();
    }

    void Update() {
        if(transform.position.y >= maxY+1 || transform.position.y <= minY-1) {
            gamemanager.GameOver();
        }
    }

    void FixedUpdate()
    {
        if(upPressed) {
            rb.velocity = new Vector2(0, speed);
            Debug.Log(transform.position);
        }
        else {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MiddlePipe"))
        {
            scoremanager.AddScore();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ObstaclePipe"))
        {
            gamemanager.GameOver();
        }
    }

    void CameraBounds() {
        mainCamera = Camera.main;

        // Calculate camera bounds
        float cameraHeight = 2f * mainCamera.orthographicSize;
        minY = mainCamera.transform.position.y - cameraHeight / 2f;
        maxY = mainCamera.transform.position.y + cameraHeight / 2f;
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

}