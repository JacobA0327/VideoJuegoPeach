using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    [SerializeField] private string finalSceneName = "FINAL"; // Nombre de la escena final

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el objeto que colisiona tiene el tag "Player"
        if (collision.transform.CompareTag("Player"))
        {
            // Cambia a la escena final especificada por nombre
            SceneManager.LoadScene(finalSceneName);
        }
    }
}
