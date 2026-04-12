namespace NeoBrutalism.Blazor;

/// <summary>Service to trigger toast notifications. Register as scoped or singleton in DI.</summary>
public class NBSonnerService
{
    /// <summary>Raised when a new toast should be shown.</summary>
    public event Action<NBToast>? OnShow;

    /// <summary>Show a toast with the given options.</summary>
    public void Show(string message, string? description = null, NBToastVariant variant = NBToastVariant.Default, int durationMs = 4000)
    {
        var toast = new NBToast
        {
            Message = message,
            Description = description,
            Variant = variant,
            DurationMs = durationMs
        };
        OnShow?.Invoke(toast);
    }

    /// <summary>Show a success toast.</summary>
    public void Success(string message, string? description = null) => Show(message, description, NBToastVariant.Success);

    /// <summary>Show an error toast.</summary>
    public void Error(string message, string? description = null) => Show(message, description, NBToastVariant.Error);

    /// <summary>Show a warning toast.</summary>
    public void Warning(string message, string? description = null) => Show(message, description, NBToastVariant.Warning);

    /// <summary>Show an info toast.</summary>
    public void Info(string message, string? description = null) => Show(message, description, NBToastVariant.Info);
}
