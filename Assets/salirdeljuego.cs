using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salirdeljuego : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }

}
