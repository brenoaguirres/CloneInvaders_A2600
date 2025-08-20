using TMPro;
using UnityEngine;

namespace AlienInvaders.UI
{
    public class LabelValueItem : ViewItem
    {
        #region FIELDS
        [Header("LabelText References")]
        [SerializeField] private TextMeshProUGUI _labelTMP;
        [SerializeField] private TextMeshProUGUI _valueTMP;

        [Header("Optional Settings")]
        [SerializeField] private string _beforeText = "";
        [SerializeField] private string _afterText = "";
        #endregion

        #region PROPERTIES
        public string Label
        {
            get
            {
                return _labelTMP.text;
            }
            set
            {
                _labelTMP.text = _beforeText + value + _afterText;
                OnValueChanged?.Invoke(nameof(Label));
            }
        }
        public string Value
        {
            get
            {
                return _valueTMP.text;
            }
            set
            {
                _valueTMP.text = _beforeText + value + _afterText;
                OnValueChanged?.Invoke(nameof(Value));
            }
        }
        #endregion
    }
}