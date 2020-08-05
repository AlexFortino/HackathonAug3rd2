using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 5;
    public float JumpForce = 10;
    bool IsJumping = false;
    float Horizontal = 0;
    float Vertical = 0;
    public int collectibles = 0;
    Camera cam;
    Rigidbody rb;
    public Text chatObject;
    public int needcollectibles = 8;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal += Input.GetAxis("Mouse X");
        /*transform.Rotate(new Vector3(0, Horizontal, 0));*/

        Vertical -= Input.GetAxis("Mouse Y");
        Vertical = Mathf.Clamp(Vertical, -30, 60);
        transform.eulerAngles = new Vector3(0, Horizontal, 0);
        cam.transform.eulerAngles = new Vector3(Vertical, Horizontal, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && IsJumping == false)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsJumping = true;
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            collectibles = collectibles + 1;
            Destroy(other.gameObject);
            chatObject.text = "Films: " + collectibles;
        }
        if (other.gameObject.CompareTag("Doorway"))
        {
            if (collectibles >= needcollectibles)
            {
                /*if you have enough */
                chatObject.text = "You win!";
            }
            else
            {
                /*dont have enough*/
            }
        }
    }
}