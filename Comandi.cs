namespace allyoucaneat
{
    // Nomi dei comandi scambiati nel campo CommandName.
    // Usare queste costanti evita errori di battitura nelle stringhe.
    public static class Comandi
    {
        public const string Hello = "hello";                 // client -> server: [tavolo]   | server -> client: ["ok"]
        public const string GetMenu = "getMenu";             // client -> server: nessun parametro
        public const string Menu = "menu";                   // server -> client: [JSON lista piatti]
        public const string NewOrder = "newOrder";           // client -> server: [JSON ordine]
        public const string OrderReceived = "orderReceived"; // server -> client: [idOrdine]
        public const string OrderStatus = "orderStatus";     // server -> client: [idOrdine, stato]
        public const string Quit = "quit";                   // client -> server: nessun parametro
        public const string Error = "error";                 // server -> client: [messaggio]
    }
}
