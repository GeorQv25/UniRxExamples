using UnityEngine;
using UniRx;


public class HealthTester : MonoBehaviour
{
    private HealthService healthService;


    private void Awake()
    {
        healthService = FindFirstObjectByType<HealthService>();
    }

    private void Start()
    {
        // Каждые 1.5 секунды отнимаем 10 ед. здоровья
        Observable
            .Interval(System.TimeSpan.FromSeconds(1.5f))
            .Subscribe(_ => healthService.TakeDamage(10))
            .AddTo(this);
    }
}