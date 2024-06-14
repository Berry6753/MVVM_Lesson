using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions;

public class TempProfileUI : MonoBehaviour
{
    [SerializeField] private Text Text_Name;
    [SerializeField] private Text Text_Level;

    private TempProfileViewModel _vm;

    private void OnEnable()
    {
        if (_vm != null) return;

        _vm = new TempProfileViewModel();
        _vm.PropertyChanged += OnPropertyChanged;
        _vm.RegisterEventsOnEnable();
        _vm.RefreshViewModel();
    }

    private void OnDisable()
    {
        if (_vm == null) return;

        _vm.UnRegisterEventsOnDisable();
        _vm.PropertyChanged -= OnPropertyChanged;
        _vm = null;
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
    { 
        switch (args.PropertyName)
        {
            case nameof(_vm.Name):
                Text_Name.text = "¿Ã∏ß : " + _vm.Name;
                break;
            case nameof(_vm.Level):
                Text_Level.text = $"Lv.{_vm.Level}";
                break;
        }
    }
}
