using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] public int hp = 100;
    public float ms = 2f;
    protected Transform player;
    public int damageValue = 10;

    // State Machine //
    [Header("Pengaturan State Machine")]
    [SerializeField] private float jarakDeteksi = 5f; //Masuk chasing
    [SerializeField] private float jarakSerang = 1.2f; //Masuk attacking
    [SerializeField] private float jedaSerang = 1f; //Detik antar serang

    [Header("Idle")]
    [SerializeField] private float kecepatanPutarIdle = 90f;

    [Header("Patrol")]
    [SerializeField] private float kecepatanPatrol = 1f;

    // State sekarang -- mulai dari Idle //
    private ZombieState state = ZombieState.Idle;
    private float waktuSerangTerakhir;

    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        waktuSerangTerakhir = -jedaSerang;
    }

    void Update()
    {
        // Langkah A : tentukan state (aturan pindah)
        PeriksaTransisi();

        // Langkah B : jalankan perilaku sesuai state sekarang
        switch (state)
        {
            // case ZombieState.Idle:
            //     PerilakuIdle();
            //     break;
            // case ZombieState.Patrol:
            //     PerilakuPatrol();
            //     break;
            // case ZombieState.Chasing:
            //     PerilakuChasing();
            //     break;
            // case ZombieState.Attacking:
            //     PerilakuAttacking();
            //     break;
        }
    }

    // Perilaku Method //

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.position);
    }

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if (jarak <= jarakSerang)
        {
            state = ZombieState.Attacking; // sangat dekat  -> serang
        }
        else if (jarak <= jarakDeteksi)
        {
            state = ZombieState.Chasing; // terlihat player -> kejar
        }
        else
        {
            state = ZombieState.Patrol; // player jauh -> patrol
        }
    }

    void PerilakuIdle()
    {
        transform.Rotate(0f, 0f, kecepatanPutarIdle * Time.deltaTime);
    }

    void PerilakuPatrol()
    {
        // Debug.Log("Enemy sedang patrol");
    }

    void PerilakuChasing()
    {
        Debug.Log("Enemy sedang chasing player");
        Kejar();
    }

    void PerilakuAttacking()
    {
        Debug.Log("Enemy sedang attacking player");

        if (player == null)
        {
            return;
        }

        // Cek apakah cooldown serangan sudah selesai
        if (Time.time - waktuSerangTerakhir >= jedaSerang)
        {
            Serang(player.gameObject);
            // Catat waktu serangan terakhir
            waktuSerangTerakhir = Time.time;
        }
    }

    // Perilaku Method //

    public void Kejar()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Serang(collision.gameObject);
    //     }
    // }

    public virtual void Serang(GameObject target)
    {
        Debug.Log("Enemy menyerang!");

        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log($"{gameObject.name} menyerang {target.name} sebesar {damageValue} damage");
            damageable.KenaDamage(damageValue);
        }
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;

        hp = Mathf.Max(hp, 0); // Pastikan hp tidak negatif

        Debug.Log($"{gameObject.name} kena damage {jumlah}, HP sisa: {hp}");

        if (hp <= 0)
        {
            Mati();
        }
    }

    private void Mati()
    {
        Debug.Log($"{gameObject.name} mati!");
        Destroy(gameObject);
    }

}
