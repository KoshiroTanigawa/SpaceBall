using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
