using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()//apelata de fiecare data cand atingem butonul de start, o facem public pentru a o putea apela de la buton
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//incarcam nivelul urmator luand indexul nivelului curent incarcat
    }

    public void QuitGame()//apelata de fiecare data cand atingem butonul de quit, o facem public pentru a o putea apela de la buton
    {
        Debug.Log("QUIT!");//verificare functionalitate in unity
        Application.Quit();//se va inchide programul
    }
}
