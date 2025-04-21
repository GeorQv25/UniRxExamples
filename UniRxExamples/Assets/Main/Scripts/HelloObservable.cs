using UniRx;
using UnityEngine;


public class HelloObservable : MonoBehaviour
{
    private void Start()
    {
        // Каждый кадр будет вызываться лямбда и в консоль пойдёт Log
        Observable
            .EveryUpdate()
            .Subscribe(_ => Debug.Log("Hello, UniRx! frame: " + Time.frameCount))
            .AddTo(this);   // автоматически отписывается при уничтожении объекта
    }
}
