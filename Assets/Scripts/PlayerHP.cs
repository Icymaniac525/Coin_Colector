using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] public int maxHp;

    private int currentHp;

    [Header("Invincibility")]
    [SerializeField] private float waktuInvincible = 1f;

    private bool isInvincible = false;

    void Start()
    {
        currentHp = maxHp;
    }

    public void KenaDamage(int jumlah)
    {

        if (isInvincible)
        {
            Debug.Log("Player sedang invincible, tidak menerima damage.");
            return;
        }

        currentHp -= jumlah;
        Debug.Log($"Player kena damage {jumlah}, HP sisa: {currentHp}");

        if (currentHp <= 0)
        {
            currentHp = 0;
            Mati();
            return;
        }

        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        isInvincible = true;
        Debug.Log("Player menjadi invincible.");

        yield return new WaitForSeconds(waktuInvincible);

        isInvincible = false;
        Debug.Log("Player tidak lagi invincible.");
    }

    private void Mati()
    {
        Debug.Log("Player mati!");
        // Tambahkan logika untuk menangani kematian pemain, misalnya memuat ulang level atau menampilkan layar game over.
        Destroy(gameObject);
    }
}
