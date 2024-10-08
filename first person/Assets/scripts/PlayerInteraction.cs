using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
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
        if (triggerColl == null)
        {
            gmSc.infoText.text = " ";
        }
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
