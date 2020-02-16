namespace ClientApi.Models
{
    public class Product
    {
        public Product(
            string code,
            string name,
            int quantity,
            int cell,
            int orderId,
            int externalId)
        {
            Code = code;
            Name = name;
            Quantity = quantity;
            Cell = cell;
            OrderId = orderId;
            ExternalId = externalId;
        }

        public int Id { get; }
        public int ExternalId { get; }
        public string Code { get; }
        public string Name { get; }
        public int Quantity { get; }
        public int Cell { get; }

        public int OrderId { get; }
    }
}
