using UnityEngine;

namespace Assets.Scripts
{
    public class ScrollingObject : MonoBehaviour {

        private Rigidbody2D _rb2D;

        // Use this for initialization
        void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _rb2D.velocity = new Vector2(GameControll.Instance.ScrollSpeed, 0);
        }

        // Update is called once per frame
        void Update () {
		
        }
    }
}
