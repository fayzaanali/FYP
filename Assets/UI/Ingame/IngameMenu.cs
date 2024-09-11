using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IngameMenu : MonoBehaviour
{
    public Button closeButton;

    public Slider fovSlider;
    public Camera cam, weaponCam;
    public GameObject ingameMenu;
    public TextMeshProUGUI displayFov;
    bool isMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        ingameMenu.SetActive(false);
        //fovSlider.value = 60;
        isMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        setFov();
    }

    void setFov()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isMenuActive == false)
        {
            setActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isMenuActive == true)
        {
            setActive(false);
        }

        closeButton.GetComponent<Button>().onClick.AddListener(delegate { setActive(false); });
        cam.fieldOfView = fovSlider.value;
        weaponCam.fieldOfView = fovSlider.value;
        displayFov.text = fovSlider.value.ToString();
    }

    void setActive(bool setActive)
    {
        if (setActive == false)
        {
            ingameMenu.SetActive(setActive);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            isMenuActive = false;
        } else if (setActive == true)
        {
            Cursor.lockState = CursorLockMode.None;
            ingameMenu.SetActive(setActive);
            Time.timeScale = 0;
            isMenuActive = true;
        }
    }
}
