using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contrl_b : MonoBehaviour
{
    public Animator ani;
    public Rigidbody rig;
    public GameObject movetar;

    public float speed1;
    public float speed2;

    bool walk = false;
    bool run = false;
    bool fly = false;

    bool canm = true;
    public float imtime;
    private bool is_catch;
    private bool is_trigg;
    private itemset_a targ;
    public GameObject m_tar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fly&&!is_catch)
            {
                fly = false;
            }
            else
            {
                fly = true;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2.5f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -2.5f, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            walk = true;
            if (Input.GetKey(KeyCode.Q))
            {
                run = true;
                rig.velocity = (movetar.transform.position - transform.position) * Time.deltaTime * speed2;
            }
            else
            {
                run = false;
                rig.velocity = (movetar.transform.position - transform.position) * Time.deltaTime * speed1;
            }

        }
        else
        {
            walk = false;
            run = false;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && fly && canm) 
        {
            canm = false;
            ani.SetTrigger("att");
            Invoke("m", 0.25f);

            if (is_trigg && !is_catch)
            {
                is_catch = true;
                targ.rig.useGravity = false;
                targ.coli.enabled = false;
                targ.target = m_tar;
            }
            else if (is_catch)
            {
                is_catch = false;
                targ.rig.useGravity = true;
                targ.coli.enabled = true;
                targ.target = null;
            }

        }

        ani.SetBool("walk", walk);
        ani.SetBool("run", run);
        ani.SetBool("fly", fly);
    }

    void m()
    {
        canm = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "item" && !is_catch)
        {
            is_trigg = true;
            targ = other.transform.GetComponent<itemset_a>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            is_trigg = false;
        }
    }
}
