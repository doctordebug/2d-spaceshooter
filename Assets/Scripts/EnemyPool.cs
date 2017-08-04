using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyPool : MonoBehaviour {

        private GameObject[] _enemys;
        private readonly Vector2 objectPoolPosition = new Vector2(-15f, -25f); // Offscreen
        private int _currentColumn = 0;
        private float _timeSinceLastSpawned;

        public GameObject EnemyPrefab;
        public int EnemyCount = 5;
        public float SpawnXPosition = 10f;
        public float MinSpawnXPosition = -4f;
        public float MaxSpawnXPosition = 4;
        public float EnemyRepeatingRate = 4;



        // Use this for initialization
        void Start () {
            _enemys = new GameObject[EnemyCount];
            for(int i = 0; i < EnemyCount; i++)
            {
                _enemys[i] = (GameObject)Instantiate(EnemyPrefab, objectPoolPosition, Quaternion.identity);
                var collider =  _enemys[i].GetComponent<PolygonCollider2D>();
                if (collider != null) {
                    collider.isTrigger = true;
                }
            }
        }
	
        // Update is called once per frame
        void Update () {
            _timeSinceLastSpawned += Time.deltaTime;
            if (_timeSinceLastSpawned >= EnemyRepeatingRate)
            {
                _timeSinceLastSpawned = 0;
                float spawnYPosition = Random.Range(MinSpawnXPosition, MaxSpawnXPosition);
                _enemys[_currentColumn].transform.position = new Vector2(SpawnXPosition, spawnYPosition);
                _enemys[_currentColumn].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                var collider = _enemys[_currentColumn].GetComponent<PolygonCollider2D>();
                if (collider != null)
                {
                    collider.isTrigger = false;
                }
                _currentColumn = ++_currentColumn % EnemyCount; 
            }
        }
    }
}
