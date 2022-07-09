using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("‰Ÿ‚³‚ê‚½!");  // ƒƒO‚ğo—Í
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
