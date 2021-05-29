using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject ballPosition;
    [SerializeField]
    private float maxSp = 50;

    float accel = 1000.0f;
    float h;
    Rigidbody rb;

    static public bool ballExistFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        ballExistFlag = false;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!ballExistFlag)
            {
                Instantiate(ball, ballPosition.transform.position, ballPosition.transform.rotation);
                ballExistFlag = true;
            }
        }
    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        if(rb.velocity.magnitude < maxSp)
        {
            rb.AddForce(transform.right * h * accel, ForceMode.Impulse);
        }
        
        if (h == 0)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
