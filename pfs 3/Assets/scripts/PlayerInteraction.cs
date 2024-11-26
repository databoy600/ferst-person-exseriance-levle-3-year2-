using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject hand;
    public GameObject cam;
    
    public float lookDistance;

    public LayerMask layerMask;

    RaycastHit hit;

    public Collider triggerColl;

    GameManager gmSc;


    // Start is called before the first frame update
    void Start()
    {
        gmSc = GameObject.Find("GameManager").GetComponent<GameManager>();
        gmSc.infoText.text = " ";
        
    }

    // Update is called once per frame
    void Update()
    {
      // OTHER INTERACSHONS
        if (triggerColl != null && Input.GetKeyDown(KeyCode.E))
        {
            if (triggerColl.gameObject.CompareTag("Lock") && gmSc.hasKey)
          {
            gmSc.hasKey = false;
            gmSc.infoText.text = " ";
            Destroy(triggerColl.gameObject);
          }

          if (triggerColl.gameObject.CompareTag("lever"))
          {
            lever leverSc = triggerColl.gameObject.GetComponent<lever>();
            leverSc.isOn = !leverSc.isOn;
          }
             
        

        }
        
        // WEPONS
        if (hand.transform.childCount == 1 && Input.GetKeyDown(KeyCode.F))
        {
           hand.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
           hand.transform.GetChild(0).gameObject.transform.parent = null;
        }
        else if (hand.transform.childCount == 1 && Input.GetKeyDown(KeyCode.G))
        {
            GameObject currentObj;
            currentObj = hand.transform.GetChild(0).gameObject;
            currentObj.GetComponent<Rigidbody>().isKinematic = false;

            currentObj.gameObject.GetComponent<Rigidbody>().AddForce(currentObj.transform.up * -10f, ForceMode.Impulse);
           currentObj.gameObject.transform.parent = null;
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, lookDistance, layerMask))
        {
            gmSc.infoText.text = "press Left click to pick Up " + hit.collider.gameObject.name;

            if (hand.transform.childCount == 0 && Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.collider.gameObject.transform.parent = hand.transform;
                hit.collider.gameObject.transform.position = hand.transform.position;
                hit.collider.gameObject.transform.rotation = hand.transform.rotation;
            }
        }
        else
        {
            if (triggerColl == null)
           {
              gmSc.infoText.text = " ";
           }
         
        }
        Debug.DrawRay(cam.transform.position, cam.transform.forward * lookDistance, Color.yellow);
      
    }

    void OnTriggerEnter(Collider other)
    {
        triggerColl = other;

        if (other.gameObject.CompareTag("Key"))
        {
            gmSc.hasKey =true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Lock"))
        {
            if (gmSc.hasKey)
            {
                gmSc.infoText.text = "Press E to Interract";
            }
            else
            {
                  gmSc.infoText.text = "you need a key to open this";
            }
        }
        
        if(other.gameObject.CompareTag("lever"))
        {
            gmSc.infoText.text = "press E to switch";
        }
    }

    void OnTriggerExit(Collider other)
    {
        triggerColl = null;
        
        
    }
}
