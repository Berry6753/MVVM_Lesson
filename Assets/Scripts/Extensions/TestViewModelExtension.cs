namespace ViewModel.Extensions
{
    public static class TestViewModelExtension
    {
        protected abstract Class class

        public static void RefreshViewModel(this  vm)
        {
            int tempId = 2;
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModel);
        }

        public static void OnRefreshViewModel(this  vm, int userId, string name, int level)
        {
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
        }

        public static void RegisterEventsOnEnable(this  vm)
        {
            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.RegisterNameChangeCallback(vm.OnResponseNameChange);
        }

        public static void UnRegisterEventsOnDisable(this  vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.UnRegisterNameChangeCallback(vm.OnResponseNameChange);
        }

        public static void OnResponseLevelUp(this  vm, int userId, int level)
        {
            if (vm.UserId != userId)
                return;

            vm.Level = level;
        }

        public static void OnResponseNameChange(this  vm, int userId, string name)
        {
            if (vm.UserId != userId)
                return;

            vm.Name = name;
        }
    }
}
