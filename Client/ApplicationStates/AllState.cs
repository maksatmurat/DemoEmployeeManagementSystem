namespace Client.ApplicationStates;

public class AllState
{
    //Scope action
    public Action? Action { get; set; }
    //General Department
    public bool ShowGeneralDepartment { get; set; }
    public void GeneralDepartmentClicked()
    {
        ResetAllDepartments();
        ShowGeneralDepartment = true;
        Action?.Invoke();
    }
    //Department
    public bool ShowDepartment { get; set; }
    public void DepartmentClicked()
    {
        ResetAllDepartments();
        ShowDepartment = true;
        Action?.Invoke();
    }
    //Branch
    public bool ShowBranch { get; set; }
    public void BranchClicked()
    {
        ResetAllDepartments();
        ShowBranch = true;
        Action?.Invoke();
    }

    //Country
    public bool ShowCountry { get; set; }
    public void CountryClicked()
    {
        ResetAllDepartments();
        ShowCountry = true;
        Action?.Invoke();
    }
    //City
    public bool ShowCity { get; set; }
    public void CityClicked()
    {
        ResetAllDepartments();
        ShowCity = true;
        Action?.Invoke();
    }
    //Town
    public bool ShowTown { get; set; }
    public void TownClicked()
    {
        ResetAllDepartments();
        ShowTown = true;
        Action?.Invoke();
    }
    //User
    public bool ShowUser { get; set; }
    public void UserClicked()
    {
        ResetAllDepartments();
        ShowUser = true;
        Action?.Invoke();
    }
    //Employee
    public bool ShowEmployee { get; set; }
    public void EmployeeClicked()
    {
        ResetAllDepartments();
        ShowEmployee = true;
        Action?.Invoke();
    }

    private void ResetAllDepartments()
    {
        ShowGeneralDepartment = false;
        ShowDepartment = false;
        ShowBranch = false;
        ShowCountry = false;
        ShowCity = false;
        ShowTown = false;
        ShowUser = false;
        ShowEmployee = false;
    }

}


//public class AllState
//{
//    // Global action
//    public Action? Action { get; set; }

//    // Tüm durumları tutan dictionary
//    private readonly Dictionary<string, bool> _states = new()
//    {
//        ["GeneralDepartment"] = false,
//        ["Department"] = false,
//        ["Branch"] = false,
//        ["Country"] = false,
//        ["City"] = false,
//        ["Town"] = false,
//        ["User"] = false,
//        ["Employee"] = false,
//    };

//    // Aktif gösterim kontrolü
//    public bool this[string key] => _states.TryGetValue(key, out var value) && value;

//    // Tüm alanları sıfırlar
//    private void ResetAll() => _states.Keys.ToList().ForEach(k => _states[k] = false);

//    // Genel amaçlı "Click" metodu
//    public void Click(string key)
//    {
//        if (!_states.ContainsKey(key))
//            throw new ArgumentException($"Invalid key: {key}");

//        ResetAll();
//        _states[key] = true;
//        Action?.Invoke();
//    }

//    // Yardımcı özellikler (isteğe bağlı)
//    public bool ShowGeneralDepartment => this["GeneralDepartment"];
//    public bool ShowDepartment => this["Department"];
//    public bool ShowBranch => this["Branch"];
//    public bool ShowCountry => this["Country"];
//    public bool ShowCity => this["City"];
//    public bool ShowTown => this["Town"];
//    public bool ShowUser => this["User"];
//    public bool ShowEmployee => this["Employee"];
//}
