using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGameStart : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name=="TitleScreen")
        {
            SceneManager.LoadScene("CharacterCreation", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "CharacterCreation")
        {
            SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        }
    }


}
