using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool isUp = false;
    [HideInInspector]
    public bool isDown = false;

    public float gravity;
    public float speed;
    public float maxSpeed;

    private Animator anim;
    private Rigidbody rb;
    private Collider coll;
    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    private float verticalSpeed = 0;

    void Awake() {
        //coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && (this.isUp || this.isDown)) // change to "Reverse"
        {
            this.isUp = false;
            this.isDown = false;
            Flip();
        }

        moveDirection = Vector3.right;
        verticalSpeed -= gravity * Time.deltaTime;

        // if speed > 0
        // line cast up
        // else if speed < 0
        // line cast down
        if (verticalSpeed > 0) {
            if(Physics.Linecast(this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(0, 0.6f, 0))) {
                this.isUp = true;
                verticalSpeed = 0;
            } else {
                this.isUp = false;
            }
        } else if(verticalSpeed < 0) {
            if (Physics.Linecast(this.gameObject.transform.position, this.gameObject.transform.position - new Vector3(0, 0.6f, 0))) {
                this.isDown = true;
                verticalSpeed = 0;
            } else {
                this.isDown = false;
            }
        }

        moveDirection *= speed;
        moveDirection.y = verticalSpeed;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void FixedUpdate() {

    }

    void Flip() {
        this.gravity = -this.gravity;
		GetComponent<SpriteRenderer> ().flipY = !GetComponent<SpriteRenderer> ().flipY;
    }
}