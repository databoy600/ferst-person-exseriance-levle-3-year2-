using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageScript : MonoBehaviour
{
  public GameObject Sword;
    //public transform attackpoint;
    // public float attackRange = 0.5f;
    public int damage;
    public float damageAmount;
    public float attackRate;
    public float attackDelay;
    
    GameObject EnemyObject;

   

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
           Attack();
        }
    }
      void Attack(){
        EnemyObject.GetComponent<Helath>().hp -= damage;
         attackDelay = Time.time + attackRate;
    }

  
}
