namespace Sample
{
    public interface IDamagable
    {
        public float Health { get; set; }
        public int Defence { get; set; }
        public void Die();
        public void TakeDamage();
        public void RestoreHealth();
    }
}