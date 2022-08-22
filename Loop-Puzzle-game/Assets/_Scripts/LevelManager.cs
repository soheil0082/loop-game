using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextLevel);
    }
}
