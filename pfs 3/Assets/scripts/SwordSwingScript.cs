using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingScript : MonoBehaviour
{
    public GameObject Sword;

    public bool CanAttack = true; 
    public float AttckCooldwon = 1.0f;

    public int damage;
  //  public bool didDamage;
    

    // Start is called before the first frame update
//    void OnTriggerEnter(Collider other)
//    {
//      if(other.GameObject>CompareTag("Sword"))
//      {
       
//      }
//    }


   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SwordSwing());
        }
        if (CanAttack)
        {
            SwordAttack();
        }
    }

    IEnumerator SwordSwing()
    {
        Sword.GetComponent<Animator>().Play("SwordSwing");
        yield return new WaitForSeconds(1.0f);
        Sword.GetComponent<Animator>().Play("New State");
    }


    public void SwordAttack()
    {
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
       // AudioSource ac = GetComponent<AudioSource>();
       
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttckCooldwon);
        CanAttack = true;
    }
}
