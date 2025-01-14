using UnityEngine;

public partial class Explosion : MonoBehaviour
{
    public void Despawn()
    {
        MainSystem.Instance.PoolManager.Despawn(gameObject);
    }
    public void PlaySoundEffect()
    {
        MainSystem.Instance.SoundManager.SoundController.SoundEffect.PlaySFX(SfxClipName.Explosion);
    }
}