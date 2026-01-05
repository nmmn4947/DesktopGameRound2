using UnityEngine;

public class CoinEmittor : MonoBehaviour
{
    private MoneyManager Manager;
    [SerializeField] private GameObject CoinParticle;
    private GameObject CoinParticleInstance;
    private ParticleSystem ParticleEmittor;

    public void Start()
    {
        Manager = MoneyManager.Instance();

        CoinParticleInstance = Instantiate(CoinParticle, Vector3.zero, Quaternion.identity);
        ParticleEmittor = CoinParticleInstance.GetComponent<ParticleSystem>();

        Manager.OnPassiveIncome += Emit;
        Manager.OnActiveIncome += Emit;
    }

    public void Emit(Vector3 position, int amount)
    {
        ParticleEmittor.transform.position = position;

        var emission = ParticleEmittor.emission;

        ParticleSystem.Burst burst;
        burst = emission.GetBurst(0);
        burst.count = amount;
        emission.SetBurst(0, burst);

        ParticleSystem.MainModule pmm = ParticleEmittor.main;
        pmm.startSize = 0.2f;

        ParticleEmittor.Play();
    }


    public void OnDestroy()
    {
        Manager.OnPassiveIncome -= Emit;
        Manager.OnActiveIncome -= Emit;

        CoinParticleInstance = null;
        ParticleEmittor = null;
        Manager = null;
    }
}
