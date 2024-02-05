using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null) {
            TakeDamage(damageDealer.GetDamage());
            PlayExplosionEffect();
            ShakeCamera();
            damageDealer.Hit();
            
        }
    }

    private void TakeDamage(int damage){
        health -= damage;
        if (health == 0) {
            Destroy(gameObject);
        }
    }

    void PlayExplosionEffect(){
        if (explosionEffect != null) {
            ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            audioPlayer.PlayExplosionClip();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera(){
        if (cameraShake != null && applyCameraShake) {
            cameraShake.Play();
        }
    }
}
