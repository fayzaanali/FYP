using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollect : MonoBehaviour
{
    // Start is called before the first frame update
    int item;
    public TextMeshProUGUI displayCollect;

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "collect")
        {
            item++;
            Debug.Log("item collected");
            Destroy(coll.gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayCollect.text = item.ToString() + " Collected";
    }
}
