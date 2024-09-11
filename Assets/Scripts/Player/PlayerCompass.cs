using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCompass : MonoBehaviour
{
    public RawImage compassImg;
    public Transform player;
    public TextMeshProUGUI compassDirText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        compassImg.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1, 1);
        Vector3 forward = player.transform.forward;
        forward.y = 0;
        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));

        int displayAngle = Mathf.RoundToInt(headingAngle);

        switch (displayAngle)
        {
            case 0:
                compassDirText.text = "N";
                break;

            case 360:
                compassDirText.text = "N";
                break;

            case 45:
                compassDirText.text = "NE";
                break;

            case 90:
                compassDirText.text = "E";
                break;

            case 130:
                compassDirText.text = "SE";
                break;

            case 180:
                compassDirText.text = "S";
                break;

            case 225:
                compassDirText.text = "SW";
                break;

            case 270:
                compassDirText.text = "W";
                break;

            default:
                compassDirText.text = headingAngle.ToString();
                break;
        }
    }
}
