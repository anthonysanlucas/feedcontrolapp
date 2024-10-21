﻿namespace ec.com.naturisa.mobile.feedcontrol.Helpers;

public class Const
{
    public static class Status
    {
        public const string Active = "ACTIVO";
        public const string Inactive = "INACTIVO";

        public static class Transfer
        {
            public const string Assigned = "ASIGNADO";
            public const string Received = "RECIBIDO";
            public const string InRoute = "EN RUTA";
            public const string Finalized = "FINALIZADO";
            public const string Delivered = "ENTREGADO";
        }
    }
}
