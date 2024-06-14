namespace ViewModel.Extensions
{
    public static class TopLeftViewModelExtension
    {
        public static void RefreshViewModel(this TopLeftViewModel vm)
        {
            int tempId = 2;
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModel);
        }

        public static void OnRefreshViewModel(this TopLeftViewModel vm, int userId, string name, int level)
        {
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
        }

        public static void BindRegisterEvents(this TopLeftViewModel vm, bool e)
        {

        }

        public static void RegisterEventsOnEnable(this TopLeftViewModel vm)
        {
            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.RegisterNameChangeCallback(vm.OnResponseNameChange);
        }

        public static void UnRegisterEventsOnDisable(this TopLeftViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.UnRegisterNameChangeCallback(vm.OnResponseNameChange);
        }

        public static void OnResponseLevelUp(this TopLeftViewModel vm, int userId, int level)
        {
            if (vm.UserId != userId)
                return;

            vm.Level = level;
        }

        public static void OnResponseNameChange(this TopLeftViewModel vm, int userId, string name)
        {
            if (vm.UserId != userId)
                return;

            vm.Name = name;
        }
    }
}