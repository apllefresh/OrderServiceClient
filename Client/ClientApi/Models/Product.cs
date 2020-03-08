namespace ClientApi.Models
{
    public class Product
    {
        public Product(
            int id,
            string code,
            string name,
            int quantity,
            int cellId,
            int orderId,
            int externalId)
        {
            Id = id;
            Code = code;
            Name = name;
            Quantity = quantity;
            CellId = cellId;
            OrderId = orderId;
            ExternalId = externalId;
        }

        public int Id { get; }
        public int ExternalId { get; }
        public string Code { get; }
        public string Name { get; }
        public int Quantity { get; }
        public int CellId { get; }

        public int OrderId { get; }
    }
}
