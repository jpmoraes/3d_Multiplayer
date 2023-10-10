using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    Animator m_Animator;
    public int life = 100;
    public int moeda = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator=GetComponent<Animator>();
    }
        // Update is called once per frame
    void Update()
    {
        float moveV = Input.GetAxis("Vertical");
        transform.Translate(0,0,moveV * Time.deltaTime * speed);

        float moveH = Input.GetAxis("Horizontal");
        transform.Rotate(0, moveH * Time.deltaTime * speedRotation, 0);

       
        if(moveH > 0 || moveH < 0 || moveV > 0 || moveV <0)
        {
          
            m_Animator.SetBool("walk", true);

        }
        else
        {
            m_Animator.SetBool("walk", false);
        }



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            life -= 25;

            if (life <= 0)
            {
                life = 100;
                this.transform.position = new Vector3(494.660004f, 3.94000006f, 253.589996f); //voltar inicio fase
                this.transform.eulerAngles = new Vector3(0f, 185.991852f, 0f); //voltar camera para frente
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "moeda")
        {
            moeda += 1;

        }
    }

}
