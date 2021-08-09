using UnityEngine;

namespace Entity {
    public class Entity : MonoBehaviour {
        public float MovementSpeed = 3f;
        public float JumpSpeed = 10f;
        public int MidAirJumps = 0;
        public float Gravity = -30f;

        public bool IsGrounded {
            get => _isGrounded;
        }

        protected int _midAirJumps = 0;
        protected bool _jumping = false;

        private bool _isGrounded = false;

        private int _maskGround;

		protected virtual void Awake() {
			_maskGround = LayerMask.NameToLayer("Ground");
		}

		private void OnCollisionEnter(Collision collision) {
            if (collision.collider.gameObject.layer == _maskGround) {
                Ground();
                _jumping = false;
            }
        }

        private void OnCollisionStay(Collision collision) {
            if (collision.collider.gameObject.layer == _maskGround) {
                Ground();
            }
        }

        private void OnCollisionExit(Collision collision) {
            if (collision.collider.gameObject.layer == _maskGround) {
                _isGrounded = false;
            }
        }

        private void Ground() {
            _midAirJumps = 0;
            _isGrounded = true;
		}
    }
}
