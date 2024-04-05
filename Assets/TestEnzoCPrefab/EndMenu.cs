using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public GameObject QuitMenu;

    CanvasGroup endMenuGroup;

    // Start is called before the first frame update
    void Start()
    {
        EndMenuButton();
        endMenuGroup = GameObject.Find("EndCanvas").GetComponent<CanvasGroup>();
    }

    public void EndMenuButton()
    {
        // Show Main Menu
        QuitMenu.SetActive(true);
    }

    public void RestartButton()
    {
        endMenuGroup.alpha = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
