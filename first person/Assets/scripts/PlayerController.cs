using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    
    public float gravity;

    public float gravityLimit;
    public float gravityMultiplier;

    public float cameraSpeed;

    public float jumpForce;

   public bool doublejump;

    Vector2 inputs;
    public CharacterController controller;
    public GameObject cam;
    public GameObject playerHead;

    public string spawnPoint;
    public Animator bbox;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       Movement();
       Rotation();
       Jump();

      // if (Input.GetButtonDown("jump"))
       // {
           // if (isGrounded())
           // {

           // }
       // }
       if (transform.position.y < -20f)
       {
        StartCoroutine(ResetOnDeath());
       }

    }
    

    void Movement()
    {
      inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       Vector3 movement = new Vector3(inputs.x, gravity, inputs.y);
        movement = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * movement;
        controller.Move(movement * movementSpeed * Time.deltaTime);
    }
    
    void Rotation()
    {
        playerHead.transform.rotation = Quaternion.Slerp(playerHead.transform.rotation, cam.transform.rotation, cameraSpeed * Time.deltaTime);
    }

    void Jump()
    {
        
        if (gravity < gravityLimit)
        {
            gravity = gravityLimit;
        }
        else 
        {
            gravity -= Time.deltaTime * gravityMultiplier;
        }
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            gravity = Mathf.Sqrt(jumpForce);

            
        }
       
  

    }

     void OnTriggerEnter(Collider other) 
     {
        if (other.gameObject.CompareTag("Spikes"))
        {
            StartCoroutine(ResetOnDeath());
        }
    }
    public IEnumerator ResetOnDeath()
    {
        bbox.SetBool("out", true);
        controller.enabled = false;
        yield return new WaitForSeconds(1f);

        transform.position = GameObject.Find(spawnPoint).transform.position;
        yield return new WaitForSeconds(.1f);
        bbox.SetBool("out", true);
        controller.enabled = true;
    }

 public IEnumerator ResetPos()
    {
        bbox.SetBool("out", true);
        controller.enabled = false;
        transform.position = GameObject.Find(spawnPoint).transform.position;
        yield return new WaitForSeconds(.1f);
        controller.enabled = true;
    }
    public IEnumerator LoadNewScene(string levelName)
    {
        bbox.SetBool("out", false);
        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
    }


}
