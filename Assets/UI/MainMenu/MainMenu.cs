using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button playBtn;
    //public SceneManager loadScene;
    void Start()
    {
        playBtn.GetComponent<Button>().onClick.AddListener(loadScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        SceneManager.LoadScene(1);
    }
}
