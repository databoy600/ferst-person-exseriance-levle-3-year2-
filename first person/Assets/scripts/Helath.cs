using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helath : MonoBehaviour
{
    public int hp;

    int maxHp;

    public bool respwan;

    public float respwanTime;
    
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if(!active)
            {
                StartCoroutine(RespaweObject());
            }
            else if (!respwan)
            {
                Destroy(gameObject);
            }
        }
    }


    IEnumerator RespaweObject()
    {
        active = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(respwanTime);

        gameObject.GetComponent<MeshRenderer>().enabled = true;
        hp = maxHp;
        active = false;
    }
}
