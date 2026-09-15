using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public float kecepatan = 5f;
    public int skor = 0;
    private GameManager gameManager;

    private Vector2 arahGerak; //nilai dari action "Move"

    // Dipanggil OTOMATIS oleh komponen Player Input
    // saat action "Move" pada inputSystem_Actions aktif.
    // METHOD : On + nama action = OnMove
    void OnMove(InputValue value)
    {
        // TODO : Ambil nilai dari Vector2 dari input, simpan ke arahGerak
        arahGerak = value.Get<Vector2>();
    }

    // Dipanggil otomatis saat Player menyentuh objek ber-Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO : Jika player menyentuh objek dengan tag "Coin"
        // maka hapus objek tersebut
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);

            if (gameManager != null)
            {
                gameManager.KoinTerkumpul();
            }
        }
    }

    void Start()
    {
        arahGerak = Vector2.zero;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO : Gerakkan objeck menggunkan arahGerak
        // Ingat kecepatan harus dikalikan dengan Time.deltaTime agar gerakan tidak tergantung frame rate
        transform.position += new Vector3(arahGerak.x, arahGerak.y, 0) * kecepatan * Time.deltaTime;
    }
}
