using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class DiceResult : MonoBehaviour
{
    private Rigidbody rb;
    public Text resultText; // Referência ao elemento de texto para exibir o resultado
    private List<string> results = new List<string>(); // Lista para armazenar os resultados com timestamps

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        resultText.gameObject.SetActive(false); // Desativa o texto inicialmente
        LoadResults(); // Carrega resultados anteriores
    }

    void Update()
    {
        if (rb.IsSleeping() && !resultText.gameObject.activeInHierarchy)
        {
            int result = CheckTopFace();
            string resultEntry = GetResultEntry(result);
            results.Add(resultEntry);
            UpdateResultText(resultEntry);
            resultText.gameObject.SetActive(true); // Ativa o texto quando o dado para
            SaveResults(); // Salva os resultados
        }
        else if (!rb.IsSleeping() && resultText.gameObject.activeInHierarchy)
        {
            resultText.gameObject.SetActive(false); // Desativa o texto quando o dado está rolando
        }
    }

    int CheckTopFace()
    {
        Transform highestFace = null;
        float highestY = float.MinValue;

        foreach (Transform child in transform)
        {
            if (child.position.y > highestY)
            {
                highestY = child.position.y;
                highestFace = child;
            }
        }

        if (highestFace != null)
        {
            int result;
            if (int.TryParse(highestFace.name, out result))
            {
                return result; // Retorna o resultado se a conversão for bem-sucedida
            }
        }
        return 0; // Retorna um valor padrão (0) se nenhum resultado for encontrado
    }

    void UpdateResultText(string resultEntry)
    {
        resultText.text = "Result: " + resultEntry;
    }

    public void ShowPreviousResults()
    {
        LoadResults(); // Carrega os resultados salvos

        string allResults = "Previous Results:\n";
        for (int i = results.Count - 1; i >= 0; i--)
        {
            allResults += results[i] + "\n";
        }
        resultText.text = allResults;
    }

    public void SaveResults()
    {
        string resultsString = string.Join(",", results);
        PlayerPrefs.SetString("DiceResults", resultsString);
        PlayerPrefs.Save();
    }

    public void LoadResults()
    {
        string resultsString = PlayerPrefs.GetString("DiceResults", "");
        if (!string.IsNullOrEmpty(resultsString))
        {
            results = new List<string>(resultsString.Split(','));
        }
    }

    string GetResultEntry(int result)
    {
        // Gera uma entrada de resultado com timestamp
        DateTime timestamp = DateTime.Now;
        string timestampStr = timestamp.ToString("yyyy-MM-dd");
        return $"{result} ({timestampStr})";
    }
}