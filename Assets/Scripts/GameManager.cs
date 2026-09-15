using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalKoin;
    private int koinTerkumpul = 0;

    public TextMeshProUGUI skorText;
    public GameObject TextYouWin;

    void Start()
    {
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        koinTerkumpul = 0;

        TextYouWin.SetActive(false);

        UpdateSkorText();
    }

    public void KoinTerkumpul()
    {
        koinTerkumpul++;

        Debug.Log("Koin terkumpul: " + koinTerkumpul);

        UpdateSkorText();

        if (koinTerkumpul == totalKoin)
        {
            Menang();
        }
    }

    void UpdateSkorText()
    {
        skorText.text = "Skor : " + koinTerkumpul;
    }

    void Menang()
    {
        Debug.Log("Kamu Menang!");

        // Munculkan tulisan YOU WIN
        TextYouWin.SetActive(true);

        // Pause game
        Time.timeScale = 0f;
    }
}