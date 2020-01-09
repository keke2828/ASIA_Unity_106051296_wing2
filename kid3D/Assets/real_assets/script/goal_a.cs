using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_a : MonoBehaviour
{
    private int n = 0;

    public GameObject tt;
    public GameObject wt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            other.transform.GetComponent<itemset_a>().iitem();
            n++;
            if (n >= 3)
            {
                tt.SetActive(false);
                wt.SetActive(true);
            }
        }
    }
}
