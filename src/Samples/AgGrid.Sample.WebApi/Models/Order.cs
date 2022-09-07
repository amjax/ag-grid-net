namespace AgGrid.Sample.WebApi.Models;
public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public decimal TotalAmount => Items.Sum(x => x.Amount);
}
