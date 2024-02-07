using UnityEngine;
using UnityEngine.Events;

public class UIEventHandler : MonoBehaviour
{
    public UnityEvent onFadeComplete;

    public void OnFadeComplete()
    {
        onFadeComplete.Invoke();
    }
}
