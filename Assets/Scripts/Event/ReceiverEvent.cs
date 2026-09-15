using UnityEngine;

public class ReceiverEvent : MonoBehaviour
{
    void OnEnable()
    {
        PemancarEvent.TekanTombol += TampilkanPesan;
    }

    void OnDisable()
    {
        PemancarEvent.TekanTombol -= TampilkanPesan;
    }

    void TampilkanPesan()
    {
        Debug.Log("Event diterima! Menampilkan pesan dari ReceiverEvent.");
    }
}
