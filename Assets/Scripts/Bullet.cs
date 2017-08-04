using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour {

        // Use this for initialization
        public float BulletSpeed = 0.03f;
        private bool _isExploding;
        private Rigidbody2D _rb2d;
        private Animator _anim;
        private Collider2D _col;

        // Use this for initialization
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _col = GetComponent<Collider2D>();
            _anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!_isExploding)
            {
                var translate = new Vector3 {x = BulletSpeed, y = 0f, z = 0};
                transform.Translate(translate);
                _anim.Play("BulletIdle", -1, 0f);
            }


            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("BulletExplosion") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 3)
            {
                transform.position = new Vector3 { x = -40f, y = -40f, z = 0 };
                _isExploding = false;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //
            collision.gameObject.transform.position = new Vector3 { x = -30f, y = -40f, z = 0 };
            GameControll.Instance.Score(10);
            _anim.Play("BulletExplosion",-1, 0f);

            _isExploding = true;
        }
    }
}
