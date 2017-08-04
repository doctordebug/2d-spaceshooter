using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour {

        public float EnemySpeed = 0.02f;
        private PolygonCollider2D _rb2D;
        private readonly Vector2 _objectPoolPosition = new Vector2(-15f, -25f);
        private int _sign = 1;

        // Use this for initialization
        void Start()
        {
            _rb2D = GetComponent<PolygonCollider2D>();
            _rb2D.isTrigger = true;
            transform.position = _objectPoolPosition;

        }


        // Update is called once per frame
        void Update () {

            MoveEnemy();
            KeepPlayerInScreen();
        }

        private void MoveEnemy()
        {
            float ys = Mathf.Sin(Time.deltaTime);
            var translate = new Vector3 { x = -1 * EnemySpeed, y = _sign * ys, z = 0 };
            transform.Translate(translate);
        }

        private void KeepPlayerInScreen()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.y < 0 || pos.y > 1) _sign *= -1;
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}
