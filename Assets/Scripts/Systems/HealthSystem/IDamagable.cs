namespace Systems.HealthSystems
{
    public interface IDamagable
    {
        void TakeDamage(float dmg);
        void Destroy();
    }

}