using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public DiceResult diceResultScript;
    public GameObject resultPanel; // Painel para exibir resultados

    void Start()
    {
        if (resultPanel != null)
            resultPanel.SetActive(false);
    }

    public void OnShowResultsButton()
    {
        diceResultScript.ShowPreviousResults();
        if (resultPanel != null)
            resultPanel.SetActive(true);
    }

    public void OnHideResultsButton()
    {
        if (resultPanel != null)
            resultPanel.SetActive(false);
    }

    public void OnRestartButton()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}