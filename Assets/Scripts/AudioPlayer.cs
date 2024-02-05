using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingEffect;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosion;
    [SerializeField][Range(0f, 1f)] float explosionVolume = 1f;

    public void PlayShootingClip()
    {
        if (shootingEffect != null)
        {
            AudioSource.PlayClipAtPoint(shootingEffect, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayExplosionClip()
    {
        if (explosion != null)
        {
            AudioSource.PlayClipAtPoint(explosion, Camera.main.transform.position, explosionVolume);
        }
    }
}
