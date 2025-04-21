using UniRx;
using UnityEngine;

public class HealthService : MonoBehaviour
{
    // ��������� �������� ��������
    [SerializeField] private int startHealth = 100;
    // ���������� ��������, �� ������� ����� �������������
    public ReactiveProperty<int> Health { get; private set; }


    private void Awake()
    {
        // �������������� ��������
        Health = new ReactiveProperty<int>(startHealth);
    }

    // ����� ��� �����
    public void TakeDamage(int amount)
    {
        Health.Value = Mathf.Max(Health.Value - amount, 0);
    }

    // ����� ��� �������
    public void Heal(int amount)
    {
        Health.Value = Mathf.Min(Health.Value + amount, startHealth);
    }
}
