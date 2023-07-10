using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour, IPointerDownHandler
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Обработка нажатия пальцем
        //Debug.Log("Палец нажат!");
    }
}
