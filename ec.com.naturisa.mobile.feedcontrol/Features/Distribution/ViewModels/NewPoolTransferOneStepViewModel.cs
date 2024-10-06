namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewPoolTransferOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<string> availablePools;

        [ObservableProperty]
        private ObservableCollection<string> selectedPools;

        [ObservableProperty]
        private string selectedPool;

        [ObservableProperty]
        private string originBranch;

        [ObservableProperty]
        private List<string> transporters;

        [ObservableProperty]
        private List<string> vehiclePlates;

        [ObservableProperty]
        private string selectedTransporter;

        [ObservableProperty]
        private string selectedVehiclePlate;

        public NewPoolTransferOneStepViewModel(IToastService toastService)
            : base(toastService)
        {
            OriginBranch = "MARICULTURA";

            // Inicializamos las piscinas disponibles
            AvailablePools = new ObservableCollection<string>
            {
                "MA001",
                "MA002",
                "MA003",
                "MA004",
                "MA005",
                "MA006",
                "MA007",
                "MA009",
                "MA010"
            };

            // Inicializamos la lista de piscinas seleccionadas
            SelectedPools = new ObservableCollection<string>();

            transporters = ["NELSON ZAMBRANO"];
            vehiclePlates = ["GCT 5936"];
        }

        // Comando para agregar una piscina seleccionada
        [RelayCommand]
        private void AddPool(string selectedPool)
        {
            if (!string.IsNullOrEmpty(selectedPool) && !SelectedPools.Contains(selectedPool))
            {
                // Agregar la piscina seleccionada a la lista de seleccionadas
                SelectedPools.Add(selectedPool);

                // Remover la piscina del Picker
                AvailablePools.Remove(selectedPool);

                // Limpiar la selección para que el picker vuelva a estar vacío
                SelectedPool = null;
            }
        }

        [RelayCommand]
        public void RemoveSelectedPool(string pool)
        {
            if (SelectedPools.Contains(pool))
            {
                // Remover de la lista seleccionada
                SelectedPools.Remove(pool);

                // Volver a agregar la piscina eliminada a la lista de disponibles
                AvailablePools.Add(pool);

                // Ordenar las piscinas disponibles
                SortAvailablePools();
            }
        }

        [RelayCommand]
        async Task GoToPoolTransferTwoStep()
        {
            if (SelectedPools.Count == 0)
            {
                await ShowToastAsync("Debe seleccionar al menos una piscina para continuar.");
                return;
            }

            await Shell.Current.GoToAsync(nameof(NewPoolTransferTwoStepView));
        }

        private void SortAvailablePools()
        {
            var sortedPools = AvailablePools.OrderBy(p => p).ToList();

            // Limpiar la colección actual y agregar los elementos ordenados
            AvailablePools.Clear();
            foreach (var pool in sortedPools)
            {
                AvailablePools.Add(pool);
            }
        }
    }
}
