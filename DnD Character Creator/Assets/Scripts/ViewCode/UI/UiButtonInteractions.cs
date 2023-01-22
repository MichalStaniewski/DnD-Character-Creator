using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class UiButtonInteractions : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] protected GameObject panel_1;
        [SerializeField] protected GameObject panel_2;

        [Header("Buttons")]
        [SerializeField] protected Button button_1;
        [SerializeField] protected Button button_2;

        private void Start()
        {
            SetButtonsAndPanels(true);
        }

        protected void SetButtonsAndPanels(bool _val)
        {
            button_1.gameObject.SetActive(!_val);
            button_2.gameObject.SetActive(_val);

            panel_1.SetActive(_val);
            panel_2.SetActive(!_val);
        }
        public void Panel_1_Button()
        {
            SetButtonsAndPanels(true);
        }

        public void Panel_2_Button()
        {
            SetButtonsAndPanels(false);
        }
    }
}
