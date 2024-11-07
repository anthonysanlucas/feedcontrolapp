namespace ec.com.naturisa.mobile.feedcontrol.Helpers;

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
            public const string AtDestination = "EN DESTINO";
            public const string Delivered = "ENTREGADO";
            public const string Paused = "PAUSADO";
        }

        public static class Feed
        {
            public const string Assigned = "ASIGNADO";           
            public const string OnCourse = "EN CURSO";
            public const string Fed = "ALIMENTADO";                      
        }

        public static class FeedRemaining
        {
            public const string Assigned = "ASIGNADO";            
            public const string Completed = "COMPLETADO";
        }
    }
}
