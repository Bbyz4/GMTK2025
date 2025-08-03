using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticlesPrefab;

    public void PlayDeathParticles()
    {
        if (deathParticlesPrefab == null)
        {
            Debug.LogError("No particles!");
            return;
        }

        ParticleSystem deathParticlesInstance = Instantiate(deathParticlesPrefab, transform.position, Quaternion.Euler(0, 0, -45f));

        deathParticlesInstance.Play();

        Destroy(deathParticlesInstance, 20f);
    }
}
