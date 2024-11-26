using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacastWepon : MonoBehaviour
{
   public int damage;

   public float shootDistance;

   public LayerMask layerMask;

   public GameObject cam;

   RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * shootDistance, Color.red);

        if (transform.parent != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, shootDistance, layerMask))
                {
                    hit.collider.gameObject.GetComponent<Helath>().hp -= damage;
                }
            }
        }
    }
}
