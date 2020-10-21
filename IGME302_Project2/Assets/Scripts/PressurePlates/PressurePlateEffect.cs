using UnityEngine;

[RequireComponent(typeof(PressurePlate))]
public abstract class PressurePlateEffect : MonoBehaviour
{
    private PressurePlate pressurePlate;

    private void Awake()
    {
        pressurePlate = GetComponent<PressurePlate>();
    }

    private void OnEnable()
    {
        pressurePlate.OnActivate += ActivateEffect;
    }

    private void OnDisable()
    {
        pressurePlate.OnActivate -= ActivateEffect;
    }

    public abstract void ActivateEffect();
}
