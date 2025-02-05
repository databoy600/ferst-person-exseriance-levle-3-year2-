using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageScript : MonoBehaviour
{
    //public transform attackpoint;
    // public float attackRange = 0.5f;
    public float damageAmount;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //  void Attack(){
    //     playerObject.GetComponent<EnemyHealth>().health -= damageAmount;
    //     attackDelay = Time.time + attackRate;
    // }

  
}
