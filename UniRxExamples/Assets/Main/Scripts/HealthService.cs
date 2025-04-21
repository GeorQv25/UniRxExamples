using UniRx;
using UnityEngine;

public class HealthService : MonoBehaviour
{
    // Начальное значение здоровья
    [SerializeField] private int startHealth = 100;
    // Реактивное свойство, на которое будем подписываться
    public ReactiveProperty<int> Health { get; private set; }


    private void Awake()
    {
        // Инициализируем свойство
        Health = new ReactiveProperty<int>(startHealth);
    }

    // Метод для урона
    public void TakeDamage(int amount)
    {
        Health.Value = Mathf.Max(Health.Value - amount, 0);
    }

    // Метод для лечения
    public void Heal(int amount)
    {
        Health.Value = Mathf.Min(Health.Value + amount, startHealth);
    }
}
