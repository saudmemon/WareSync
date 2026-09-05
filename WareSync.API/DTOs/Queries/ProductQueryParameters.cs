namespace WareSync.API.DTOs.Queries;

public class ProductQueryParameters
{
    public string? Keyword { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public string? SortBy { get; set; } = "Name";

    public bool Descending { get; set; } = false;

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}