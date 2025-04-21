using UniRx;
using UnityEngine;

public class HealthService : MonoBehaviour
{
    [SerializeField] private int _startHealth = 100;
    [SerializeField] private int _startArmor = 50;

    public ReactiveProperty<int> Health { get; private set; }
    public ReactiveProperty<int> Armor { get; private set; }


    private void Awake()
    {
        Health = new ReactiveProperty<int>(_startHealth);
        Armor = new ReactiveProperty<int>(_startArmor);
    }

    public void TakeDamage(int amount)
    {
        int left = Mathf.Max(0, Armor.Value - amount);
        int damage = amount - (Armor.Value - left);
        Armor.Value = left;
        if (damage > 0)
        {
            Health.Value = Mathf.Max(Health.Value - damage, 0);
        }
    }

    public void Heal(int amount)
    {
        Health.Value = Mathf.Min(Health.Value + amount, _startHealth);
    }

    public void RestoreArmor(int amount)
    {
        Armor.Value = Mathf.Min(Armor.Value + amount, _startArmor);
    }

    public void ResetStats()
    {
        Health.Value = _startHealth;
        Armor.Value = _startArmor;
    }
}
