namespace CartaoVacina.Core.Results;

public readonly struct Result<T>
{
    private readonly string _errorMesage;
    private readonly T? _value;

    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;
    public string ErrorMesage => _errorMesage;
    public T Value => _value;

    private Result(bool isSuccess, T value, string errorMessage)
        => (IsSuccess, _value, _errorMesage) = (isSuccess, value, errorMessage);

    public static Result<T> Success(T value)
        => new(true, value, string.Empty);

    public static Result<T> Fail(string errorMessage)
        => new(false, default!, errorMessage);

    public static implicit operator bool(Result<T> result) 
        => result.IsSuccess;
}
