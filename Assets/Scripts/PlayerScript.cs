using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 720;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public static bool hasKey;
    public static float[] position;
    public static Vector3 pos;
    public static bool isWaiting = false;
    private float timer;
    public static GameObject obj;
    public static Quaternion startRotation = Quaternion.Euler(0, 0, -90);
    public static Vector3 startPos = new Vector3(-19.5841f, -5.3575f, 0f);
    public static bool restart = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasKey = false;
        position = new float[2];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        pos = transform.position;
        obj = gameObject;
        transform.SetPositionAndRotation(startPos, startRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (restart == true) {
            transform.SetPositionAndRotation(startPos, startRotation);
            restart = false;
        }
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementDirection.Normalize();
        if (MessageScript.numLives == 0) {
            Time.timeScale = 0f;
        }
        
    }

    void FixedUpdate() {
        rb.velocity = movementDirection * speed;
        if (movementDirection != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
