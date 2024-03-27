using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteIntensity : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;

    private void Start()
    {
        volume.profile.TryGet(out vignette);
        vignette.intensity.value = 0;
    }

    public void IncreaseVignetteIntensity()
    {
        if(vignette != null)
        {
            vignette.intensity.value += 0.05f;
        }
    }
}
