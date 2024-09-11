using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public GameObject map;
    bool isMapActive;

    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(false);
        isMapActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isMapActive)
        {
            map.SetActive(true);
            isMapActive = true;
        } else if (Input.GetKeyDown(KeyCode.F) && isMapActive)
        {
            map.SetActive(false);
            isMapActive = false;
        }
    }
}
