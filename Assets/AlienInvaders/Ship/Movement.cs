using UnityEngine;

namespace AlienInvaders.Ship
{
    public class Movement : MonoBehaviour
    {
        #region CONSTANTS
        private const float INPUT_THRESHOLD = 0.05f;
        #endregion

        #region ENUMS
        public enum ForceType
        {
            IMPULSE,
            ACCELERATION
        }
        #endregion

        #region FIELDS
        [Header("Movement Settings")]
        [SerializeField] private float _maxSpeed = 10f;
        [SerializeField] private ForceType _forceType = ForceType.ACCELERATION;

        [Space]
        [Header("Acceleration Settings")]
        [SerializeField] private float _timeToMaxSpeed = 1f;
        [SerializeField] private float _timeToBreakSpeed = 0.25f;

        private float _moveSpeed = 0f;
        private float _accLerpFactor = 0f;
        #endregion

        #region PROPERTIES
        public float MoveSpeed => _moveSpeed;
        public float MaxSpeed => _maxSpeed;
        #endregion

        #region CUSTOM METHODS
        private void MoveHorizontalAcceleration(float input, Rigidbody rigidbody)
        {
            input = Mathf.Clamp(input, -1, 1);

            _accLerpFactor += Time.deltaTime / _timeToMaxSpeed;
            _accLerpFactor = Mathf.Clamp01(_accLerpFactor);

            if (Mathf.Abs(input) > INPUT_THRESHOLD)
            {
                // Aceleração
                _accLerpFactor += Time.deltaTime / _timeToMaxSpeed;
                _accLerpFactor = Mathf.Clamp01(_accLerpFactor);

                float targetSpeed = input * _maxSpeed;
                Vector3 targetVelocity = new Vector3(targetSpeed, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
                rigidbody.linearVelocity = Vector3.Lerp(rigidbody.linearVelocity, targetVelocity, _accLerpFactor);
            }
            else
            {
                // Desaceleração
                BreakHorizontalAcceleration(rigidbody);
            }
        }

        private void BreakHorizontalAcceleration(Rigidbody rigidbody)
        {
            _accLerpFactor -= Time.deltaTime / _timeToBreakSpeed;
            _accLerpFactor = Mathf.Clamp01(_accLerpFactor);

            Vector3 targetVelocity = new Vector3(0f, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
            rigidbody.linearVelocity = Vector3.Lerp(rigidbody.linearVelocity, targetVelocity, 1f - _accLerpFactor);
        }

        private void MoveHorizontalImpulse(float input, Rigidbody rigidbody)
        {
            input = Mathf.Clamp(input, -1, 1);

            if (Mathf.Abs(input) > INPUT_THRESHOLD)
            {
                Vector3 targetVelocity = new Vector3(input * _maxSpeed, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
                rigidbody.linearVelocity = targetVelocity;
            }
            else
            {
                // Desaceleração
                BreakHorizontalImpulse(rigidbody);
            }
        }

        private void BreakHorizontalImpulse(Rigidbody rigidbody)
        {
            Vector3 targetVelocity = new Vector3(0f, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
            rigidbody.linearVelocity = targetVelocity;
        }

        public void SetForceType(ForceType _type)
        {
            _forceType = _type;
        }

        public void MoveHorizontal(float input, Rigidbody rigidbody)
        {
            if (_forceType == ForceType.ACCELERATION)
            {
                MoveHorizontalAcceleration(input, rigidbody);
            }
            else
            {
                MoveHorizontalImpulse(input, rigidbody);
            }

            _moveSpeed = Mathf.Abs(rigidbody.linearVelocity.x);
        }
        #endregion
    }
}