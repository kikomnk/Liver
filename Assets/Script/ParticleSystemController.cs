using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    private ParticleSystem particleSystem;

    void Start()
    {
        // Get the Particle System component attached to this GameObject
        particleSystem = GetComponent<ParticleSystem>();

        if (particleSystem == null)
        {
            Debug.LogError("No Particle System found on this GameObject.");
            return;
        }

        // Configure the Particle System
        ConfigureParticleSystem();
    }

    void ConfigureParticleSystem()
    {
        var main = particleSystem.main;
        main.loop = true;
        main.startLifetime = 2.0f;
        main.startSpeed = 5.0f;
        main.startSize = 0.5f;
        main.startColor = Color.red;

        var emission = particleSystem.emission;
        emission.rateOverTime = 10;

        var shape = particleSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Cone;
        shape.angle = 25;
        shape.radius = 0.5f;

        var colorOverLifetime = particleSystem.colorOverLifetime;
        colorOverLifetime.enabled = true;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.blue, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
        );
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);

        var sizeOverLifetime = particleSystem.sizeOverLifetime;
        sizeOverLifetime.enabled = true;
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, 0.1f);
        curve.AddKey(1.0f, 1.0f);
        sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1.0f, curve);

        particleSystem.Play();
    }
}
