using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding : MonoBehaviour
{
    [Header("References")]
    public transform orientation;
    public transform playerObj;
    private Rigidbody rb;
    private playerMovementAdvanced pm;

    [Header("sliding")]
    public float maxSliderTime;
    public float slideForce;
    private float slideTimer;

    public float slideYScale;
    private float StartYScale;

    [header("Input")]
    public KeyCode slideKey = KeyCode.LefControl;
    private float horizontalInput;
    private float verticalInput;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComonent<Rigidbody>();
        pm = GetComonent<playerMovementAdvanced>();

        startYScale = playerObj.localScale.y;
    }

    private void startSlide()
    {
        
    }

    private void SlidingMovement()
    {

    }

    private void stopSlide()
    {

    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput !=0)) StartSlide();

        if (Input.GetKeyUp(slideKey) && sliding) stopSlide();
    }
}
