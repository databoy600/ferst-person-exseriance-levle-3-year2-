using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] GameObject FlashLightLight;
    private bool FlashLightActive = false;
    // Start is called before the first frame update
    void Start()
    {
        FlashLightLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
          if (FlashLightActive == false)
          {
             FlashLightLight.gameObject.SetActive(true);
             FlashLightActive = true;
          }
          else
          {
             FlashLightLight.gameObject.SetActive(false);
             FlashLightActive = false;
          }
        }
    }
}
