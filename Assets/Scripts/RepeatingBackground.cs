using UnityEngine;

namespace Assets.Scripts
{
    public class RepeatingBackground : MonoBehaviour {

        private BoxCollider2D _groundCollider;
        private float _bgLength;

        // Use this for initialization
        void Start () {
            _groundCollider = GetComponent<BoxCollider2D>();
            _bgLength = _groundCollider.size.x;
        }
	
        // Update is called once per frame
        void Update () {
            if (transform.position.x < -_bgLength) {
                RepositionBg();
            }
        }

        private void RepositionBg() {
            Vector2 groundOffset = new Vector2(_bgLength * 2, 0);
            transform.position = (Vector2)transform.position + groundOffset;
        }
    }
}
