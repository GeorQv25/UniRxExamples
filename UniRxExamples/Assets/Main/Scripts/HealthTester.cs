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
        Observable
            .Interval(System.TimeSpan.FromSeconds(1.5f))
            .Subscribe(_ => healthService.TakeDamage(10))
            .AddTo(this);
    }
}