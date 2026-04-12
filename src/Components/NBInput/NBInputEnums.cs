namespace NeoBrutalism.Blazor;

/// <summary>HTML input type for an <see cref="NBInput"/>.</summary>
public enum NBInputType
{
    /// <summary>Plain text input.</summary>
    Text,
    /// <summary>Email address input.</summary>
    Email,
    /// <summary>Password (masked) input.</summary>
    Password,
    /// <summary>Numeric input.</summary>
    Number,
    /// <summary>Telephone number input.</summary>
    Tel,
    /// <summary>URL input.</summary>
    Url,
    /// <summary>Search input.</summary>
    Search
}
