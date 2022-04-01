using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigiBodyComponent;
    bool jump;
    bool touchGround;
    private float horizontal;
    void Start()
    {
        rigiBodyComponent = GetComponent<Rigidbody>();
        jump = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && touchGround == true)
        {
            jump = true;
        }
        horizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        if(jump)
        {
            rigiBodyComponent.AddForce(6 * Vector3.up, ForceMode.VelocityChange);
            jump = false;
            touchGround = false;
                
        }
        rigiBodyComponent.velocity = new Vector3(horizontal *2, rigiBodyComponent.velocity.y, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        touchGround = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        Destroy(other.gameObject);
        Debug.Log("Coin collected");
    }
}
