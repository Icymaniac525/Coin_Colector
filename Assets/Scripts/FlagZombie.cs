using UnityEngine;

public class FlagZombie : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool flag = true;

    public override void Serang(GameObject target)
    {
        Debug.Log("FlagZombie menyerang!");

        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.KenaDamage(damageValue);
        }
    }
}
