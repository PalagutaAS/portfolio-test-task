using UnityEngine;

public interface IParticleService
{
    void Play(Vector3 position);
}
public class ParticleService : IParticleService
{
    private ParticleSystem _particle;
    public ParticleService(ParticleSystem particle)
    {
        _particle = Object.Instantiate(particle);
    }

    public void Play(Vector3 position)
    {
        _particle.transform.position = position;
        _particle.Play();
    }
}
