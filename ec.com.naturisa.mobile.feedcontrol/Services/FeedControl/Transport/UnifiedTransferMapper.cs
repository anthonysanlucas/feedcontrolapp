namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.Transport
{
    public class UnifiedTransferMapper
    {

        public static UnifiedTransfer MapToUnifiedTransfer(object transfer)
        {
            return transfer switch
            {
                SupplierTransferResponse supplier => new UnifiedTransfer
                {
                    Id = supplier.IdSupplierTransfer, // ID del SupplierTransfer
                    TransferType = "Supplier",
                    Code = supplier.Code,
                    Origin = supplier.OriginSupplierName,
                    Destination = supplier.DestinationWarehouseName,
                    TransporterName = supplier.FreightTransporterName,
                    VehicleName = supplier.TransportName,
                    TotalSacks = supplier.TotalSacks ?? 0,
                    TotalPallets = supplier.TotalPallets ?? 0,
                    Status = supplier.LastStatusCatalogueName,
                    CreatedAt = supplier.CreatedAt,
                    OriginalData = supplier
                },
                PoolTransferResponse pool => new UnifiedTransfer
                {
                    Id = pool.IdPoolTransfer, // ID del PoolTransfer
                    TransferType = "Pool",
                    Code = pool.Code,
                    Origin = pool.OriginPoolCode,
                    Destination = pool.DestinationPoolCode,
                    TransporterName = pool.FreightTransporterName,
                    VehicleName = pool.TransportName,
                    TotalSacks = pool.TotalEquivalenceSacks,
                    TotalPallets = pool.TotalEquivalencePallets,
                    Status = pool.Status,
                    CreatedAt = pool.CreatedAt,
                    OriginalData = pool
                },
                WarehouseTransferResponse warehouse => new UnifiedTransfer
                {
                    Id = warehouse.IdWarehouseTransfer, // ID del WarehouseTransfer
                    TransferType = "Warehouse",
                    Code = warehouse.Code,
                    Origin = warehouse.OriginWarehouseName,
                    Destination = warehouse.DestinationWarehouseName,
                    TransporterName = warehouse.FreightTransporterName,
                    VehicleName = warehouse.TransportName,
                    TotalSacks = warehouse.TotalEquivalenceSacks,
                    TotalPallets = warehouse.TotalEquivalencePallets,
                    Status = warehouse.LastStatusCatalogueName,
                    CreatedAt = warehouse.CreatedAt,
                    OriginalData = warehouse
                },
                FeedTransferModel feed => new UnifiedTransfer
                {
                    Id = feed.IdFeedTransfer ?? 0, // ID del FeedTransfer
                    TransferType = "Feed",
                    Code = feed.TransferCode,
                    Origin = feed.OriginSubsidiaryName,
                    Destination = feed.DestinationSubsidiaryName,
                    TransporterName = feed.AssignedCarrierName,
                    VehicleName = feed.AssignedVehiclePlate,
                    TotalSacks = feed.TotalSacks,
                    TotalPallets = feed.ApproximatePallets,
                    Status = feed.Status,
                    CreatedAt = feed.AssignedDate,
                    OriginalData = feed
                },
                _ => throw new NotImplementedException("Tipo de transferencia no soportado.")
            };
        }
    }
}
