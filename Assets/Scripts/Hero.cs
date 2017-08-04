using UnityEngine;

namespace Assets.Scripts
{
    public class Hero : MonoBehaviour
    {
        public float Speed = 0.000001f;

        void Start()
        {
            var renderer = GetComponent<Renderer>();

        }

        void FixedUpdate()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touches.Length != 0)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    var toTranslate = new Vector3
                    {
                        x = touchDeltaPosition.x * GameControll.Instance.MovingSpeed,
                        y = touchDeltaPosition.y * GameControll.Instance.MovingSpeed,
                        z = 0
                    };
                    transform.position += toTranslate;
                }
                KeepPlayerInScreen();
                return;
            }
            //debug
            int y = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                y = 1;
            if (Input.GetKeyDown(KeyCode.DownArrow))
                y = -1;
            int x = 0;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                x = 1;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                x = -1;

            var toTranslate2 = new Vector3
            {
                x = x * 0.2f,
                y = y * 0.2f,
                z = 0
            };
            transform.position += toTranslate2;
            KeepPlayerInScreen();
        }

        private void KeepPlayerInScreen()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
    }
}