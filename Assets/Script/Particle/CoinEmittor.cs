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

    public void Emit(Vector3 Position, int amount)
    {
        ParticleEmittor.transform.position = Position;
        ParticleEmittor.Emit(amount);
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
