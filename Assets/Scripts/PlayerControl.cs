using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool reverse = false;

    public float speed;
    public float maxSpeed;
    public float speedIncreaseFactor;

    private Animator anim;
    private Rigidbody rb;
    private Collider coll;
    private CharacterController controller;

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
        if (Input.GetKeyDown(KeyCode.Space)) // change to "Reverse"
        {
            Flip();
            Physics.gravity = -Physics.gravity;
        }

        controller.SimpleMove(Vector3.right * speed);
        speed += speed * speedIncreaseFactor; // change to be dependent on time
        speed = speed > maxSpeed ? maxSpeed : speed;

        Debug.Log(controller.isGrounded);
    }

    void FixedUpdate() {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        Debug.Log(hit.gameObject);
    }

    void Flip() {
<<<<<<< e3d069f6f31e907f54b29523da4a72517f3f7f0d
        
=======
        GameObject.Find("World").GetComponent<WorldController>().Flip();
>>>>>>> Initial Commit version 2
       // transform.Rotate(new Vector3(0, 180 + transform.rotation.y, 0));
    }
}