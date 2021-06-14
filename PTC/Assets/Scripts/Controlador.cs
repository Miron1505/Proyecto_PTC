using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public void CambiarEscena(string nivel1)
    {
        print("Cambiando a la escena" + nivel1);
        SceneManager.LoadScene(nivel1);
    }
    public void Salir()
    {
        print("Saliendo del juego ");
        Application.Quit();
    }
}
