using System.ComponentModel;

public class TempProfileViewModel
{
    private int _userId;
    private string _name;
    private int _level;

    public int UserId
    { 
        get { return _userId; } 
        set { _userId = value; }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (_name == value) return;

            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Level
    {
        get { return _level; }
        set 
        {
            if (_level == value) return;

            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }

    #region Property

    public PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
