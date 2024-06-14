using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions;

public class TopLeftUI : MonoBehaviour
{
    [SerializeField] private Text Text_Name;
    [SerializeField] private Text Text_Level;
    [SerializeField] private Image Image_Icon;

    // ºä ¸ðµ¨
    private TopLeftViewModel _vm;

    private void OnEnable()
    {
        if (_vm == null)
        { 
            _vm = new TopLeftViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterEventsOnEnable();
            _vm.RefreshViewModel();
        }
    }

    private void OnDisable()
    {
        if( _vm != null )
        {
            _vm.UnRegisterEventsOnDisable();
            _vm.PropertyChanged -= OnPropertyChanged;
            _vm = null;
        }
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
    { 
        switch (args.PropertyName)
        {
            case nameof(_vm.Name):
                Text_Name.text = "ÀÌ¸§ : " + _vm.Name;
                break;
            case nameof(_vm.Level):
                Text_Level.text = $"Lv.{_vm.Level}";
                break;
            case nameof(_vm.IconName):
                break;
        }
    }
}
