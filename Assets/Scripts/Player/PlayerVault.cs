using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerVault : MonoBehaviour
{
    private int vaultLayer;
    public Camera cam;
    public float playerHeight;
    public float playerRadius;
    public LayerMask vaultLayerMask;
    public TextMeshProUGUI displayVault;
    public LayerMask displayJumpLayer;

    // Start is called before the first frame update
    void Start()
    {
        vaultLayer = vaultLayerMask;
        vaultLayer = ~vaultLayer;
    }

    // Update is called once per frame
    void Update()
    {
        displayJump();
        vault();
    }

    private void vault()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var firstHit, 2f, vaultLayer))
            {
                if (Physics.Raycast(firstHit.point + (cam.transform.forward * playerRadius) + (Vector3.up * 1.5f * playerHeight), Vector3.down, out var secondHit, playerHeight))
                {
                    StartCoroutine(lerpVault(secondHit.point, .5f));
                }
            }
        }
    }

    IEnumerator lerpVault(Vector3 targetPosition, float dur)
    {
        float time = 0;
        Vector3 startPos = transform.position;

        while(time < dur)
        {
            transform.position = Vector3.Lerp(startPos, targetPosition, time / dur);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    void displayJump()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 2f, displayJumpLayer))
        {
            displayVault.text = "Space to Jump";
        }
    }
}
