namespace AgGrid.Sample.WebApi.Models;

public class OrderItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Quantity { get; set; }
    public Decimal Amount { get; set; }
}