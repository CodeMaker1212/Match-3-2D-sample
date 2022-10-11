using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{  
    protected void Enable() => gameObject.SetActive(true);

    protected void Disable() => gameObject.SetActive(false);
}