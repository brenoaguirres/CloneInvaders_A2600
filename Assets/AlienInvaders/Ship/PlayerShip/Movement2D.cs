using System;
using AlienInvaders.Tools.LogManager;
using UnityEngine;
using UnityEngine.Windows;

namespace Adventure.PlayerShip
{
    public class Movement2D : MonoBehaviour
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

        [Space]
        [Header("Event Flags")]
        private bool canDispatchMove = true;
        private bool canDispatchMaxSpeed = true;
        private bool canDispatchBreak = true;
        private bool canDispatchStop = true;
        #endregion

        #region PROPERTIES
        public float MoveSpeed => _moveSpeed;
        public float MaxSpeed => _maxSpeed;
        #endregion

        #region EVENTS
        public Action OnMove;
        public Action OnMaxSpeed;
        public Action OnBreak;
        public Action OnStop;
        #endregion

        #region CUSTOM METHODS
        private void MoveHorizontalAcceleration(float input, Rigidbody rigidbody)
        {
            input = Mathf.Clamp(input, -1, 1);

            _accLerpFactor += Time.deltaTime / _timeToMaxSpeed;
            _accLerpFactor = Mathf.Clamp01(_accLerpFactor);

            if (Mathf.Abs(input) > INPUT_THRESHOLD)
            {
                // Acelera��o
                _accLerpFactor += Time.deltaTime / _timeToMaxSpeed;
                _accLerpFactor = Mathf.Clamp01(_accLerpFactor);

                float targetSpeed = input * _maxSpeed;
                Vector3 targetVelocity = new Vector3(targetSpeed, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
                rigidbody.linearVelocity = Vector3.Lerp(rigidbody.linearVelocity, targetVelocity, _accLerpFactor);

                if (Mathf.Abs(rigidbody.linearVelocity.x) >= _maxSpeed)
                    DispatchMaxSpeedEvent();
                else
                    DispatchMoveEvent();
            }
            else
            {
                // Desacelera��o
                BreakHorizontalAcceleration(rigidbody);
            }
        }

        private void BreakHorizontalAcceleration(Rigidbody rigidbody)
        {
            _accLerpFactor -= Time.deltaTime / _timeToBreakSpeed;
            _accLerpFactor = Mathf.Clamp01(_accLerpFactor);

            Vector3 targetVelocity = new Vector3(0f, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
            rigidbody.linearVelocity = Vector3.Lerp(rigidbody.linearVelocity, targetVelocity, 1f - _accLerpFactor);
            
            if (Mathf.Abs(rigidbody.linearVelocity.x) <= 0)
                DispatchStopEvent();
            else
                DispatchBreakEvent();
        }

        private void MoveHorizontalImpulse(float input, Rigidbody rigidbody)
        {
            input = Mathf.Clamp(input, -1, 1);

            if (Mathf.Abs(input) > INPUT_THRESHOLD)
            {
                Vector3 targetVelocity = new Vector3(input * _maxSpeed, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
                rigidbody.linearVelocity = targetVelocity;

                DispatchMaxSpeedEvent();
            }
            else
            {
                // Desacelera��o
                BreakHorizontalImpulse(rigidbody);
            }
        }

        private void BreakHorizontalImpulse(Rigidbody rigidbody)
        {
            Vector3 targetVelocity = new Vector3(0f, rigidbody.linearVelocity.y, rigidbody.linearVelocity.z);
            rigidbody.linearVelocity = targetVelocity;

            DispatchStopEvent();
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

        #region EVENT DISPATCH
        private void DispatchMoveEvent()
        {
            if (!canDispatchMove) return;

            OnMove?.Invoke();

            canDispatchMove = false;
            canDispatchBreak = true;
            canDispatchStop = true;
        }
        private void DispatchMaxSpeedEvent()
        {
            if (!canDispatchMaxSpeed) return;

            OnMaxSpeed?.Invoke();

            canDispatchMaxSpeed = false;
            canDispatchBreak = true;
            canDispatchStop = true;
        }
        private void DispatchBreakEvent()
        {
            if (!canDispatchBreak) return;

            OnBreak?.Invoke();

            canDispatchBreak = false;
            canDispatchMove = true;
            canDispatchMaxSpeed = true;
        }
        private void DispatchStopEvent()
        {
            if (!canDispatchStop) return;

            OnStop?.Invoke();

            canDispatchStop = false;
            canDispatchMove = true;
            canDispatchMaxSpeed = true;
        }
        #endregion
    }
}