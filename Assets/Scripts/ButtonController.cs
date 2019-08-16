using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    
    public GameObject menu;
    private GameObject testing;

    public void StartGame()
    {

        DestroyObjects();
        SceneManager.LoadScene("Cutscene1");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    private void DestroyObjects()
    {
        GameManager.ResetGame();
        GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
        if (GameController != null)
        {
            Destroy(GameController);
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            for (int i = 0; i < players.Length; i++)
            {
                Destroy(players[i]);
            }
        }
    }

    public void ToLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ToLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ToLevelThree()
    {
        SceneManager.LoadScene("Level3");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void CancelMenu()
    {
        gameObject.transform.parent.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.transform.parent.gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.transform.parent.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Time.timeScale = 1f;
    }

    public void OpenMenu()
    {
        menu.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        menu.gameObject.GetComponent<CanvasGroup>().interactable = true;
        menu.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Time.timeScale = 0f;

    }

    public void ToRule()
    {
        SceneManager.LoadScene("InstructionScreen");
    }


}
