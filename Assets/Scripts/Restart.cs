using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
