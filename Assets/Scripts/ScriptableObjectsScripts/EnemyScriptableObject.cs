using UnityEngine;


[CreateAssetMenu(fileName ="Enemy", menuName = "Enemy", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public int MaxHealth;
    public int ScoreValue;
    public float Speed;
    public float TimeBtwShots;
    public GameObject[] PowerUpsPrefabs;
    public GameObject BulletPrefab;
    public GameObject HitParticles;
}
