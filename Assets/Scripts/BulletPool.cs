using UnityEngine;

namespace Assets.Scripts
{
    public class BulletPool : MonoBehaviour {

        private GameObject[] _enemys;
        public GameObject BulletPrefab;
        public GameObject Hero;

        public int MaxBulletsOnScreen = 20;
        private readonly Vector2 _initBulletPosition = new Vector2(-15f, -25f); // Offscreen
        private float _timeSinceLastSpawned;

        public float SpawnXPosition = 0f;
        public float SpawnYPosition = 0f;

        private int _currentColumn = 0;

        // Use this for initialization
        void Start()
        {
            _enemys = new GameObject[MaxBulletsOnScreen];
            for (int i = 0; i < MaxBulletsOnScreen; i++)
            {
                //BulletPrefab.
                _enemys[i] = Instantiate(BulletPrefab, _initBulletPosition, Quaternion.identity);
                var localCollider = _enemys[i].GetComponent<PolygonCollider2D>();
                if (localCollider != null)
                {
                    localCollider.isTrigger = true;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            _timeSinceLastSpawned += Time.deltaTime;
            if (_timeSinceLastSpawned >= GameControll.Instance.FireRepeatingTime)
            {
                var heroPosition = Hero.transform.position;
                _enemys[_currentColumn].transform.position = heroPosition;
                _currentColumn = ++_currentColumn % MaxBulletsOnScreen;
                _timeSinceLastSpawned = 0;
                var localCollider = _enemys[_currentColumn].GetComponent<PolygonCollider2D>();
                if (localCollider != null)
                {
                    localCollider.isTrigger = false;
                }
            }
        }
    }
}
