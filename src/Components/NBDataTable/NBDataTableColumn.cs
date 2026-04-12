using Microsoft.AspNetCore.Components;

namespace NeoBrutalism.Blazor;

/// <summary>Defines a column in an <see cref="NBDataTable{TItem}"/>.</summary>
/// <typeparam name="TItem">Type of the data item.</typeparam>
public class NBDataTableColumn<TItem>
{
    /// <summary>Column header text.</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>Function to extract the cell value from a row item.</summary>
    public Func<TItem, object?> Field { get; set; } = _ => null;

    /// <summary>Whether this column supports sorting.</summary>
    public bool Sortable { get; set; }

    /// <summary>Optional custom template for the cell content.</summary>
    public RenderFragment<TItem>? Template { get; set; }
}
