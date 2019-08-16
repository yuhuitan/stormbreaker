using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ActivateUI();
        }
        
    }

    public void ActivateUI()
    {
        menu.SetActive(true);
    }

    public void DeactivateUI()
    {
        menu.SetActive(false);
    }
}
