using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wp;
    public GameObject HitParricle;


    private void OnTriggerEnter(collider other)
    {
        if(other.tag == "Enemt")
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");

            Instantiate(HitParricle, new Vector3(other.transform.position.x, transform.position.y,
            other.transform.position.z); other.transform.rotation);

        }
    }



}
