using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private PlayerController pm;

    [Header("sliding")]
    public float maxSliderTime;
    public float slideForce;
    private float slideTimer;

    public float slideYScale;
    private float StartYScale;

    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;


    private bool sliding;


    // Start is called before the first frame update
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        pm = transform.GetComponent<PlayerController>();

        StartYScale = playerObj.localScale.y;
    }

    private void StartSlide()
    {
        sliding = true;

        playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z);
        rb.AddForce(Vector3.down *5f,ForceMode.Impulse);

        slideTimer = maxSliderTime;

    }

    private void SlidingMovement()
    {
       Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
       rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);

       slideTimer -= Time.deltaTime;
       
       if(slideTimer <= 0) StopSlide();
    }

    private void StopSlide()
    {
       sliding = false;
        playerObj.localScale = new Vector3(playerObj.localScale.x, StartYScale, playerObj.localScale.z);
    }

    private void FixedUpdae()
    {
        if (sliding)
           SlidingMovement();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0)) StartSlide();

        if (Input.GetKeyUp(slideKey) && sliding) StopSlide();
    }
}
